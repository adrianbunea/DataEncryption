using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LZ77
{
    public partial class Form1 : Form
    {
        readonly string root = $"{Environment.CurrentDirectory}";
        string fileToBeEncoded;
        string fileToBeDecoded;
        LZ77 lz77;

        public Form1()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
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
            lz77 = new LZ77();
            lz77.offsetBits = (int)offsetBits.Value;
            lz77.lengthBits = (int)lengthBits.Value;
            lz77.Encode(fileToBeEncoded);
            if (checkBoxShowTokens.Checked)
            {
                listBoxTokens.DataSource = lz77.Tokens;
            }
        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileToBeDecoded = openFileDialog.FileName;
                }
            }
        }

        private void decodeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lz77 = new LZ77();
            lz77.Decode(fileToBeDecoded);
            if (checkBoxShowTokens.Checked)
            {
                listBoxTokens.DataSource = lz77.Tokens;
            }
        }
    }
}
