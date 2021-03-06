﻿using System;
using System.IO;
using BitReaderWriter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitBufferTests
    {
        readonly string filepath = $"{Environment.CurrentDirectory}\\ReaderTestFile.txt";
        BitBuffer buffer;

        [TestCleanup]
        public void Teardown()
        {
            buffer.Dispose();
            File.Delete(filepath);
        }

        [TestMethod]
        [DataRow((byte)128, (byte)0)]
        [DataRow((byte)64, (byte)1)]
        [DataRow((byte)129, (byte)0)]
        [DataRow((byte)63, (byte)0)]
        public void Pop_WhenBufferIsNotEmpty_ReturnsLeftmostBit(byte testByte, byte expectedBit)
        {
            byte[] testBytes = new byte[1] { testByte };
            File.WriteAllBytes(filepath, testBytes);
            buffer = new BitBuffer(File.OpenRead(filepath));

            buffer.Pop(); // Makes the empty buffer fetch a byte from the file
            byte bit = buffer.Pop();

            Assert.AreEqual(expectedBit, bit);
        }

        [TestMethod]
        [DataRow((byte)128, (byte)1)]
        [DataRow((byte)64, (byte)0)]
        public void Pop_WhenBufferIsEmpty_ReturnsLeftmostBit(byte testByte, byte expectedBit)
        {
            byte[] testBytes = new byte[1] { testByte };
            File.WriteAllBytes(filepath, testBytes);
            buffer = new BitBuffer(File.OpenRead(filepath));

            byte bit = buffer.Pop();

            Assert.AreEqual(expectedBit, bit);
        }

        [TestMethod]
        [DataRow((byte)0, (byte)127)]
        [DataRow((byte)1, (byte)255)]
        public void Push_WhenBufferIsNotFull_WritesRightmostBit(byte testBit, byte expectedByte)
        {
            FileStream fs = File.Create(filepath);
            buffer = new BitBuffer(fs);

            buffer.Push(testBit);
            buffer.Flush();
            buffer.Dispose();

            fs = File.Open(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            byte actualByte = (byte)fs.ReadByte();
            fs.Close();

            Assert.AreEqual(expectedByte, actualByte);
        }

        [TestMethod]
        [DataRow((byte)0, (byte)127)]
        [DataRow((byte)1, (byte)255)]
        public void Push_WhenBufferIsFull_WritesContentToFile(byte testBit, byte expectedByte)
        {
            FileStream fs = File.Create(filepath);
            buffer = new BitBuffer(fs);

            buffer.Push(testBit);
            buffer.Flush();
            buffer.Dispose();

            fs = File.Open(filepath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            byte actualByte = (byte)fs.ReadByte();
            fs.Close();

            Assert.AreEqual(expectedByte, actualByte);
        }
    }
}
