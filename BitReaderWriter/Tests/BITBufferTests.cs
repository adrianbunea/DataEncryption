using System;
using BitReaderWriter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BitBufferTests
    {
        [TestMethod]
        [DataRow((byte)128, (byte)0)]
        [DataRow((byte) 64, (byte)1)]
        [DataRow((byte)129, (byte)0)]
        [DataRow((byte) 63, (byte)0)]
        public void Pop_WhenBufferIsNotEmpty_ReturnsLeftmostBit(byte testByte, byte expectedBit)
        {
            byte[] testBytes = new byte[1] { testByte };
            BitBuffer buffer = new BitBuffer(testBytes);

            buffer.Pop();
            byte bit = buffer.Pop();

            Assert.AreEqual(expectedBit, bit);
        }

        [TestMethod]
        [DataRow((byte)128, (byte)1)]
        [DataRow((byte) 64, (byte)0)]
        [DataRow((byte)129, (byte)1)]
        [DataRow((byte) 63, (byte)0)]
        public void Pop_WhenBufferIsEmpty_ReturnsLeftmostBit(byte testByte, byte expectedBit)
        {
            byte[] testBytes = new byte[1] { testByte };
            BitBuffer buffer = new BitBuffer(testBytes);

            byte bit = buffer.Pop();

            Assert.AreEqual(expectedBit, bit);
        }
    }
}
