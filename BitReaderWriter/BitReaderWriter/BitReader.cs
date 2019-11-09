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
        private readonly FileStream fs;

        public BitReader(string filepath)
        {
            fs = File.OpenRead(filepath);
            buffer = new BitBuffer(fs);
        }

        public void Dispose()
        {
            try
            {
                fs.Close();
            }
            catch (ObjectDisposedException)
            {
                return;
            }
        }

        public byte ReadBit()
        {
            return buffer.Pop();
        }

        public UInt32 ReadNBits(int bitsToBeRead)
        {
            GuardClauses.IsNotLesserThan1(bitsToBeRead);
            GuardClauses.IsNotGreaterThan32(bitsToBeRead);

            UInt32 bits = 0;
            byte bit;

            while (bitsToBeRead > 0)
            {
                try
                {
                    bit = ReadBit();
                }
                catch (ArgumentOutOfRangeException)
                {
                    return bits;
                }

                bits <<= 1;
                bits += bit;
                bitsToBeRead--;
            }

            return bits;
        }
    }
}
