using System;
using System.IO;
using BitReaderWriter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitReaderTests
    {
        BitReader bitReader;
        string filepath = $"{Environment.CurrentDirectory}\\ReaderTestFile.txt";

        [TestCleanup]
        public void Teardown()
        {
            File.Delete(filepath);
        }

        [TestMethod]
        [DataRow((byte)61, (byte)1)]
        [DataRow((byte)62, (byte)0)]
        [DataRow((byte)63, (byte)1)]
        [DataRow((byte)64, (byte)0)]
        public void ReadBit_ValidFile_ReadsBitCorrectly(byte testByte, byte expectedBit)
        {
            byte[] testBytes = new byte[1] { testByte };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            byte readBit = bitReader.ReadBit();

            Assert.AreEqual(expectedBit, readBit);
        }
        
        [TestMethod]
        public void ReadNBit_ValidFile_ReadsNBitsCorrectly()
        {

        }
    }
}
