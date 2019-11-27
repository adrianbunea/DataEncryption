using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77
{
    class SearchBuffer
    {
        private Buffer buffer;
        public int length;
        public int Length
        {
            set
            {
                this.length = value;
                buffer.lengthSB = length;
            }
        }

        public SearchBuffer(Buffer buffer)
        {
            this.buffer = buffer;
        }

        public byte this[int index]
        {
            get
            {
                return buffer[buffer.startIndexLAB - index -1];
            }
            set
            {
                buffer[buffer.startIndexLAB - index - 1] = value;
            }
        }

        public int IndexOf(List<byte> values)
        {
            List<byte> SB = new List<byte>();

            if (buffer.startIndexLAB == 0) return -1;
            
            for (int i = buffer.startIndexLAB - 1; i >= 0; i--)
            {
                SB.Add(this[i]);
            }

            string stringifiedSB = ToString(SB);
            string stringifiedValues = ToString(values);

            int index = stringifiedSB.LastIndexOf(stringifiedValues);
            if (index >= 0)
            {
                index = buffer.startIndexLAB - index - 1;
            }
            return index;
        }

        private string ToString(List<byte> values)
        {
            string result = "";
            foreach(byte value in values)
            {
                result += ((char)value).ToString();
            }
            return result;
        }
    }
}
