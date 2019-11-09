using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitReaderWriter;
using System.Collections.Generic;
using System.Linq;

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
        [DataRow((byte)0, (byte)127)]
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
        [DataRow((UInt32)254, 8, (UInt32)254)]
        [DataRow((UInt32)65534, 16, (UInt32)65534)]
        [DataRow((UInt32)16777214, 24, (UInt32)16777214)]
        [DataRow((UInt32)4294967294, 32, (UInt32)4294967294)]
        public void WriteNBits_ValidFile_WritesBitsCorrectly(UInt32 value, int numberOfBits, UInt32 expectedValue)
        {
            bitWriter = new BitWriter(filepath);

            bitWriter.WriteNBits(value, numberOfBits);
            bitWriter.Dispose();
            List<byte> fileBytes = File.ReadAllBytes(filepath).ToList();
            UInt32 actualValue = 0;
            for (int i = 0; i < fileBytes.Count; i++)
            {
                int shiftAmount = (fileBytes.Count - i - 1) * 8;
                actualValue |= (UInt32)(fileBytes[i] << shiftAmount);
            }

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
