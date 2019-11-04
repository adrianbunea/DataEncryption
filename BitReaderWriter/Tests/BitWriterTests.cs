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
        [DataRow((byte)0, (byte)0)]
        [DataRow((byte)1, (byte)128)]
        public void WriteBit_ValidFile_WritesBitCorrectly(byte testBit, byte expectedByte)
        {
            bitWriter = new BitWriter(filepath);
            bitWriter.WriteBit(testBit);
            for (int i = 0; i < 8; i++)
            {
                bitWriter.WriteBit(0);
            }
            bitWriter.Dispose();
            byte[] fileBytes = File.ReadAllBytes(filepath);
            byte actualByte = fileBytes[0];

            Assert.AreEqual(expectedByte, actualByte);
        }

        [TestMethod]
        public void WriteNBit_ValidFile_WritesNBitsCorrectly()
        {

        }
    }
}
