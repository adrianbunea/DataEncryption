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
        public List<string> Codes 
        {
            get
            {
                List<string> codes = new List<string>();
                foreach (KeyValuePair<byte, string> entry in model.entries)
                {
                    string code = String.Format("{0}: {1}", (char)entry.Key, entry.Value);
                    codes.Add(code);
                }

                return codes;
            }
        }

        private int[] statistic;
        private Model model;

        public void Encode(string fileToBeEncoded)
        {
            statistic = CalculateStatistic(fileToBeEncoded);
            model = CreateModel();
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

        private Model CreateModel()
        {
            return new Model(statistic);
        }

        private void WriteEncodedFile(string fileToBeEncoded)
        {
            BitWriter writer = new BitWriter(fileToBeEncoded + ".hs");
            WriteHeader(writer);

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

        private void WriteHeader(BitWriter writer)
        {
            int[] allocatedBits = new int[256];
            for (int i = 0; i < 256; i++)
            {
                int counter = statistic[i];
                if (counter == 0)
                {
                    writer.WriteNBits(0, 2);
                    allocatedBits[i] = 0;
                }
                else if (counter < Math.Pow(2, 8))
                {
                    writer.WriteNBits(1, 2);
                    allocatedBits[i] = 8;
                }
                else if (counter < Math.Pow(2, 16))
                {
                    writer.WriteNBits(2, 2);
                    allocatedBits[i] = 16;
                }
                else if (counter < Math.Pow(2, 32))
                {
                    writer.WriteNBits(3, 2);
                    allocatedBits[i] = 32;
                }
                else
                {
                    throw new Exception("Counter was too large");
                }
            }

            for (int i = 0; i < 256; i++)
            {
                
                int numberOfBits = allocatedBits[i];
                if (numberOfBits > 0)
                {
                    uint counter = (uint)statistic[i];
                    writer.WriteNBits(counter, numberOfBits);
                }
            }
        }

        public void Decode(string fileToBeDecoded)
        {

        }
    }
}
