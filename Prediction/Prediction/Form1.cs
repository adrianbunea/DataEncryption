using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using Prediction.Predictors;
using System.Windows.Forms.DataVisualization.Charting;

namespace Prediction
{
    public partial class Form1 : Form
    {
        int selectedHistogram;
        string fileToBeEncoded;
        string fileToBeDecoded;
        ImagePrediction prediction;

        public Form1()
        {
            InitializeComponent();

            prediction = new ImagePrediction();
            prediction.errorMatrixScale = (float)numericUpDownScaleEM.Value;
            selectedHistogram = 0;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.bmp;*.tiff;*.jpg;*.jpeg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeEncoded = openFileDialog.FileName;
                    using (FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open))
                    {
                        pictureBoxOriginalImage.Image = Image.FromStream(fs);
                    }
                }
            }
        }

        private void buttonPredict_Click(object sender, EventArgs e)
        {
            prediction.Predict(fileToBeEncoded);
            pictureBoxOriginalImage.Image = prediction.PredictionMatrix;
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            prediction.Encode();
        }

        private void buttonShowErrorMatrix_Click(object sender, EventArgs e)
        {
            pictureBoxErrorMatrix.Image = prediction.ErrorMatrix;
        }

        private void buttonLoadEncoded_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Prediction Files|*.pre";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeDecoded = openFileDialog.FileName;
                }
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {
            prediction.Decode(fileToBeDecoded);
            pictureBoxDecodedImage.Image = prediction.ImageMatrix;
        }

        private void buttonSaveDecoded_Click(object sender, EventArgs e)
        {
            prediction.storeDecodedFile();
        }

        #region Predictor Selection
        private void radioButtonPredictor1_CheckedChanged(object sender, EventArgs e)
        {
            HalfPredictor predictor = new HalfPredictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor2_CheckedChanged(object sender, EventArgs e)
        {
            APredictor predictor = new APredictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor3_CheckedChanged(object sender, EventArgs e)
        {
            BPredictor predictor = new BPredictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor4_CheckedChanged(object sender, EventArgs e)
        {
            CPredictor predictor = new CPredictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor5_CheckedChanged(object sender, EventArgs e)
        {
            ABCPredictor predictor = new ABCPredictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor6_CheckedChanged(object sender, EventArgs e)
        {
            ABC2Predictor predictor = new ABC2Predictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor7_CheckedChanged(object sender, EventArgs e)
        {
            BAC2Predictor predictor = new BAC2Predictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor8_CheckedChanged(object sender, EventArgs e)
        {
            AB2Predictor predictor = new AB2Predictor();
            prediction.SetPredictor(predictor);
        }

        private void radioButtonPredictor9_CheckedChanged(object sender, EventArgs e)
        {
            jpegLSPredictor predictor = new jpegLSPredictor();
            prediction.SetPredictor(predictor);
        }
        #endregion

        #region Histogram Display
        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {
            ShowHistogram();
        }

        private void radioButtonHistogram1_CheckedChanged(object sender, EventArgs e)
        {
            selectedHistogram = 0;
            ShowHistogram();
        }

        private void radioButtonHistogram2_CheckedChanged(object sender, EventArgs e)
        {
            selectedHistogram = 1;
            ShowHistogram();
        }

        private void radioButtonHistogram3_CheckedChanged(object sender, EventArgs e)
        {
            selectedHistogram = 2;
            ShowHistogram();
        }

        private void ShowHistogram()
        {
            chart1.Series.Clear();
            Series series = new Series()
            {
                MarkerSize = 3,
                CustomProperties = "IsXAxisQuantitative=True"
            };

            KeyValuePair<int, int>[] statistic;
            switch (selectedHistogram)
            {
                case 0:
                    statistic = CreateStatistic(new Bitmap(pictureBoxOriginalImage.Image));
                    break;
                case 1:
                    statistic = CreateStatistic(new Bitmap(pictureBoxErrorMatrix.Image));
                    break;
                default:
                    statistic = CreateStatistic(new Bitmap(pictureBoxDecodedImage.Image));
                    break;
            }

            series.Points.DataBind(statistic, "Key", "Value", null);
            chart1.Series.Add(series);
        }

        private KeyValuePair<int, int>[] CreateStatistic(Bitmap bitmap)
        {
            int[] initialStatistic = new int[512];
            for (int row = 0; row < 256; row++)
            {
                for (int column = 0; column < 256; column++)
                {
                    initialStatistic[bitmap.GetPixel(column, row).R + 256]++;
                }
            }

            KeyValuePair<int, int>[] statistic = new KeyValuePair<int, int>[512];

            for (int i = 0; i < 512; i++)
            {
                statistic[i] = new KeyValuePair<int, int>(i - 256, initialStatistic[i]);
            }

            return statistic;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int newMaximum = (int)(65536 / (float)numericUpDown1.Value);
            chart1.ChartAreas[0].AxisY.Maximum = newMaximum;
            chart1.ChartAreas[0].AxisY.MajorTickMark.Interval = newMaximum / 2;
            chart1.ChartAreas[0].AxisY.Interval = newMaximum;
            ShowHistogram();
        }
        #endregion

        private void numericUpDownScaleEM_ValueChanged(object sender, EventArgs e)
        {
            prediction.errorMatrixScale = (float)numericUpDownScaleEM.Value;
            pictureBoxErrorMatrix.Image = prediction.ErrorMatrix;
        }
    }
}
