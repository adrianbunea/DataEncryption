using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticHuffman
{
    class Model
    {
        public Dictionary<byte, string> entries;

        public Model(int[] statistic)
        {
            List<List<Symbol>> tree = MakeTree(statistic);
            entries = MakeCodes(tree);
        }

        private List<List<Symbol>>  MakeTree(int[] statistic)
        {
            List<List<Symbol>> tree = new List<List<Symbol>>();
            List<Symbol> list = MakeInitialList(statistic);
            tree.Add(list);

            tree = MakeLayers(tree);

            return tree;
        }

        private List<Symbol> MakeInitialList(int[] statistic)
        {
            List<Symbol> list = new List<Symbol>();
            for (int i = 0; i < 256; i++)
            {
                if (statistic[i] != 0)
                {
                    string value = ((char)i).ToString();
                    int frequency = statistic[i];
                    list.Add(new Symbol(value, frequency));
                }
            }

            list.Sort();
            return list;
        }

        private List<List<Symbol>> MakeLayers(List<List<Symbol>> tree)
        {
            List<Symbol> currentLayer = tree.Last();

            if (currentLayer.Count != 1)
            {
                Symbol firstSymbol = currentLayer[0];
                Symbol secondSymbol = currentLayer[1];

                string value = firstSymbol.value + secondSymbol.value;
                int frequency = firstSymbol.frequency + secondSymbol.frequency;
                Symbol newSymbol = new Symbol(value, frequency);
                newSymbol.leftSymbol = firstSymbol;
                newSymbol.rightSymbol = secondSymbol;

                List<Symbol> newLayer = new List<Symbol>(currentLayer);
                newLayer.RemoveRange(0, 2);
                newLayer.Add(newSymbol);
                newLayer.Sort();
                tree.Add(newLayer);

                tree = MakeLayers(tree);
            }

            return tree;
        }

        private Dictionary<byte, string> MakeCodes(List<List<Symbol>> tree)
        {
            List<string> bytes = new List<string>();
            for (int i = 0; i < tree.First().Count; i++)
            {
                string value = tree.First()[i].value;
                bytes.Add(value);
            }

            Dictionary<byte, string> entries = new Dictionary<byte, string>();

            foreach (string _byte in bytes)
            {
                string codification = "";
                Symbol currentSymbol = tree.Last()[0];

                while (currentSymbol.leftSymbol != null)
                {
                    Symbol left = currentSymbol.leftSymbol;
                    Symbol right = currentSymbol.rightSymbol;

                    if (left.value.Contains(_byte))
                    {
                        codification += "0";
                        currentSymbol = left;
                    } 
                    else
                    {
                        codification += "1";
                        currentSymbol = right;
                    }
                }

                codification = codification == "" ? "0" : codification;
                byte value = (byte)char.Parse(_byte);
                entries.Add(value, codification);
            }
            return entries;
        }
    }
}
