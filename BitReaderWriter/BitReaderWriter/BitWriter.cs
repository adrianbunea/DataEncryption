using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BitReaderWriter
{
    public class BitWriter
    {
        private const int RIGHTMOST_BIT_MASK = 1;
        private readonly BitBuffer buffer;
        private FileStream fs;

        public BitWriter(string filepath)
        {
            fs = File.Create(filepath);
            buffer = new BitBuffer(fs);
        }

        public void WriteBit(byte bit)
        {
            buffer.Push(bit);
        }

        public void WriteNBit(int value, int bitsToBeWritten)
        {
            GuardClauses.IsNotLesserThan1(bitsToBeWritten);
            GuardClauses.IsNotGreaterThan32(bitsToBeWritten);

            while (bitsToBeWritten > 0)
            {
                byte bit = (byte)(value & RIGHTMOST_BIT_MASK);
                value >>= 1;

                WriteBit(bit);
                bitsToBeWritten--;
            }
        }

        public void Dispose()
        {
            FlushBuffer();
            fs.Close();
        }

        private void FlushBuffer()
        {
            for (int i = 0; i < 7; i++)
            {
                WriteBit(1);
            }
        }
    }
}
