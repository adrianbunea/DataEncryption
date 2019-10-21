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
        private const int LEFTMOST_BIT = 128;
        private const int RIGHTMOST_BIT = 1;

        private readonly string filepath;
        private byte[] fileBytes;

        public BitReader(string filepath)
        {
            fileBytes = File.ReadAllBytes(filepath);
        }

        public byte ReadBit()
        {
            byte bit = (byte)(fileBytes[0] & RIGHTMOST_BIT);
            return bit;
        }
    }
}
