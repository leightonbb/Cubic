using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecoder.Tests
{
    [TestClass]
    public class HexConverterTests
    {
        [TestMethod]
        public void Call_ConvertToBytes_WithSpaceSeparagedValues()
        {
            var result = HexConverter.ConvertToBytes("06 48 65 6C 6C");
            Assert.AreEqual(0x06, result[0]);
            Assert.AreEqual(0x48, result[1]);
            Assert.AreEqual(0x6C, result[4]);
            Assert.AreEqual(5, result.Length);
        }
    }
}
