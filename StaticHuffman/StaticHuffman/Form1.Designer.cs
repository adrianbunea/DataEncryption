namespace StaticHuffman
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
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodeLoadedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decoderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadEncodedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decodeFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonEncodeInputText = new System.Windows.Forms.Button();
            this.checkBoxShowCodes = new System.Windows.Forms.CheckBox();
            this.listBoxCodes = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.encoderToolStripMenuItem,
            this.decoderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(601, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip";
            // 
            // encoderToolStripMenuItem
            // 
            this.encoderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.encodeLoadedFileToolStripMenuItem});
            this.encoderToolStripMenuItem.Name = "encoderToolStripMenuItem";
            this.encoderToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.encoderToolStripMenuItem.Text = "Encoder";
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.loadFileToolStripMenuItem.Text = "Load File";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.loadFileToolStripMenuItem_Click);
            // 
            // encodeLoadedFileToolStripMenuItem
            // 
            this.encodeLoadedFileToolStripMenuItem.Name = "encodeLoadedFileToolStripMenuItem";
            this.encodeLoadedFileToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.encodeLoadedFileToolStripMenuItem.Text = "Encode Loaded File";
            this.encodeLoadedFileToolStripMenuItem.Click += new System.EventHandler(this.encodeLoadedFileToolStripMenuItem_Click);
            // 
            // decoderToolStripMenuItem
            // 
            this.decoderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadEncodedFileToolStripMenuItem,
            this.decodeFileToolStripMenuItem});
            this.decoderToolStripMenuItem.Name = "decoderToolStripMenuItem";
            this.decoderToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.decoderToolStripMenuItem.Text = "Decoder";
            // 
            // loadEncodedFileToolStripMenuItem
            // 
            this.loadEncodedFileToolStripMenuItem.Name = "loadEncodedFileToolStripMenuItem";
            this.loadEncodedFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadEncodedFileToolStripMenuItem.Text = "Load Encoded File";
            this.loadEncodedFileToolStripMenuItem.Click += new System.EventHandler(this.loadEncodedFileToolStripMenuItem_Click);
            // 
            // decodeFileToolStripMenuItem
            // 
            this.decodeFileToolStripMenuItem.Name = "decodeFileToolStripMenuItem";
            this.decodeFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.decodeFileToolStripMenuItem.Text = "Decode Loaded File";
            this.decodeFileToolStripMenuItem.Click += new System.EventHandler(this.decodeFileToolStripMenuItem_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(26, 46);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(390, 418);
            this.textBox.TabIndex = 1;
            // 
            // buttonEncodeInputText
            // 
            this.buttonEncodeInputText.Location = new System.Drawing.Point(433, 46);
            this.buttonEncodeInputText.Name = "buttonEncodeInputText";
            this.buttonEncodeInputText.Size = new System.Drawing.Size(146, 44);
            this.buttonEncodeInputText.TabIndex = 2;
            this.buttonEncodeInputText.Text = "Encode Input Text";
            this.buttonEncodeInputText.UseVisualStyleBackColor = true;
            this.buttonEncodeInputText.Click += new System.EventHandler(this.buttonEncodeInputText_Click);
            // 
            // checkBoxShowCodes
            // 
            this.checkBoxShowCodes.AutoSize = true;
            this.checkBoxShowCodes.Location = new System.Drawing.Point(462, 96);
            this.checkBoxShowCodes.Name = "checkBoxShowCodes";
            this.checkBoxShowCodes.Size = new System.Drawing.Size(86, 17);
            this.checkBoxShowCodes.TabIndex = 3;
            this.checkBoxShowCodes.Text = "Show Codes";
            this.checkBoxShowCodes.UseVisualStyleBackColor = true;
            // 
            // listBoxCodes
            // 
            this.listBoxCodes.FormattingEnabled = true;
            this.listBoxCodes.Location = new System.Drawing.Point(433, 122);
            this.listBoxCodes.Name = "listBoxCodes";
            this.listBoxCodes.Size = new System.Drawing.Size(146, 342);
            this.listBoxCodes.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 488);
            this.Controls.Add(this.listBoxCodes);
            this.Controls.Add(this.checkBoxShowCodes);
            this.Controls.Add(this.buttonEncodeInputText);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem encoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem encodeLoadedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decoderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadEncodedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decodeFileToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Button buttonEncodeInputText;
        private System.Windows.Forms.CheckBox checkBoxShowCodes;
        private System.Windows.Forms.ListBox listBoxCodes;
    }
}

