using System;
using System.Collections.Generic;
using System.IO;
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

        private FileStream fs;
        private int bitsCount;
        private byte bits;

        public BitBuffer(FileStream fs)
        {
            this.fs = fs;
            bitsCount = 0;
        }

        public void Dispose()
        {
            fs.Close();
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
            bits = (byte)fs.ReadByte();
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
