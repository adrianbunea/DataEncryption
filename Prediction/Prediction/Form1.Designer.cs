namespace Prediction
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.pictureBoxOriginalImage = new System.Windows.Forms.PictureBox();
            this.pictureBoxErrorMatrix = new System.Windows.Forms.PictureBox();
            this.pictureBoxDecodedImage = new System.Windows.Forms.PictureBox();
            this.buttonLoadImage = new System.Windows.Forms.Button();
            this.buttonPredict = new System.Windows.Forms.Button();
            this.buttonStore = new System.Windows.Forms.Button();
            this.numericUpDownScaleEM = new System.Windows.Forms.NumericUpDown();
            this.labelScaleEM = new System.Windows.Forms.Label();
            this.buttonShowErrorMatrix = new System.Windows.Forms.Button();
            this.buttonSaveDecoded = new System.Windows.Forms.Button();
            this.buttonDecode = new System.Windows.Forms.Button();
            this.buttonLoadEncoded = new System.Windows.Forms.Button();
            this.panelPredictor = new System.Windows.Forms.Panel();
            this.radioButtonPredictor9 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor8 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor7 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor6 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor5 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor4 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor3 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor2 = new System.Windows.Forms.RadioButton();
            this.radioButtonPredictor1 = new System.Windows.Forms.RadioButton();
            this.labelPredictor = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonHistogram3 = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogram2 = new System.Windows.Forms.RadioButton();
            this.radioButtonHistogram1 = new System.Windows.Forms.RadioButton();
            this.labelHistogram = new System.Windows.Forms.Label();
            this.labelHistogramScale = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonShowHistogram = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleEM)).BeginInit();
            this.panelPredictor.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxOriginalImage
            // 
            this.pictureBoxOriginalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxOriginalImage.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxOriginalImage.Name = "pictureBoxOriginalImage";
            this.pictureBoxOriginalImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxOriginalImage.TabIndex = 0;
            this.pictureBoxOriginalImage.TabStop = false;
            // 
            // pictureBoxErrorMatrix
            // 
            this.pictureBoxErrorMatrix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxErrorMatrix.Location = new System.Drawing.Point(274, 12);
            this.pictureBoxErrorMatrix.Name = "pictureBoxErrorMatrix";
            this.pictureBoxErrorMatrix.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxErrorMatrix.TabIndex = 1;
            this.pictureBoxErrorMatrix.TabStop = false;
            // 
            // pictureBoxDecodedImage
            // 
            this.pictureBoxDecodedImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxDecodedImage.Location = new System.Drawing.Point(536, 12);
            this.pictureBoxDecodedImage.Name = "pictureBoxDecodedImage";
            this.pictureBoxDecodedImage.Size = new System.Drawing.Size(256, 256);
            this.pictureBoxDecodedImage.TabIndex = 2;
            this.pictureBoxDecodedImage.TabStop = false;
            // 
            // buttonLoadImage
            // 
            this.buttonLoadImage.Location = new System.Drawing.Point(12, 274);
            this.buttonLoadImage.Name = "buttonLoadImage";
            this.buttonLoadImage.Size = new System.Drawing.Size(92, 23);
            this.buttonLoadImage.TabIndex = 3;
            this.buttonLoadImage.Text = "Load Image";
            this.buttonLoadImage.UseVisualStyleBackColor = true;
            this.buttonLoadImage.Click += new System.EventHandler(this.buttonLoadImage_Click);
            // 
            // buttonPredict
            // 
            this.buttonPredict.Location = new System.Drawing.Point(110, 274);
            this.buttonPredict.Name = "buttonPredict";
            this.buttonPredict.Size = new System.Drawing.Size(82, 23);
            this.buttonPredict.TabIndex = 4;
            this.buttonPredict.Text = "Predict";
            this.buttonPredict.UseVisualStyleBackColor = true;
            this.buttonPredict.Click += new System.EventHandler(this.buttonPredict_Click);
            // 
            // buttonStore
            // 
            this.buttonStore.Location = new System.Drawing.Point(198, 274);
            this.buttonStore.Name = "buttonStore";
            this.buttonStore.Size = new System.Drawing.Size(70, 23);
            this.buttonStore.TabIndex = 5;
            this.buttonStore.Text = "Store";
            this.buttonStore.UseVisualStyleBackColor = true;
            this.buttonStore.Click += new System.EventHandler(this.buttonStore_Click);
            // 
            // numericUpDownScaleEM
            // 
            this.numericUpDownScaleEM.DecimalPlaces = 1;
            this.numericUpDownScaleEM.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownScaleEM.Location = new System.Drawing.Point(274, 277);
            this.numericUpDownScaleEM.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            65536});
            this.numericUpDownScaleEM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownScaleEM.Name = "numericUpDownScaleEM";
            this.numericUpDownScaleEM.Size = new System.Drawing.Size(36, 20);
            this.numericUpDownScaleEM.TabIndex = 6;
            this.numericUpDownScaleEM.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // labelScaleEM
            // 
            this.labelScaleEM.AutoSize = true;
            this.labelScaleEM.Location = new System.Drawing.Point(316, 279);
            this.labelScaleEM.Name = "labelScaleEM";
            this.labelScaleEM.Size = new System.Drawing.Size(90, 13);
            this.labelScaleEM.TabIndex = 7;
            this.labelScaleEM.Text = "Error Matrix Scale";
            // 
            // buttonShowErrorMatrix
            // 
            this.buttonShowErrorMatrix.Location = new System.Drawing.Point(412, 274);
            this.buttonShowErrorMatrix.Name = "buttonShowErrorMatrix";
            this.buttonShowErrorMatrix.Size = new System.Drawing.Size(118, 23);
            this.buttonShowErrorMatrix.TabIndex = 8;
            this.buttonShowErrorMatrix.Text = "Show Error Matrix";
            this.buttonShowErrorMatrix.UseVisualStyleBackColor = true;
            this.buttonShowErrorMatrix.Click += new System.EventHandler(this.buttonShowErrorMatrix_Click);
            // 
            // buttonSaveDecoded
            // 
            this.buttonSaveDecoded.Location = new System.Drawing.Point(700, 274);
            this.buttonSaveDecoded.Name = "buttonSaveDecoded";
            this.buttonSaveDecoded.Size = new System.Drawing.Size(92, 23);
            this.buttonSaveDecoded.TabIndex = 11;
            this.buttonSaveDecoded.Text = "Save Decoded";
            this.buttonSaveDecoded.UseVisualStyleBackColor = true;
            this.buttonSaveDecoded.Click += new System.EventHandler(this.buttonSaveDecoded_Click);
            // 
            // buttonDecode
            // 
            this.buttonDecode.Location = new System.Drawing.Point(612, 274);
            this.buttonDecode.Name = "buttonDecode";
            this.buttonDecode.Size = new System.Drawing.Size(82, 23);
            this.buttonDecode.TabIndex = 10;
            this.buttonDecode.Text = "Decode";
            this.buttonDecode.UseVisualStyleBackColor = true;
            this.buttonDecode.Click += new System.EventHandler(this.buttonDecode_Click);
            // 
            // buttonLoadEncoded
            // 
            this.buttonLoadEncoded.Location = new System.Drawing.Point(536, 274);
            this.buttonLoadEncoded.Name = "buttonLoadEncoded";
            this.buttonLoadEncoded.Size = new System.Drawing.Size(70, 23);
            this.buttonLoadEncoded.TabIndex = 9;
            this.buttonLoadEncoded.Text = "Load Encoded";
            this.buttonLoadEncoded.UseVisualStyleBackColor = true;
            this.buttonLoadEncoded.Click += new System.EventHandler(this.buttonLoadEncoded_Click);
            // 
            // panelPredictor
            // 
            this.panelPredictor.Controls.Add(this.radioButtonPredictor9);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor8);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor7);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor6);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor5);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor4);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor3);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor2);
            this.panelPredictor.Controls.Add(this.radioButtonPredictor1);
            this.panelPredictor.Location = new System.Drawing.Point(12, 330);
            this.panelPredictor.Name = "panelPredictor";
            this.panelPredictor.Size = new System.Drawing.Size(100, 209);
            this.panelPredictor.TabIndex = 12;
            // 
            // radioButtonPredictor9
            // 
            this.radioButtonPredictor9.AutoSize = true;
            this.radioButtonPredictor9.Location = new System.Drawing.Point(3, 187);
            this.radioButtonPredictor9.Name = "radioButtonPredictor9";
            this.radioButtonPredictor9.Size = new System.Drawing.Size(58, 17);
            this.radioButtonPredictor9.TabIndex = 8;
            this.radioButtonPredictor9.TabStop = true;
            this.radioButtonPredictor9.Text = "jpegLS";
            this.radioButtonPredictor9.UseVisualStyleBackColor = true;
            this.radioButtonPredictor9.CheckedChanged += new System.EventHandler(this.radioButtonPredictor9_CheckedChanged);
            // 
            // radioButtonPredictor8
            // 
            this.radioButtonPredictor8.AutoSize = true;
            this.radioButtonPredictor8.Location = new System.Drawing.Point(3, 164);
            this.radioButtonPredictor8.Name = "radioButtonPredictor8";
            this.radioButtonPredictor8.Size = new System.Drawing.Size(74, 17);
            this.radioButtonPredictor8.TabIndex = 7;
            this.radioButtonPredictor8.TabStop = true;
            this.radioButtonPredictor8.Text = "(A + B) / 2";
            this.radioButtonPredictor8.UseVisualStyleBackColor = true;
            this.radioButtonPredictor8.CheckedChanged += new System.EventHandler(this.radioButtonPredictor8_CheckedChanged);
            // 
            // radioButtonPredictor7
            // 
            this.radioButtonPredictor7.AutoSize = true;
            this.radioButtonPredictor7.Location = new System.Drawing.Point(3, 141);
            this.radioButtonPredictor7.Name = "radioButtonPredictor7";
            this.radioButtonPredictor7.Size = new System.Drawing.Size(90, 17);
            this.radioButtonPredictor7.TabIndex = 6;
            this.radioButtonPredictor7.TabStop = true;
            this.radioButtonPredictor7.Text = "B + (A - C) / 2";
            this.radioButtonPredictor7.UseVisualStyleBackColor = true;
            this.radioButtonPredictor7.CheckedChanged += new System.EventHandler(this.radioButtonPredictor7_CheckedChanged);
            // 
            // radioButtonPredictor6
            // 
            this.radioButtonPredictor6.AutoSize = true;
            this.radioButtonPredictor6.Location = new System.Drawing.Point(3, 118);
            this.radioButtonPredictor6.Name = "radioButtonPredictor6";
            this.radioButtonPredictor6.Size = new System.Drawing.Size(90, 17);
            this.radioButtonPredictor6.TabIndex = 5;
            this.radioButtonPredictor6.TabStop = true;
            this.radioButtonPredictor6.Text = "A + (B - C) / 2";
            this.radioButtonPredictor6.UseVisualStyleBackColor = true;
            this.radioButtonPredictor6.CheckedChanged += new System.EventHandler(this.radioButtonPredictor6_CheckedChanged);
            // 
            // radioButtonPredictor5
            // 
            this.radioButtonPredictor5.AutoSize = true;
            this.radioButtonPredictor5.Location = new System.Drawing.Point(3, 95);
            this.radioButtonPredictor5.Name = "radioButtonPredictor5";
            this.radioButtonPredictor5.Size = new System.Drawing.Size(67, 17);
            this.radioButtonPredictor5.TabIndex = 4;
            this.radioButtonPredictor5.TabStop = true;
            this.radioButtonPredictor5.Text = "A + B - C";
            this.radioButtonPredictor5.UseVisualStyleBackColor = true;
            this.radioButtonPredictor5.CheckedChanged += new System.EventHandler(this.radioButtonPredictor5_CheckedChanged);
            // 
            // radioButtonPredictor4
            // 
            this.radioButtonPredictor4.AutoSize = true;
            this.radioButtonPredictor4.Location = new System.Drawing.Point(3, 72);
            this.radioButtonPredictor4.Name = "radioButtonPredictor4";
            this.radioButtonPredictor4.Size = new System.Drawing.Size(32, 17);
            this.radioButtonPredictor4.TabIndex = 3;
            this.radioButtonPredictor4.TabStop = true;
            this.radioButtonPredictor4.Text = "C";
            this.radioButtonPredictor4.UseVisualStyleBackColor = true;
            this.radioButtonPredictor4.CheckedChanged += new System.EventHandler(this.radioButtonPredictor4_CheckedChanged);
            // 
            // radioButtonPredictor3
            // 
            this.radioButtonPredictor3.AutoSize = true;
            this.radioButtonPredictor3.Location = new System.Drawing.Point(3, 49);
            this.radioButtonPredictor3.Name = "radioButtonPredictor3";
            this.radioButtonPredictor3.Size = new System.Drawing.Size(32, 17);
            this.radioButtonPredictor3.TabIndex = 2;
            this.radioButtonPredictor3.TabStop = true;
            this.radioButtonPredictor3.Text = "B";
            this.radioButtonPredictor3.UseVisualStyleBackColor = true;
            this.radioButtonPredictor3.CheckedChanged += new System.EventHandler(this.radioButtonPredictor3_CheckedChanged);
            // 
            // radioButtonPredictor2
            // 
            this.radioButtonPredictor2.AutoSize = true;
            this.radioButtonPredictor2.Location = new System.Drawing.Point(3, 26);
            this.radioButtonPredictor2.Name = "radioButtonPredictor2";
            this.radioButtonPredictor2.Size = new System.Drawing.Size(32, 17);
            this.radioButtonPredictor2.TabIndex = 1;
            this.radioButtonPredictor2.TabStop = true;
            this.radioButtonPredictor2.Text = "A";
            this.radioButtonPredictor2.UseVisualStyleBackColor = true;
            this.radioButtonPredictor2.CheckedChanged += new System.EventHandler(this.radioButtonPredictor2_CheckedChanged);
            // 
            // radioButtonPredictor1
            // 
            this.radioButtonPredictor1.AutoSize = true;
            this.radioButtonPredictor1.Location = new System.Drawing.Point(3, 3);
            this.radioButtonPredictor1.Name = "radioButtonPredictor1";
            this.radioButtonPredictor1.Size = new System.Drawing.Size(43, 17);
            this.radioButtonPredictor1.TabIndex = 0;
            this.radioButtonPredictor1.TabStop = true;
            this.radioButtonPredictor1.Text = "128";
            this.radioButtonPredictor1.UseVisualStyleBackColor = true;
            this.radioButtonPredictor1.CheckedChanged += new System.EventHandler(this.radioButtonPredictor1_CheckedChanged);
            // 
            // labelPredictor
            // 
            this.labelPredictor.AutoSize = true;
            this.labelPredictor.Location = new System.Drawing.Point(12, 314);
            this.labelPredictor.Name = "labelPredictor";
            this.labelPredictor.Size = new System.Drawing.Size(49, 13);
            this.labelPredictor.TabIndex = 13;
            this.labelPredictor.Text = "Predictor";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonHistogram3);
            this.panel1.Controls.Add(this.radioButtonHistogram2);
            this.panel1.Controls.Add(this.radioButtonHistogram1);
            this.panel1.Location = new System.Drawing.Point(159, 330);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(109, 71);
            this.panel1.TabIndex = 13;
            // 
            // radioButtonHistogram3
            // 
            this.radioButtonHistogram3.AutoSize = true;
            this.radioButtonHistogram3.Location = new System.Drawing.Point(3, 49);
            this.radioButtonHistogram3.Name = "radioButtonHistogram3";
            this.radioButtonHistogram3.Size = new System.Drawing.Size(69, 17);
            this.radioButtonHistogram3.TabIndex = 2;
            this.radioButtonHistogram3.Text = "Decoded";
            this.radioButtonHistogram3.UseVisualStyleBackColor = true;
            this.radioButtonHistogram3.CheckedChanged += new System.EventHandler(this.radioButtonHistogram3_CheckedChanged);
            // 
            // radioButtonHistogram2
            // 
            this.radioButtonHistogram2.AutoSize = true;
            this.radioButtonHistogram2.Location = new System.Drawing.Point(3, 26);
            this.radioButtonHistogram2.Name = "radioButtonHistogram2";
            this.radioButtonHistogram2.Size = new System.Drawing.Size(97, 17);
            this.radioButtonHistogram2.TabIndex = 1;
            this.radioButtonHistogram2.Text = "Error Prediction";
            this.radioButtonHistogram2.UseVisualStyleBackColor = true;
            this.radioButtonHistogram2.CheckedChanged += new System.EventHandler(this.radioButtonHistogram2_CheckedChanged);
            // 
            // radioButtonHistogram1
            // 
            this.radioButtonHistogram1.AutoSize = true;
            this.radioButtonHistogram1.Location = new System.Drawing.Point(3, 3);
            this.radioButtonHistogram1.Name = "radioButtonHistogram1";
            this.radioButtonHistogram1.Size = new System.Drawing.Size(60, 17);
            this.radioButtonHistogram1.TabIndex = 0;
            this.radioButtonHistogram1.Text = "Original";
            this.radioButtonHistogram1.UseVisualStyleBackColor = true;
            this.radioButtonHistogram1.CheckedChanged += new System.EventHandler(this.radioButtonHistogram1_CheckedChanged);
            // 
            // labelHistogram
            // 
            this.labelHistogram.AutoSize = true;
            this.labelHistogram.Location = new System.Drawing.Point(159, 314);
            this.labelHistogram.Name = "labelHistogram";
            this.labelHistogram.Size = new System.Drawing.Size(54, 13);
            this.labelHistogram.TabIndex = 14;
            this.labelHistogram.Text = "Histogram";
            // 
            // labelHistogramScale
            // 
            this.labelHistogramScale.AutoSize = true;
            this.labelHistogramScale.Location = new System.Drawing.Point(201, 409);
            this.labelHistogramScale.Name = "labelHistogramScale";
            this.labelHistogramScale.Size = new System.Drawing.Size(34, 13);
            this.labelHistogramScale.TabIndex = 16;
            this.labelHistogramScale.Text = "Scale";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 1;
            this.numericUpDown1.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(159, 407);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(36, 20);
            this.numericUpDown1.TabIndex = 15;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // buttonShowHistogram
            // 
            this.buttonShowHistogram.Location = new System.Drawing.Point(159, 433);
            this.buttonShowHistogram.Name = "buttonShowHistogram";
            this.buttonShowHistogram.Size = new System.Drawing.Size(109, 23);
            this.buttonShowHistogram.TabIndex = 17;
            this.buttonShowHistogram.Text = "Show Histogram";
            this.buttonShowHistogram.UseVisualStyleBackColor = true;
            this.buttonShowHistogram.Click += new System.EventHandler(this.buttonShowHistogram_Click);
            // 
            // chart1
            // 
            chartArea6.AxisX.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea6.AxisX.Interval = 128D;
            chartArea6.AxisX.IsStartedFromZero = false;
            chartArea6.AxisX.MajorGrid.Enabled = false;
            chartArea6.AxisX.MajorTickMark.Interval = 32D;
            chartArea6.AxisX.Maximum = 256D;
            chartArea6.AxisX.Minimum = -256D;
            chartArea6.AxisX.Title = "Intensity";
            chartArea6.AxisY.ArrowStyle = System.Windows.Forms.DataVisualization.Charting.AxisArrowStyle.SharpTriangle;
            chartArea6.AxisY.Interval = 65536D;
            chartArea6.AxisY.MajorGrid.Enabled = false;
            chartArea6.AxisY.MajorTickMark.Interval = 16384D;
            chartArea6.AxisY.Maximum = 65536D;
            chartArea6.AxisY.Minimum = 0D;
            chartArea6.AxisY.Title = "Frequency (# of Pixels)";
            chartArea6.AxisY.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea6.InnerPlotPosition.Auto = false;
            chartArea6.InnerPlotPosition.Height = 73F;
            chartArea6.InnerPlotPosition.Width = 83F;
            chartArea6.InnerPlotPosition.X = 10F;
            chartArea6.InnerPlotPosition.Y = 7F;
            chartArea6.Name = "ChartArea1";
            chartArea6.Position.Auto = false;
            chartArea6.Position.Height = 84F;
            chartArea6.Position.Width = 94F;
            chartArea6.Position.X = 5F;
            chartArea6.Position.Y = 15F;
            this.chart1.ChartAreas.Add(chartArea6);
            legend6.Enabled = false;
            legend6.Name = "Legend1";
            this.chart1.Legends.Add(legend6);
            this.chart1.Location = new System.Drawing.Point(290, 314);
            this.chart1.Name = "chart1";
            series6.ChartArea = "ChartArea1";
            series6.Legend = "Legend1";
            series6.Name = "Series1";
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(502, 225);
            this.chart1.TabIndex = 18;
            this.chart1.Text = "chart1";
            title6.Name = "Title1";
            title6.Text = "Histogram";
            this.chart1.Titles.Add(title6);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 549);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.buttonShowHistogram);
            this.Controls.Add(this.labelHistogramScale);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelHistogram);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelPredictor);
            this.Controls.Add(this.panelPredictor);
            this.Controls.Add(this.buttonSaveDecoded);
            this.Controls.Add(this.buttonDecode);
            this.Controls.Add(this.buttonLoadEncoded);
            this.Controls.Add(this.buttonShowErrorMatrix);
            this.Controls.Add(this.labelScaleEM);
            this.Controls.Add(this.numericUpDownScaleEM);
            this.Controls.Add(this.buttonStore);
            this.Controls.Add(this.buttonPredict);
            this.Controls.Add(this.buttonLoadImage);
            this.Controls.Add(this.pictureBoxDecodedImage);
            this.Controls.Add(this.pictureBoxErrorMatrix);
            this.Controls.Add(this.pictureBoxOriginalImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOriginalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxErrorMatrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDecodedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownScaleEM)).EndInit();
            this.panelPredictor.ResumeLayout(false);
            this.panelPredictor.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxOriginalImage;
        private System.Windows.Forms.PictureBox pictureBoxErrorMatrix;
        private System.Windows.Forms.PictureBox pictureBoxDecodedImage;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonPredict;
        private System.Windows.Forms.Button buttonStore;
        private System.Windows.Forms.NumericUpDown numericUpDownScaleEM;
        private System.Windows.Forms.Label labelScaleEM;
        private System.Windows.Forms.Button buttonShowErrorMatrix;
        private System.Windows.Forms.Button buttonSaveDecoded;
        private System.Windows.Forms.Button buttonDecode;
        private System.Windows.Forms.Button buttonLoadEncoded;
        private System.Windows.Forms.Panel panelPredictor;
        private System.Windows.Forms.RadioButton radioButtonPredictor9;
        private System.Windows.Forms.RadioButton radioButtonPredictor8;
        private System.Windows.Forms.RadioButton radioButtonPredictor7;
        private System.Windows.Forms.RadioButton radioButtonPredictor6;
        private System.Windows.Forms.RadioButton radioButtonPredictor5;
        private System.Windows.Forms.RadioButton radioButtonPredictor4;
        private System.Windows.Forms.RadioButton radioButtonPredictor3;
        private System.Windows.Forms.RadioButton radioButtonPredictor2;
        private System.Windows.Forms.RadioButton radioButtonPredictor1;
        private System.Windows.Forms.Label labelPredictor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonHistogram3;
        private System.Windows.Forms.RadioButton radioButtonHistogram2;
        private System.Windows.Forms.RadioButton radioButtonHistogram1;
        private System.Windows.Forms.Label labelHistogram;
        private System.Windows.Forms.Label labelHistogramScale;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonShowHistogram;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

