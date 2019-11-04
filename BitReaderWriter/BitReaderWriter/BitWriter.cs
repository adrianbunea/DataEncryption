using System;
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
        private FileStream fs;

        public BitWriter(string filepath)
        {
            fs = File.Create(filepath);
            buffer = new BitBuffer(fs);
        }

        public void WriteBit(byte bit)
        {
            buffer.Push(bit);
        }

        public void Dispose()
        {
            fs.Close();
        }
    }
}
