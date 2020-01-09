using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prediction.Predictors;

namespace Prediction
{
    public partial class Form1 : Form
    {
        string fileToBeEncoded;
        string fileToBeDecoded;
        ImagePrediction prediction;

        public Form1()
        {
            prediction = new ImagePrediction();
            InitializeComponent();
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
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeDecoded = openFileDialog.FileName;
                }
            }
        }

        private void buttonDecode_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveDecoded_Click(object sender, EventArgs e)
        {

        }

        private void buttonShowHistogram_Click(object sender, EventArgs e)
        {

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
        private void radioButtonHistogram1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonHistogram2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonHistogram3_CheckedChanged(object sender, EventArgs e)
        {

        }
        #endregion
    }
}
