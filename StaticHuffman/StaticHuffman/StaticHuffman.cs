using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticHuffman
{
    class StaticHuffman
    {
        public List<string> Codes { get; set; }
        private Dictionary<byte, uint> codes;

        public void Encode(string fileToBeEncoded)
        {
            int[] statistic = CalculateStatistic(fileToBeEncoded);
            codes = CreateModel(statistic);
            WriteEncodedFile(fileToBeEncoded);
        }

        private int[] CalculateStatistic(string fileToBeEncoded)
        {
            return new int[256];
        }

        private Dictionary<byte, uint> CreateModel(int[] statistic)
        {
            return new Dictionary<byte, uint>();
        }

        private void WriteEncodedFile(string fileToBeEncoded)
        {
            
        }

        public void Decode(string fileToBeDecoded)
        {

        }
    }
}
