using System;
using System.Drawing;
using System.IO;
using Prediction.Predictors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prediction
{
    class ImagePrediction
    {
        private string fileToBeEncoded;
        private string fileToBeDecoded;

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
            CreateImageMatrix(fileToBeEncoded);

            if (selectedPredictor.GetType() == typeof(HalfPredictor))
            {
                for (int row = 0; row < 256; row++)
                {
                    for (int column = 0; column < 256; column++)
                    {
                        predictionMatrix[row, column] = 128;
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

        private void CreateImageMatrix(string fileToBeEncoded)
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
        }

        private void PredictFirstRow()
        {
            for (int column = 1; column < 256; column++)
            {
                byte a = imageMatrix[0, column - 1];
                Block block = new Block(a, 0, 0);
                predictionMatrix[0, column] = aPredictor.Predict(block);
            }
        }

        private void PredictFirstColumn()
        {
            for (int row = 1; row < 256; row++)
            {
                byte b = imageMatrix[row - 1, 0];
                Block block = new Block(0, b, 0);
                predictionMatrix[row, 0] = bPredictor.Predict(block);
            }
        }

        private void PredictPixel(int row, int column)
        {
            byte a = imageMatrix[row, column - 1];
            byte b = imageMatrix[row - 1, column];
            byte c = imageMatrix[row - 1, column - 1];
            Block block = new Block(a, b, c);
            predictionMatrix[row, column] = selectedPredictor.Predict(block);
        }

        private void ComputeError(int row, int column)
        {
            errorMatrix[row, column] = imageMatrix[row, column] - predictionMatrix[row, column];
        }

        public void Encode()
        {

        }
    }
}
