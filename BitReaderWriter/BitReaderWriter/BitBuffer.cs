using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitReaderWriter
{
    public class BitBuffer
    {
        private const int LEFTMOST_BIT_MASK = 128;
        private byte LeftmostBit
        {
            get
            {
                return (byte)((bits & LEFTMOST_BIT_MASK) >> 7);
            }
        }

        private int currentByte;
        private int bitsCount;
        private readonly byte[] bytes;
        private byte bits;

        public BitBuffer(byte[] bytes)
        {
            this.bytes = bytes;
            currentByte = 0;
            bitsCount = 0;
        }

        public byte Pop()
        {
            if (EmptyBuffer())
            {
                ReadByte();
            }

            byte bit = LeftmostBit;
            RemoveLeftmostBit();

            return bit;
        }

        private void ReadByte()
        {
            bits = bytes[currentByte];
            currentByte++;
            bitsCount = 8;
        }

        private void RemoveLeftmostBit()
        {
            bits <<= 1;
            bitsCount--;
        }

        private bool EmptyBuffer()
        {
            return bitsCount == 0;
        }
    }
}
