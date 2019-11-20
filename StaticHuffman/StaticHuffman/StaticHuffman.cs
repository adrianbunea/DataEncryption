using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitReaderWriter;

namespace StaticHuffman
{
    class StaticHuffman
    {
        public List<string> Codes { get; set; }
        private Model model;

        public void Encode(string fileToBeEncoded)
        {
            int[] statistic = CalculateStatistic(fileToBeEncoded);
            model = CreateModel(statistic);
            WriteEncodedFile(fileToBeEncoded);
        }

        private int[] CalculateStatistic(string fileToBeEncoded)
        {
            int[] statistic = new int[256];

            using (FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open))
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    statistic[fs.ReadByte()]++;
                }
            }

            return statistic;
        }

        private Model CreateModel(int[] statistic)
        {
            return new Model(statistic);
        }

        private void WriteEncodedFile(string fileToBeEncoded)
        {
            BitWriter writer = new BitWriter(fileToBeEncoded + ".hs");

            using (FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open))
            {
                for (int i = 0; i < fs.Length; i++)
                {
                    byte readByte = (byte)fs.ReadByte();
                    string codification = model.entries[readByte];
                    writer.WriteNBits(Convert.ToUInt32(codification, 2), codification.Length);
                }
            }

            writer.Dispose();

        }

        public void Decode(string fileToBeDecoded)
        {

        }
    }
}
