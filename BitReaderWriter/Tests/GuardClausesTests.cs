using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BitReaderWriter;

namespace Tests
{
    [TestClass]
    public class GuardClausesTests
    {
        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(20)]
        [DataRow(32)]
        public void IsNotGreaterThan32_ValueNotGreaterThan32_DoesNothing(int value)
        {
            GuardClauses.IsNotGreaterThan32(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(33)]
        [DataRow(256)]
        [DataRow(1024)]
        [DataRow(1048576)]
        public void IsNotGreaterThan32_ValueGreaterThan32_ThrowsArgumentException(int value)
        {
            GuardClauses.IsNotGreaterThan32(value);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(20)]
        [DataRow(32)]
        public void IsNotLesserThan1_ValueNotLesserThan1_DoesNothing(int value)
        {
            GuardClauses.IsNotLesserThan1(value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-256)]
        [DataRow(-1048576)]
        public void IsNotLesserThan1_ValueLesserThan1_ThrowsArgumentException(int value)
        {
            GuardClauses.IsNotLesserThan1(value);
        }
    }
}
