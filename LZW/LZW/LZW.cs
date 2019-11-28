using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LZW
{
    class LZW
    {
        public List<string> Indexes { get; }
        private List<int> indexes;

        public int Strategy
        {
            set
            {
                strategy = value;
            }
        }
        private int strategy;

        public void Encode(string filepath)
        {

        }

        public void Decode(string filepath)
        {

        }
    }
}
