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
        private byte LeftmostBit
        {
            get
            {
                return (byte)((bits & Masks.LEFTMOST_BIT_MASK) >> 7);
            }
        }

        private readonly FileStream fs;
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

        public void Push(byte bit)
        {
            AppendLeftmostBit(bit);

            if (FullBuffer())
            {
                WriteByte();
            }
        }

        private void ReadByte()
        {
            if (fs.Position == fs.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            bits = (byte)fs.ReadByte();
            bitsCount = 8;
        }

        private void WriteByte()
        {
            fs.WriteByte(bits);
            bitsCount = 0;
        }

        private void RemoveLeftmostBit()
        {
            bits <<= 1;
            bitsCount--;
        }

        private void AppendLeftmostBit(byte bit)
        {
            bits >>= 1;
            bits += (byte)(bit << 7);
            bitsCount++;
        }

        private bool EmptyBuffer()
        {
            return bitsCount == 0;
        }

        private bool FullBuffer()
        {
            return bitsCount == 8;
        }
    }
}
