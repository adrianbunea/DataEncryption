namespace LZ77
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
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decoderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.offsetBits = new System.Windows.Forms.NumericUpDown();
            this.lengthBits = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxShowTokens = new System.Windows.Forms.CheckBox();
            this.listBoxTokens = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetBits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBits)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encoderToolStripMenuItem,
            this.decoderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(404, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // encoderToolStripMenuItem
            // 
            this.encoderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.decodeToolStripMenuItem});
            this.encoderToolStripMenuItem.Name = "encoderToolStripMenuItem";
            this.encoderToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.encoderToolStripMenuItem.Text = "Encoder";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // decodeToolStripMenuItem
            // 
            this.decodeToolStripMenuItem.Name = "decodeToolStripMenuItem";
            this.decodeToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.decodeToolStripMenuItem.Text = "Encode";
            this.decodeToolStripMenuItem.Click += new System.EventHandler(this.encodeToolStripMenuItem_Click);
            // 
            // decoderToolStripMenuItem
            // 
            this.decoderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.decodeToolStripMenuItem1});
            this.decoderToolStripMenuItem.Name = "decoderToolStripMenuItem";
            this.decoderToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.decoderToolStripMenuItem.Text = "Decoder";
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem1.Text = "Load";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // decodeToolStripMenuItem1
            // 
            this.decodeToolStripMenuItem1.Name = "decodeToolStripMenuItem1";
            this.decodeToolStripMenuItem1.Size = new System.Drawing.Size(114, 22);
            this.decodeToolStripMenuItem1.Text = "Decode";
            this.decodeToolStripMenuItem1.Click += new System.EventHandler(this.decodeToolStripMenuItem1_Click);
            // 
            // offsetBits
            // 
            this.offsetBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.offsetBits.Location = new System.Drawing.Point(106, 34);
            this.offsetBits.Margin = new System.Windows.Forms.Padding(10);
            this.offsetBits.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.offsetBits.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.offsetBits.Name = "offsetBits";
            this.offsetBits.Size = new System.Drawing.Size(57, 26);
            this.offsetBits.TabIndex = 2;
            this.offsetBits.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // lengthBits
            // 
            this.lengthBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lengthBits.Location = new System.Drawing.Point(106, 80);
            this.lengthBits.Margin = new System.Windows.Forms.Padding(10);
            this.lengthBits.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.lengthBits.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.lengthBits.Name = "lengthBits";
            this.lengthBits.Size = new System.Drawing.Size(57, 26);
            this.lengthBits.TabIndex = 3;
            this.lengthBits.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(14, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Offset Bits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(8, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Length Bits";
            // 
            // checkBoxShowTokens
            // 
            this.checkBoxShowTokens.AutoSize = true;
            this.checkBoxShowTokens.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxShowTokens.Location = new System.Drawing.Point(29, 126);
            this.checkBoxShowTokens.Margin = new System.Windows.Forms.Padding(10);
            this.checkBoxShowTokens.Name = "checkBoxShowTokens";
            this.checkBoxShowTokens.Size = new System.Drawing.Size(124, 24);
            this.checkBoxShowTokens.TabIndex = 7;
            this.checkBoxShowTokens.Text = "Show Tokens";
            this.checkBoxShowTokens.UseVisualStyleBackColor = true;
            // 
            // listBoxTokens
            // 
            this.listBoxTokens.FormattingEnabled = true;
            this.listBoxTokens.Location = new System.Drawing.Point(183, 34);
            this.listBoxTokens.Margin = new System.Windows.Forms.Padding(10);
            this.listBoxTokens.Name = "listBoxTokens";
            this.listBoxTokens.Size = new System.Drawing.Size(202, 368);
            this.listBoxTokens.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 417);
            this.Controls.Add(this.listBoxTokens);
            this.Controls.Add(this.checkBoxShowTokens);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.lengthBits);
            this.Controls.Add(this.offsetBits);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetBits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem encoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem decodeToolStripMenuItem1;
        private System.Windows.Forms.NumericUpDown offsetBits;
        private System.Windows.Forms.NumericUpDown lengthBits;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxShowTokens;
        private System.Windows.Forms.ListBox listBoxTokens;
    }
}

