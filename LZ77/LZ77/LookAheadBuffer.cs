using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZ77
{
    class LookAheadBuffer
    {
        private Buffer buffer;
        public int length;
        public int Length 
        { 
            set
            {
                length = value;
                buffer.lengthLAB = length;
            }
        }

        public LookAheadBuffer(Buffer buffer)
        {
            this.buffer = buffer;
        }

        public byte this[int index]
        {
            get
            {
                return buffer[index + buffer.startIndexLAB];
            }
            set
            {
                buffer[index + buffer.startIndexLAB] = value;
            }
        }

        public bool Empty()
        {
            if (buffer.bytes.Count <= buffer.startIndexLAB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
