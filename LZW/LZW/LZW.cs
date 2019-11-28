using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitReaderWriter;

namespace LZW
{
    class LZW
    {
        string fileToBeEncoded;
        BitReader reader;
        BitWriter writer;

        public int indexBits;
        public List<string> Indexes { get; }
        private List<int> indexes;

        public int Strategy
        {
            set
            {
                strategy = value;
            }
        }
        private int strategy;

        List<string> dictionary;

        public LZW()
        {
            dictionary = new List<string>();
        }

        public void Encode(string filepath)
        {
            fileToBeEncoded = filepath;
            writer = new BitWriter(fileToBeEncoded + ".lzw");
            InitializeDictionary();
            FillDictionary();
            writer.Dispose();
        }

        public void Decode(string filepath)
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            for (int i = 0; i < 255; i++)
            {
                dictionary.Add(((char)i).ToString());
            }
        }

        private void FillDictionary()
        {
            string symbol;
            char currentCharacter;
            symbol = "";
            int value;

            using (FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open))
            {
                while ((value = fs.ReadByte()) != -1)
                {
                    currentCharacter = (char)value;

                    if (dictionary.Contains(symbol + currentCharacter))
                    {
                        symbol += currentCharacter;
                    }
                    else
                    {
                        writer.WriteNBits((uint)dictionary.IndexOf(currentCharacter.ToString()), indexBits);
                        dictionary.Add(symbol + currentCharacter);
                        symbol = currentCharacter.ToString();
                    }
                }

                writer.WriteNBits((uint)dictionary.IndexOf(((char)value).ToString()), indexBits);
            }
        }
    }
}
