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

        byte[] bmpHeader;

        private string fileToBeEncoded;
        private string fileToBeDecoded;
        BitReader reader;
        BitWriter writer;

        private byte[,] imageMatrix;
        private byte[,] predictionMatrix;
        private int[,] errorMatrix;

        public Bitmap ImageMatrix
        {
            get
            {
                Bitmap bitmap = new Bitmap(256, 256);
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        byte value = imageMatrix[row, column];
                        Color color = Color.FromArgb(value, value, value);
                        bitmap.SetPixel(column, row, color);
                    }
                }
                return bitmap;
            }
        }

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

        private void CreateImageMatrixFromErrorMatrix()
        {
            predictionMatrix[0, 0] = 128;
            imageMatrix[0, 0] = Helpers.Normalize(predictionMatrix[0, 0] + errorMatrix[0, 0]);

            PredictFirstRowFromErrorMatrix();
            PredictFirstColumnFromErrorMatrix();

            for (int row = 1; row < 256; row++)
            {
                for (int column = 1; column < 256; column++)
                {
                    PredictPixelFromErrorMatrix(row, column);
                }
            }
        }

        private void PredictFirstRow()
        {
            for (int column = 1; column < 256; column++)
            {
                byte a = imageMatrix[0, column - 1];
                predictionMatrix[0, column] = aPredictor.Predict(a, 0, 0);
            }
        }

        private void PredictFirstRowFromErrorMatrix()
        {
            for (int column = 1; column < 256; column++)
            {
                byte a = imageMatrix[0, column - 1];
                predictionMatrix[0, column] = aPredictor.Predict(a, 0, 0);
                imageMatrix[0, column] = Helpers.Normalize(predictionMatrix[0, column] + errorMatrix[0, column]);
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

        private void PredictFirstColumnFromErrorMatrix()
        {
            for (int row = 1; row < 256; row++)
            {
                byte b = imageMatrix[row - 1, 0];
                predictionMatrix[row, 0] = bPredictor.Predict(0, b, 0);
                imageMatrix[row, 0] = Helpers.Normalize(predictionMatrix[row, 0] + errorMatrix[row, 0]);
            }
        }

        private void PredictPixel(int row, int column)
        {
            byte a = imageMatrix[row, column - 1];
            byte b = imageMatrix[row - 1, column];
            byte c = imageMatrix[row - 1, column - 1];
            predictionMatrix[row, column] = selectedPredictor.Predict(a, b, c);
        }

        private void PredictPixelFromErrorMatrix(int row, int column)
        {
            byte a = imageMatrix[row, column - 1];
            byte b = imageMatrix[row - 1, column];
            byte c = imageMatrix[row - 1, column - 1];
            predictionMatrix[row, column] = selectedPredictor.Predict(a, b, c);
            imageMatrix[row, column] = Helpers.Normalize(predictionMatrix[row, column] + errorMatrix[row, column]);
        }

        private void ComputeError(int row, int column)
        {
            errorMatrix[row, column] = imageMatrix[row, column] - predictionMatrix[row, column];
        }

        public void Encode()
        {
            uint type = predictorTypes[selectedPredictor.GetType()];
            writer = new BitWriter(fileToBeEncoded + type + ".pre");
            using (FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open))
            {
                for (int i = 0; i < 1078; i++)
                {
                    writer.WriteNBits((uint)fs.ReadByte(), 8);
                }
            }

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
                        
                        if (value < 0)
                        {
                            int maxValueAfterZero = (int)Math.Pow(2, n) - 1;
                            uint encodedValue = (uint)(maxValueAfterZero + value);
                            writer.WriteNBits(encodedValue, n);
                        }
                        else
                        {
                            writer.WriteNBits((uint)value, n);
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

            bmpHeader = new byte[1078];
            for (int i = 0; i < 1078; i++)
            {
                bmpHeader[i] = (byte)reader.ReadNBits(8);
            }

            Dictionary<uint, Type> invertedPredictorTypes = new Dictionary<uint, Type>();
            foreach (KeyValuePair<Type, uint> pair in predictorTypes)
            {
                invertedPredictorTypes.Add(pair.Value, pair.Key);
            }

            Type type = invertedPredictorTypes[reader.ReadNBits(4)];
            selectedPredictor = (IPredictor)Activator.CreateInstance(type);

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    errorMatrix[row, column] = ReadEncodedError();
                }
            }

            reader.Dispose();

            CreateImageMatrixFromErrorMatrix();
        }

        private int ReadEncodedError()
        {
            int result;
            string bitsAfterZero = "";
            int count = 0;

            while (reader.ReadBit() != 0)
            {
                count++;
            }

            for (int i = 0; i < count; i++)
            {
                bitsAfterZero += reader.ReadBit();
            }

            if (count == 0)
            {
                result = 0;
            }
            else
            {
                int valueAfterZero = Convert.ToInt32(bitsAfterZero, 2);
                if (bitsAfterZero[0] == '0')
                {
                    int maxValueAfterZero = (int)Math.Pow(2, count) - 1;
                    result = valueAfterZero - maxValueAfterZero;
                }
                else
                {
                    result = valueAfterZero;
                }
            }

            return result;
        }

        public void storeDecodedFile()
        {
            writer = new BitWriter(fileToBeDecoded + ".decoded");

            for (int i = 0; i < 1078; i++)
            {
                writer.WriteNBits(bmpHeader[i], 8);
            }

            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    writer.WriteNBits(imageMatrix[row, column], 8);
                    writer.WriteNBits(imageMatrix[row, column], 8);
                    writer.WriteNBits(imageMatrix[row, column], 8);
                }
            }

            writer.Dispose();
        }
    }
}
