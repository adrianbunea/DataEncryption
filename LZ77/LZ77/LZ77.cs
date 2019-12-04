using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitReaderWriter;

namespace LZ77
{
    class LZ77
    {
        BitReader reader;
        BitWriter writer;
        public uint offsetBits;
        public uint lengthBits;

        private Buffer buffer;
        private SearchBuffer SB;
        private LookAheadBuffer LAB;

        private List<Token> tokens;

        public List<string> Tokens
        {
            get
            {
                List<string> tokens = new List<string>();
                foreach (Token token in this.tokens)
                {
                    tokens.Add(String.Format("{0}, {1}, {2}", token.offset.ToString(), token.length.ToString(), ((char)token.value).ToString()));
                }
                return tokens;
            }
        }

        public void Encode(string fileToBeEncoded)
        {
            FileStream fs = new FileStream(fileToBeEncoded, FileMode.Open);
            buffer = new Buffer(fs);
            SB = new SearchBuffer(buffer);
            SB.Length = (int)Math.Pow(2, offsetBits) - 1;
            LAB = new LookAheadBuffer(buffer);
            LAB.Length = (int)Math.Pow(2, lengthBits) - 1;

            CreateTokens();
            fs.Dispose();
            writer = new BitWriter(string.Format("{0}.o{1}i{1}.lz77", fileToBeEncoded, offsetBits, lengthBits));
            WriteHeader();
            WriteTokens();
            writer.Dispose();
        }

        public void Decode(string fileToBeDecoded)
        {
            reader = new BitReader(fileToBeDecoded);

            writer = new BitWriter(fileToBeDecoded + ".decoded");
            ReadHeader();
            ReadTokens(fileToBeDecoded);
            WriteDecodedFile();
        }

        private void CreateTokens()
        {
            tokens = new List<Token>();
            buffer.FillLAB(); 

            while (!LAB.Empty())
            {
                Token token = SearchLongestMatch();
                tokens.Add(token);
                buffer.SlideWindow(token.length + 1);
            }
        }

        private Token SearchLongestMatch()
        {
            byte value = LAB[0];
            List<byte> values = new List<byte>() { value };
            int offset = 0;
            int i = 1;

            while (SB.IndexOf(values) >= 0)
            {
                offset = SB.IndexOf(values);
                //buffer.startIndexLAB++;
                try
                {
                    value = LAB[i++];
                }
                catch (ArgumentOutOfRangeException)
                {
                    break;
                }
                
                
                values.Add(value);
            }

            Token token = new Token();
            token.offset = offset;
            token.length = values.Count - 1;
            token.value = values.Last();
            return token;
        }

        private void WriteHeader()
        {
            writer.WriteNBits(offsetBits, 4);
            writer.WriteNBits(lengthBits, 3);
        }

        private void WriteTokens()
        {
            foreach (Token token in tokens)
            {
                writer.WriteNBits((uint)token.offset, (int)offsetBits);
                writer.WriteNBits((uint)token.length, (int)lengthBits);
                writer.WriteNBits(token.value, 8);
            }
        }

        private void ReadHeader()
        {
            offsetBits = reader.ReadNBits(4);
            lengthBits = reader.ReadNBits(3);
        }

        private void ReadTokens(string fileToBeDecoded)
        {
            tokens = new List<Token>();
            FileInfo info = new FileInfo(fileToBeDecoded);
            long totalNumberOfBits = info.Length*8;
            long readBits = 7;
            while (readBits < totalNumberOfBits)
            {
                Token token = new Token();
                token.offset = (int)reader.ReadNBits((int)offsetBits);
                token.length = (int)reader.ReadNBits((int)lengthBits);
                token.value = (byte)reader.ReadNBits(8);
                tokens.Add(token);
                readBits += offsetBits + lengthBits + 8;
            }
        }

        private void WriteDecodedFile()
        {
            List<byte> previousBytes = new List<byte>();
            int maxSize = (int)Math.Pow(2, 16) - 1;

            foreach (Token token in tokens)
            {
                if (token.offset == 0)
                {
                    writer.WriteNBits(token.value, 8);
                    previousBytes.Add(token.value);
                }
                else
                {
                    int startIndex = previousBytes.Count - 1 - token.offset;
                    startIndex = startIndex < 0 ? 0 : startIndex;

                    for (int i = startIndex; i < startIndex + token.length; i++)
                    {
                        writer.WriteNBits(previousBytes[i], 8);
                        previousBytes.Add(previousBytes[i]);
                    }

                    writer.WriteNBits(token.value, 8);
                    previousBytes.Add(token.value);
                }

                while (previousBytes.Count > maxSize)
                {
                    previousBytes.RemoveAt(0);
                }
            }

            writer.Dispose();
        }
    }
}
