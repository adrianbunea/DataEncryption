using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitReaderWriter;

namespace Tests
{
    [TestClass]
    public class BitReaderWriterTests
    {
        readonly string sourceImagePath = Path.GetFullPath(Path.Combine($"{Environment.CurrentDirectory}", "..\\..", "TestData\\TestImage.jpg"));
        readonly string resultImagePath = Path.GetFullPath(Path.Combine($"{Environment.CurrentDirectory}", "..\\..", "TestData\\ResultImage.jpg"));

        [TestMethod]
        public void CanCreateIdenticalCopyOfAFile()
        {
            FileInfo fileInfo = new FileInfo(sourceImagePath);
            long totalBits = fileInfo.Length * 8;

            BitReader reader = new BitReader(sourceImagePath);
            BitWriter writer = new BitWriter(resultImagePath);
            Random rand = new Random();
            int bitsCount;
            for (int i = 0; i < totalBits; i+=bitsCount)
            {
                bitsCount = rand.Next(1, 33);
                writer.WriteNBits(reader.ReadNBits(bitsCount), bitsCount);
            }

            /*
            writer.Dispose();
            reader.Dispose();

            FileStream fsSource = File.OpenRead(sourceImagePath);
            FileStream fsResult = File.OpenRead(resultImagePath);

            int currentByte;
            while ((currentByte = fsSource.ReadByte()) != -1)
            {
                if (currentByte != fsResult.ReadByte())
                {
                    Assert.Fail();
                }
            }

            fsSource.Dispose();
            fsResult.Dispose();
            */
        }
    }
}
