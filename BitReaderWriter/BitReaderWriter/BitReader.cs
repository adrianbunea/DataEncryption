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
        private byte buffer;
        private int currentByte;
        private int bitsRead;

        public BitReader(string filepath)
        {
            fileBytes = File.ReadAllBytes(filepath);
            currentByte = 0;
            bitsRead = 8;
        }

        public byte ReadBit()
        {
            byte bit = (byte)(fileBytes[0] & RIGHTMOST_BIT);
            return bit;
        }

        public Int32 ReadNBits(int bitsToBeRead)
        {
            Int32 bits = 0;

            if (bitsRead == 8)
            {
                bitsRead = 0;
                buffer = fileBytes[currentByte];
                currentByte++;
            }

            while (bitsToBeRead > 0)
            {
                if (bitsRead == 8)
                {
                    bitsRead = 0;
                    buffer = fileBytes[currentByte];
                    currentByte++;
                }

                byte bit = (byte)((buffer & LEFTMOST_BIT) >> 7);
                bits <<= 1;
                bits += bit;
                buffer <<= 1;
                bitsRead++;
                bitsToBeRead--;
            }

            return bits;
        }
    }
}
