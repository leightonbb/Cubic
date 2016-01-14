using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecoder
{
    class ByteToStringConverter
    {
        public static string ConvertToEscapedString(byte inputByte)
        {
            if (IsPrintable((char)inputByte))
                return new String((char)inputByte, 1);
            else
                return "\\x" + inputByte.ToString("X2");
        }

        private static bool IsPrintable(char charInQuestion)
        {
            if (Char.IsLetterOrDigit(charInQuestion) && charInQuestion <= 126)
                return true;
            if (Char.IsWhiteSpace(charInQuestion))
                return true;
            if (Char.IsPunctuation(charInQuestion))
                return true;
            return false;
        }
    }
}
