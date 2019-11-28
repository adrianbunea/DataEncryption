using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZW
{
    public partial class Form1 : Form
    {
        readonly string root = $"{Environment.CurrentDirectory}";
        string fileToBeEncoded;
        string fileToBeDecoded;
        LZW lzw;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeEncoded = openFileDialog.FileName;
                }
            }
        }

        private void encodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lzw = new LZW();
            if (radioButtonEmpty.Checked)
            {
                lzw.Strategy = 0;
            } 
            else if (radioButtonFreeze.Checked)
            {
                lzw.Strategy = 1;
            }
            else
            {
                throw new Exception("Unknown strategy. Can be either Freeze or Empty.");
            }

            lzw.Encode(fileToBeEncoded);
            if (checkBoxShowIndexes.Checked)
            {
                listBoxIndexes.DataSource = lzw.Indexes;
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeDecoded = openFileDialog.FileName;
                }
            }
        }

        private void decodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lzw = new LZW();
            lzw.Decode(fileToBeDecoded);
            if (checkBoxShowIndexes.Checked)
            {
                listBoxIndexes.DataSource = lzw.Indexes;
            }
        }
    }
}
