﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BitReaderWriter
{
    public class BitWriter
    {
        private readonly BitBuffer buffer;
        private readonly FileStream fs;

        public BitWriter(string filepath)
        {
            fs = File.Create(filepath);
            buffer = new BitBuffer(fs);
        }

        public void WriteBit(byte bit)
        {
            buffer.Push(bit);
        }

        public void WriteNBits(UInt32 value, int bitsToBeWritten)
        {
            GuardClauses.IsNotLesserThan1(bitsToBeWritten);
            GuardClauses.IsNotGreaterThan32(bitsToBeWritten);
            int shiftCount = bitsToBeWritten - 1;
            int MASK = 1 << (bitsToBeWritten - 1);

            while (bitsToBeWritten > 0)
            {
                byte bit = (byte)((value & MASK) >> shiftCount);
                value <<= 1;

                WriteBit(bit);
                bitsToBeWritten--;
            }
        }

        public void Dispose()
        {
            try
            {
                FlushBuffer();
                fs.Close();
            }
            catch (ObjectDisposedException)
            {
                return;
            }
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
