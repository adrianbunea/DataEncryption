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
        int currentBit;
        string fileToBeEncoded;
        string fileToBeDecoded;
        BitReader reader;
        BitWriter writer;

        public int indexBits;
        public List<string> Indexes { get; }

        public int Strategy
        {
            set
            {
                strategy = value;
            }
        }
        private int strategy;

        Dictionary<int, string> dictionary;

        public LZW()
        {
            dictionary = new Dictionary<int, string>();
        }

        public void Encode(string fileToBeEncoded)
        {
            this.fileToBeEncoded = fileToBeEncoded;
            writer = new BitWriter(fileToBeEncoded + ".lzw");
            InitializeDictionary();
            WriteHeader();
            WriteEncodedFile();
            writer.Dispose();
        }

        public void Decode(string fileToBeDecoded)
        {
            this.fileToBeDecoded = fileToBeDecoded;
            reader = new BitReader(fileToBeDecoded);
            writer = new BitWriter(fileToBeDecoded + ".decoded.txt");
            InitializeDictionary();
            ReadHeader();
            WriteDecodedFile();
            writer.Dispose();
        }

        private void InitializeDictionary()
        {
            for (int i = 0; i < 255; i++)
            {
                dictionary.Add(i, ((char)i).ToString());
            }
        }

        private void WriteHeader()
        {
            writer.WriteNBits((uint)indexBits, 4);
            writer.WriteNBits((uint)strategy, 1);
        }

        private void WriteEncodedFile()
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

                    if (dictionary.ContainsValue(symbol + currentCharacter))
                    {
                        symbol += currentCharacter;
                    }
                    else
                    {
                        writer.WriteNBits((uint)dictionary.KeyByValue(currentCharacter.ToString()), indexBits);
                        dictionary.Add(dictionary.Count, symbol + currentCharacter);
                        symbol = currentCharacter.ToString();
                    }
                }

                writer.WriteNBits((uint)dictionary.KeyByValue(((char)value).ToString()), indexBits);
            }
        }

        private void ReadHeader()
        {
            indexBits = (int)reader.ReadNBits(4);
            strategy = (int)reader.ReadNBits(1);
        }

        private void WriteDecodedFile()
        {
            string symbol;
            string temp = "";
            int index;
            currentBit = 5;

            while (CanReadFromFile())
            {
                index = (int)reader.ReadNBits(indexBits);
                currentBit += indexBits;
                if (dictionary.ContainsKey(index))
                {
                    symbol = dictionary[index];
                    foreach (string character in symbol.Split())
                    {
                        writer.WriteNBits(char.Parse(character), 8);
                    }
                    dictionary.Add(dictionary.Count, temp + symbol[0]);
                }
                else
                {
                    if (index > dictionary.Count)
                    {
                        break;
                    }

                    symbol = temp + temp[0];
                    foreach (string character in symbol.Split())
                    {
                        writer.WriteNBits(char.Parse(character), 8);
                    }

                    dictionary.Add(dictionary.Count, symbol);
                }

                temp = symbol;
            }
        }

        private bool CanReadFromFile()
        {
            FileInfo info = new FileInfo(fileToBeDecoded);
            return currentBit < info.Length * 8 ? true : false;
        }
    }
}
