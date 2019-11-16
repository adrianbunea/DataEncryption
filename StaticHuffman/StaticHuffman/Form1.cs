using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StaticHuffman
{
    public partial class Form1 : Form
    {
        readonly string root = $"{Environment.CurrentDirectory}";
        string fileToBeEncoded;
        string fileToBeDecoded;
        StaticHuffman huffman;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeEncoded = openFileDialog.FileName;
                }
            }
        }

        private void encodeLoadedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            huffman = new StaticHuffman();
            huffman.Encode(fileToBeEncoded);
            if (checkBoxShowCodes.Checked)
            {
                listBoxCodes.DataSource = huffman.Codes;
            }
        }

        private void loadEncodedFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeDecoded = openFileDialog.FileName;
                }
            }
        }

        private void decodeFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            huffman = new StaticHuffman();
            huffman.Decode(fileToBeDecoded);
            if (checkBoxShowCodes.Checked)
            {
                listBoxCodes.DataSource = huffman.Codes;
            }
        }

        private void buttonEncodeInputText_Click(object sender, EventArgs e)
        {
            string path = root + "\\TextBoxContent.txt";
            File.WriteAllText(path, textBox.Text);

            huffman = new StaticHuffman();
            huffman.Encode(path);
            if (checkBoxShowCodes.Checked)
            {
                listBoxCodes.DataSource = huffman.Codes;
            }
        }
    }
}
