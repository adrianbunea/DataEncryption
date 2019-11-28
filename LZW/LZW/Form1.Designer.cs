namespace LZW
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.encoderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decoderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexBits = new System.Windows.Forms.NumericUpDown();
            this.labelIndexBits = new System.Windows.Forms.Label();
            this.radioButtonFreeze = new System.Windows.Forms.RadioButton();
            this.radioButtonEmpty = new System.Windows.Forms.RadioButton();
            this.listBoxIndexes = new System.Windows.Forms.ListBox();
            this.checkBoxShowIndexes = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexBits)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encoderToolStripMenuItem,
            this.decoderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(269, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // encoderToolStripMenuItem
            // 
            this.encoderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.encodeToolStripMenuItem});
            this.encoderToolStripMenuItem.Name = "encoderToolStripMenuItem";
            this.encoderToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.encoderToolStripMenuItem.Text = "Encoder";
            // 
            // decoderToolStripMenuItem
            // 
            this.decoderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.decodeToolStripMenuItem});
            this.decoderToolStripMenuItem.Name = "decoderToolStripMenuItem";
            this.decoderToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.decoderToolStripMenuItem.Text = "Decoder";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // decodeToolStripMenuItem
            // 
            this.decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            this.decodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.decodeToolStripMenuItem.Text = "Decode";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            // 
            // encodeToolStripMenuItem
            // 
            this.encodeToolStripMenuItem.Name = "encodeToolStripMenuItem";
            this.encodeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.encodeToolStripMenuItem.Text = "Encode";
            // 
            // indexBits
            // 
            this.indexBits.Increment = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.indexBits.Location = new System.Drawing.Point(92, 34);
            this.indexBits.Margin = new System.Windows.Forms.Padding(10);
            this.indexBits.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.indexBits.Name = "indexBits";
            this.indexBits.Size = new System.Drawing.Size(43, 20);
            this.indexBits.TabIndex = 1;
            // 
            // labelIndexBits
            // 
            this.labelIndexBits.AutoSize = true;
            this.labelIndexBits.Location = new System.Drawing.Point(19, 36);
            this.labelIndexBits.Margin = new System.Windows.Forms.Padding(10);
            this.labelIndexBits.Name = "labelIndexBits";
            this.labelIndexBits.Size = new System.Drawing.Size(53, 13);
            this.labelIndexBits.TabIndex = 2;
            this.labelIndexBits.Text = "Index Bits";
            // 
            // radioButtonFreeze
            // 
            this.radioButtonFreeze.AutoSize = true;
            this.radioButtonFreeze.Location = new System.Drawing.Point(88, 74);
            this.radioButtonFreeze.Margin = new System.Windows.Forms.Padding(10);
            this.radioButtonFreeze.Name = "radioButtonFreeze";
            this.radioButtonFreeze.Size = new System.Drawing.Size(57, 17);
            this.radioButtonFreeze.TabIndex = 3;
            this.radioButtonFreeze.TabStop = true;
            this.radioButtonFreeze.Text = "Freeze";
            this.radioButtonFreeze.UseVisualStyleBackColor = true;
            // 
            // radioButtonEmpty
            // 
            this.radioButtonEmpty.AutoSize = true;
            this.radioButtonEmpty.Location = new System.Drawing.Point(88, 104);
            this.radioButtonEmpty.Margin = new System.Windows.Forms.Padding(10);
            this.radioButtonEmpty.Name = "radioButtonEmpty";
            this.radioButtonEmpty.Size = new System.Drawing.Size(54, 17);
            this.radioButtonEmpty.TabIndex = 4;
            this.radioButtonEmpty.TabStop = true;
            this.radioButtonEmpty.Text = "Empty";
            this.radioButtonEmpty.UseVisualStyleBackColor = true;
            // 
            // listBoxIndexes
            // 
            this.listBoxIndexes.FormattingEnabled = true;
            this.listBoxIndexes.Location = new System.Drawing.Point(158, 67);
            this.listBoxIndexes.Name = "listBoxIndexes";
            this.listBoxIndexes.Size = new System.Drawing.Size(93, 290);
            this.listBoxIndexes.TabIndex = 5;
            // 
            // checkBoxShowIndexes
            // 
            this.checkBoxShowIndexes.AutoSize = true;
            this.checkBoxShowIndexes.Location = new System.Drawing.Point(158, 37);
            this.checkBoxShowIndexes.Name = "checkBoxShowIndexes";
            this.checkBoxShowIndexes.Size = new System.Drawing.Size(93, 17);
            this.checkBoxShowIndexes.TabIndex = 6;
            this.checkBoxShowIndexes.Text = "Show Indexes";
            this.checkBoxShowIndexes.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 367);
            this.Controls.Add(this.checkBoxShowIndexes);
            this.Controls.Add(this.listBoxIndexes);
            this.Controls.Add(this.radioButtonEmpty);
            this.Controls.Add(this.radioButtonFreeze);
            this.Controls.Add(this.labelIndexBits);
            this.Controls.Add(this.indexBits);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.indexBits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem encoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem encodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown indexBits;
        private System.Windows.Forms.Label labelIndexBits;
        private System.Windows.Forms.RadioButton radioButtonFreeze;
        private System.Windows.Forms.RadioButton radioButtonEmpty;
        private System.Windows.Forms.ListBox listBoxIndexes;
        private System.Windows.Forms.CheckBox checkBoxShowIndexes;
    }
}

