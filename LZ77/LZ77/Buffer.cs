using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77
{
    class Buffer
    {
        FileStream fs;
        public List<byte> bytes;
        public int startIndexLAB;
        public int lengthSB;
        public int lengthLAB;

        public Buffer(FileStream fs)
        {
            this.fs = fs;
            bytes = new List<byte>();
            startIndexLAB = 0;
        }

        public byte this[int index]
        {
            get
            {
                return bytes[index];
            }
            set
            {
                bytes[index] = value;
            }
        }

        public void SlideWindow(int positions)
        {
            for (int i = 0; i < positions; i++)
            {
                int value = fs.ReadByte();

                if (startIndexLAB >= lengthSB)
                {
                    bytes.RemoveAt(0);
                }
                else
                {
                    startIndexLAB++;
                }

                if (value != -1)
                {
                    bytes.Add((byte)value);
                }
            }
        }

        public void FillLAB()
        {
            for (int i = 0; i < lengthLAB; i++)
            {
                int value = fs.ReadByte();

                if (value != -1)
                {
                    bytes.Add((byte)value);
                }
            }
        }
    }
}
