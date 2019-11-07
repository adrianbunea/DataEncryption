using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitReaderWriter;

namespace Tests
{
    [TestClass]
    public class BitWriterTests
    {
        BitWriter bitWriter;
        string filepath = $"{Environment.CurrentDirectory}\\WriterTestFile.txt";

        [TestCleanup]
        public void Teardown()
        {
            bitWriter.Dispose();
            File.Delete(filepath);
        }

        [TestMethod]
        [DataRow((byte)0, (byte)254)]
        [DataRow((byte)1, (byte)255)]
        public void WriteBits_ValidFile_WritesBitCorrectly(byte testBit, byte expectedByte)
        {
            bitWriter = new BitWriter(filepath);

            bitWriter.WriteBit(testBit);
            bitWriter.Dispose();
            byte[] fileBytes = File.ReadAllBytes(filepath);
            byte actualByte = fileBytes[0];

            Assert.AreEqual(expectedByte, actualByte);
        }

        [TestMethod]
        [DataRow(0, 8, 0)]
        [DataRow(1, 8, 1)]
        [DataRow(127, 8, 127)]
        [DataRow(255, 8, 255)]
        public void WriteNBits_ValidFile_WritesNBitsCorrectly(int value, int numberOfBits, int expectedValue)
        {
            bitWriter = new BitWriter(filepath);

            bitWriter.WriteNBits(value, numberOfBits);
            bitWriter.Dispose();
            byte[] fileBytes = File.ReadAllBytes(filepath);
            int actualValue = fileBytes[0];

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(33)]
        [DataRow(1048576)]
        public void WriteNBits_MoreThan32Bits_ThrowsArgumentException(int numberOfBits)
        {
            bitWriter = new BitWriter(filepath);
            bitWriter.WriteNBits(0, numberOfBits);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-1048576)]
        public void WriteNBits_LessThan1Bit_ThrowsArgumentException(int numberOfBits)
        {
            bitWriter = new BitWriter(filepath);
            bitWriter.WriteNBits(0, numberOfBits);
        }
    }
}
