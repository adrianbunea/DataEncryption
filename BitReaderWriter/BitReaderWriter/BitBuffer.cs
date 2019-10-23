using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter
{
    public class BitBuffer
    {
        private const int LEFTMOST_BIT = 128;

        private int currentByte;
        private int bitsCount;
        private byte[] bytes;
        private byte bits;

        public BitBuffer(byte[] bytes)
        {
            this.bytes = bytes;
            currentByte = 0;
            bitsCount = 0;
        }

        private void Read()
        {
            bits = bytes[currentByte];
            currentByte++;
            bitsCount = 8;
        }

        public byte Pop()
        {
            if (bitsCount == 0)
            {
                Read();
            }

            byte bit = (byte)((bits & LEFTMOST_BIT) >> 7);
            bits <<= 1;
            bitsCount--;

            return bit;
        }
    }
}
