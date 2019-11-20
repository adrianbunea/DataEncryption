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
        BitReader reader;
        int readBits;
        BitWriter writer;

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

        public void Decode(string fileToBeDecoded)
        {
            ReadStatistic(fileToBeDecoded);
            model = CreateModel();
            WriteDecodedFile(fileToBeDecoded);
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

        private void ReadStatistic(string fileToBeDecoded)
        {
            statistic = new int[256];

            reader = new BitReader(fileToBeDecoded);
            int[] allocatedBits = new int[256];

            for (int i = 0; i < 256; i++)
            {
                uint mode = reader.ReadNBits(2);
                if (mode == 0)
                {
                    allocatedBits[i] = 0;
                }
                else if (mode == 1)
                {
                    allocatedBits[i] = 8;
                }
                else if (mode == 2)
                {
                    allocatedBits[i] = 16;
                }
                else if (mode == 3)
                {
                    allocatedBits[i] = 32;
                }
                else
                {
                    throw new Exception("Bit allocation too large!");
                }
            }

            readBits = 512;

            for (int i = 0; i < 256; i++)
            {
                int numberOfBits = allocatedBits[i];
                if (numberOfBits > 0)
                {
                    statistic[i] = (int)reader.ReadNBits(numberOfBits);
                    readBits += numberOfBits;
                }
            }
        }

        private Model CreateModel()
        {
            return new Model(statistic);
        }

        private void WriteEncodedFile(string fileToBeEncoded)
        {
            writer = new BitWriter(fileToBeEncoded + ".hs");
            WriteHeader();

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

        private void WriteDecodedFile(string fileToBeDecoded)
        {
            Dictionary<string, byte> invertedModelEntries = new Dictionary<string, byte>();
            foreach (KeyValuePair<byte, string> entry in model.entries)
            {
                invertedModelEntries.Add(entry.Value, entry.Key);
            }

            FileInfo info = new FileInfo(fileToBeDecoded);
            string extension = fileToBeDecoded.Substring(fileToBeDecoded.Length - 7).Replace(".hs", "");
            writer = new BitWriter(fileToBeDecoded + DateTime.Now.ToString("dd-MM-yyyy-HH-mm") + extension);


            string readCode = "";
            for (int i = readBits; i < info.Length*8; i++)
            {
                readCode += reader.ReadBit();
                if (invertedModelEntries.ContainsKey(readCode))
                {
                    writer.WriteNBits((uint)invertedModelEntries[readCode], 8);
                    readCode = "";
                }
            }

            writer.Dispose();
        }

        private void WriteHeader()
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
    }
}
