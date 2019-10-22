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
        [DataRow((byte)61, 8, (Int32)61)]
        [DataRow((byte)61, 7, (Int32)30)]
        [DataRow((byte)61, 6, (Int32)15)]
        [DataRow((byte)61, 4, (Int32) 3)]
        [DataRow((byte)61, 1, (Int32) 0)]
        public void ReadNBit_ValidFile_ReadsNBitsCorrectly(byte testByte, int numberOfBits, Int32 expectedBits)
        {
            byte[] testBytes = new byte[1] { testByte };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            Int32 readBits = bitReader.ReadNBits(numberOfBits);

            Assert.AreEqual(expectedBits, readBits);
        }
    }
}
