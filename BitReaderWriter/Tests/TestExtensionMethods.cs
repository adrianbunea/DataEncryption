using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BitReaderWriter;

namespace Tests
{
    public static class TestExtensionMethods
    {
        public static void Flush(this BitBuffer buffer)
        {
            for (int i = 0; i < 7; i++)
            {
                buffer.Push(1);
            }
        }
    }
}
