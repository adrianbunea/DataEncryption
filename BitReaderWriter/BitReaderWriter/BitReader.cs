using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter
{
    public class BitReader
    {
        private readonly BitBuffer buffer;

        public BitReader(string filepath)
        {
            buffer = new BitBuffer(File.ReadAllBytes(filepath));
        }

        public byte ReadBit()
        {
            return buffer.Pop();
        }

        public Int32 ReadNBits(int bitsToBeRead)
        {
            Int32 bits = 0;

            while (bitsToBeRead > 0)
            {
                byte bit = ReadBit();
                bits <<= 1;
                bits += bit;
                bitsToBeRead--;
            }

            return bits;
        }
    }
}
