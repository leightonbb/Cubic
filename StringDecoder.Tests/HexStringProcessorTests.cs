using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecoder.Tests
{
    [TestClass]
    public class HexStringProcessorTests
    {
        [TestMethod]
        public void Call_ProcessInputHexString_3TimesContaining2OutputStrings()
        {
            var outputter = new RecordingOutputter();
            var target = new HexStringProcessor(outputter);

            target.ProcessInputHexString("06 48 65 6C 6C");
            target.ProcessInputHexString("6F 20 00 57 6F");
            target.ProcessInputHexString("72 6C 64 00");

            Assert.AreEqual("Hello ", outputter.OutputStrings[0]);
            Assert.AreEqual("World", outputter.OutputStrings[1]);
        }
        [TestMethod]
        public void Call_ProcessInputHexString_2TimesContaining1OutputString()
        {
            var outputter = new RecordingOutputter();
            var target = new HexStringProcessor(outputter);

            target.ProcessInputHexString("08 48 69 20 54");
            target.ProcessInputHexString("68 65 72 65");

            Assert.AreEqual("Hi There", outputter.OutputStrings[0]);
        }
        [TestMethod]
        public void Call_ProcessInputHexString_2TimesContaining1OutputStringWithEscapedNonPrintingChars()
        {
            var outputter = new RecordingOutputter();
            var target = new HexStringProcessor(outputter);

            target.ProcessInputHexString("00 11 22 44 88");
            target.ProcessInputHexString("CC 00");

            Assert.AreEqual("\\x11\"D\\x88\\xCC", outputter.OutputStrings[0]);
        }
        [TestMethod]
        public void Call_ProcessInputHexString_3TimesContaining2OutputStringAnd1UnfinishedOutputString()
        {
            var outputter = new RecordingOutputter();
            var target = new HexStringProcessor(outputter);

            target.ProcessInputHexString("01 49 02 61");
            target.ProcessInputHexString("6D 04 48 65");
            target.ProcessInputHexString("72");

            Assert.AreEqual("I", outputter.OutputStrings[0]);
            Assert.AreEqual("am", outputter.OutputStrings[1]);
            Assert.AreEqual(2, outputter.OutputStrings.Count);
        }
        [TestMethod]
        public void Call_ProcessInputHexString_3TimesWithoutSpacesContaining1LongOutputString()
        {
            var outputter = new RecordingOutputter();
            var target = new HexStringProcessor(outputter);

            target.ProcessInputHexString("2C54686520717569636B2062726F776E");
            target.ProcessInputHexString("20666F78206A756D706564206F766572");
            target.ProcessInputHexString("20746865206C617A7920646F67");

            Assert.AreEqual("The quick brown fox jumped over the lazy dog", outputter.OutputStrings[0]);
            Assert.AreEqual(1, outputter.OutputStrings.Count);
        }
    }
}
