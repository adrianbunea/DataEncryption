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
            File.Delete(filepath);
        }

        [TestMethod]
        [DataRow((byte)0, (byte)254)]
        [DataRow((byte)1, (byte)255)]
        public void WriteBit_ValidFile_WritesBitCorrectly(byte testBit, byte expectedByte)
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
        public void WriteNBit_ValidFile_WritesNBitsCorrectly(int value, int numberOfBits, int expectedValue)
        {
            bitWriter = new BitWriter(filepath);

            bitWriter.WriteNBit(value, numberOfBits);
            bitWriter.Dispose();
            byte[] fileBytes = File.ReadAllBytes(filepath);
            int actualValue = fileBytes[0];

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
