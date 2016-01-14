using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecoder
{
    public class HexConverter
    {
        public static byte[] ConvertToBytes(string inputText)
        {
            var inputTextWithSpaces = inputText.Replace(" ", "");

            var bytes = new List<byte>();
            for (int i = 0; i < inputTextWithSpaces.Length; i += 2)
            {
                var hexValueText = inputTextWithSpaces.Substring(i, 2);
                var nextByte = byte.Parse(hexValueText, System.Globalization.NumberStyles.HexNumber);
                bytes.Add(nextByte);
            }

            return bytes.ToArray();
        }
    }
}
