using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticHuffman
{
    class Symbol : IComparable <Symbol>
    {
        public string value;
        public int frequency;
        public Symbol leftSymbol;
        public Symbol rightSymbol;

        public Symbol(string value, int frequency)
        {
            this.value = value;
            this.frequency = frequency;
        }

        public int CompareTo(Symbol anotherSymbol)
        {
            return frequency.CompareTo(anotherSymbol.frequency);
        }
    }
}
