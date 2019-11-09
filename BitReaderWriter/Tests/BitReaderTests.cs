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
        readonly string filepath = $"{Environment.CurrentDirectory}\\ReaderTestFile.txt";

        [TestCleanup]
        public void Teardown()
        {
            bitReader.Dispose();
            File.Delete(filepath);
        }

        [TestMethod]
        [DataRow((byte)61, (byte)0)]
        [DataRow((byte)62, (byte)0)]
        [DataRow((byte)128, (byte)1)]
        [DataRow((byte)129, (byte)1)]
        public void ReadBit_ValidFile_ReadsBitCorrectly(byte testByte, byte expectedBit)
        {
            byte[] testBytes = new byte[1] { testByte };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            byte readBit = bitReader.ReadBit();

            Assert.AreEqual(expectedBit, readBit);
        }
        
        [TestMethod]
        [DataRow((byte)61, 8, (UInt32)61)]
        [DataRow((byte)61, 7, (UInt32)30)]
        [DataRow((byte)61, 6, (UInt32)15)]
        [DataRow((byte)61, 4, (UInt32) 3)]
        [DataRow((byte)61, 1, (UInt32) 0)]
        public void ReadNBit_ValidFiles_ReadsLessThan9BitsCorrectly(byte testByte, int numberOfBits, UInt32 expectedBits)
        {
            byte[] testBytes = new byte[1] { testByte };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            UInt32 readBits = bitReader.ReadNBits(numberOfBits);

            Assert.AreEqual(expectedBits, readBits);
        }

        [TestMethod]
        public void ReadNBit_ValidFile_ReadsMoreThan8BitsCorrectly()
        {
            byte[] testBytes = new byte[4] { 255, 255, 255, 255 };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            UInt32 readBits = bitReader.ReadNBits(32);

            Assert.AreEqual(4294967295, readBits);
        }

        [TestMethod]
        public void ReadNBit_ValidFile_ReadsMoreBitsThanAvailableCorrectly()
        {
            byte[] testBytes = new byte[2] { 255, 255 };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            UInt32 readBits = bitReader.ReadNBits(32);

            Assert.AreEqual((UInt32)65535, readBits);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(33)]
        [DataRow(1048576)]
        public void ReadNBit_MoreThan32Bits_ThrowsArgumentException(int numberOfBits)
        {
            byte[] testBytes = new byte[1] { 0 };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            bitReader.ReadNBits(numberOfBits);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-1048576)]
        public void ReadNBit_LessThan1Bit_ThrowsArgumentException(int numberOfBits)
        {
            byte[] testBytes = new byte[1] { 0 };
            File.WriteAllBytes(filepath, testBytes);

            bitReader = new BitReader(filepath);
            bitReader.ReadNBits(numberOfBits);
        }
    }
}
