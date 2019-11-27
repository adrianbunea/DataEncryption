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
                return new List<string>();
            }
        }

        public LZ77()
        {
            
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

            writer = new BitWriter(fileToBeEncoded + ".lz77");
            WriteHeader();
            WriteTokens();
            writer.Dispose();
        }

        public void Decode(string fileToBeDecoded)
        {
            reader = new BitReader(fileToBeDecoded);
            ReadHeader();
            ReadTokens();
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

        }

        private void ReadTokens()
        {

        }
    }
}
