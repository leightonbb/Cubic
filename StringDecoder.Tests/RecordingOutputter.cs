using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecoder.Tests
{
    class RecordingOutputter : IOutputter
    {
        public List<string> OutputStrings = new List<string>();
        public void OutputText(string textToOutput)
        {
            OutputStrings.Add(textToOutput);
        }
    }
}
