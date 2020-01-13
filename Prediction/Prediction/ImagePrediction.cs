using System;
using System.Drawing;
using System.IO;
using Prediction.Predictors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitReaderWriter;

namespace Prediction
{
    class ImagePrediction
    {
        private Dictionary<Type, uint> predictorTypes = new Dictionary<Type, uint> {
            { typeof(HalfPredictor), 0 },
            { typeof(APredictor), 1 },
            { typeof(BPredictor), 2 },
            { typeof(CPredictor), 3 },
            { typeof(ABCPredictor), 4 },
            { typeof(ABC2Predictor), 5 },
            { typeof(BAC2Predictor), 6 },
            { typeof(AB2Predictor), 7 },
            { typeof(jpegLSPredictor), 8 },
        };

        private string fileToBeEncoded;
        private string fileToBeDecoded;
        BitReader reader;
        BitWriter writer;

        private byte[,] imageMatrix;
        private byte[,] predictionMatrix;
        private int[,] errorMatrix;

        public Bitmap PredictionMatrix
        {
            get
            {
                Bitmap bitmap = new Bitmap(256,256);
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        byte value = predictionMatrix[row, column];
                        Color color = Color.FromArgb(value, value, value);
                        bitmap.SetPixel(column, row, color);
                    }
                }
                return bitmap;
            }
        }

        public Bitmap ErrorMatrix
        {
            get
            {
                Bitmap bitmap = new Bitmap(256, 256);
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        byte value = Helpers.Normalize(errorMatrix[row, column] + 128);
                        Color color = Color.FromArgb(value, value, value);
                        bitmap.SetPixel(column, row, color);
                    }
                }
                return bitmap;
            }
        }

        private IPredictor selectedPredictor;
        private APredictor aPredictor = new APredictor();
        private BPredictor bPredictor = new BPredictor();

        public void SetPredictor(IPredictor predictor)
        {
            this.selectedPredictor = predictor;
        }

        public ImagePrediction()
        {
            this.predictionMatrix = new byte[256, 256];
            this.imageMatrix = new byte[256, 256];
            this.errorMatrix = new int[256, 256];
        }

        public void Predict(string fileToBeEncoded)
        {
            this.fileToBeEncoded = fileToBeEncoded;
            CreateImageMatrix();

            if (selectedPredictor.GetType() == typeof(HalfPredictor))
            {
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        predictionMatrix[row, column] = selectedPredictor.Predict(0, 0, 0);
                        ComputeError(row, column);
                    }
                }
            }
            else
            {
                predictionMatrix[0, 0] = 128;
                PredictFirstRow();
                PredictFirstColumn();

                for (int row = 1; row < 256; row++)
                {
                    for (int column = 1; column < 256; column++)
                    {
                        PredictPixel(row, column);
                        ComputeError(row, column);
                    }
                }
            }
        }

        private void CreateImageMatrix()
        {
            Image image = Image.FromFile(fileToBeEncoded);
            Bitmap bitmap = new Bitmap(image, 256, 256);

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    // Image is assumed to be grayscale => any color value = average of the 3 color components
                    imageMatrix[row, column] = bitmap.GetPixel(column, row).R;
                }
            }

            bitmap.Dispose();
            image.Dispose();
        }

        private void PredictFirstRow()
        {
            for (int column = 1; column < 256; column++)
            {
                byte a = imageMatrix[0, column - 1];
                predictionMatrix[0, column] = aPredictor.Predict(a, 0, 0);
            }
        }

        private void PredictFirstColumn()
        {
            for (int row = 1; row < 256; row++)
            {
                byte b = imageMatrix[row - 1, 0];
                predictionMatrix[row, 0] = bPredictor.Predict(0, b, 0);
            }
        }

        private void PredictPixel(int row, int column)
        {
            byte a = imageMatrix[row, column - 1];
            byte b = imageMatrix[row - 1, column];
            byte c = imageMatrix[row - 1, column - 1];
            predictionMatrix[row, column] = selectedPredictor.Predict(a, b, c);
        }

        private void ComputeError(int row, int column)
        {
            errorMatrix[row, column] = imageMatrix[row, column] - predictionMatrix[row, column];
        }

        public void Encode()
        {
            writer = new BitWriter(fileToBeEncoded + ".pre");
            using (FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open))
            {
                for (int i = 0; i < 1078; i++)
                {
                    writer.WriteNBits((uint)fs.ReadByte(), 8);
                }
            }

            uint type = predictorTypes[selectedPredictor.GetType()];
            writer.WriteNBits(type, 4);

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    WriteEncodedError(errorMatrix[row, column]);
                }
            }

            writer.Dispose();
        }

        private void WriteEncodedError(int value)
        {
            //Console.WriteLine(value);
            if (value == 0)
            {
                writer.WriteNBits(0, 1);
            }
            else
            {
                for (int n = 1; n <= 8; n++)
                {
                    if (Math.Abs(value) < Math.Pow(2, n))
                    {
                        writer.WriteNBits(255, n);
                        writer.WriteBit(0);
                        
                        if (value > 0)
                        {
                            writer.WriteNBits((uint)value, n);
                        }
                        else
                        {
                            uint temp = (uint)(Math.Pow(2, n) + value - 1);
                            writer.WriteNBits(temp, n);
                        }

                        break;
                    }
                }
            }
        }

        public void Decode(string fileToBeDecoded)
        {
            this.fileToBeDecoded = fileToBeDecoded;
            reader = new BitReader(fileToBeDecoded);
            writer = new BitWriter(fileToBeDecoded + ".bmp");
            for (int i = 0; i < 1078; i++)
            {
                writer.WriteNBits(reader.ReadNBits(8), 8);
            }

            Dictionary<uint, Type> invertePredictorTypes = new Dictionary<uint, Type>();
            foreach (KeyValuePair<Type, uint> pair in predictorTypes)
            {
                invertePredictorTypes.Add(pair.Value, pair.Key);
            }

            Type type = invertePredictorTypes[reader.ReadNBits(4)];
            selectedPredictor = (IPredictor)Activator.CreateInstance(type);

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    errorMatrix[row, column] = ReadEncodedError();
                }
            }
        }

        private int ReadEncodedError()
        {
            int result;
            string readBits = "";
            byte bit;
            int count = 0;

            while ((bit = reader.ReadBit()) != 0)
            {
                readBits += bit;
                count++;
            }

            readBits += bit;

            for (int i = 0; i < count; i++)
            {
                readBits += reader.ReadBit();
            }

            if (count == 0)
            {
                result = 0;
            }
            else
            {
                string bitsAfterZero = readBits.Substring(count + 1, count);
                if (bitsAfterZero[0] == '0')
                {
                    int temp = Convert.ToInt32(bitsAfterZero, 2);
                    result = -((int)Math.Pow(2, count) - 1);
                    result += temp;
                }
                else
                {
                    result = Convert.ToInt32(bitsAfterZero, 2);
                }
            }
            Console.WriteLine(result);
            return result;
        }
    }
}
