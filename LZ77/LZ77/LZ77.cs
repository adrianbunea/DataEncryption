using System;
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
        public int offsetBits;
        public int lengthBits;
        BitWriter writer;

        public List<string> Tokens
        {
            get
            {
                return new List<string>();
            }
        }

        public void Encode(string fileToBeEncoded)
        {
        }

        public void Decode(string fileToBeDecoded)
        {

        }
    }
}
