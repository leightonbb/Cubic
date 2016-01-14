using System;

namespace StringDecoder
{
    internal class ZeroTerminateStringBuildingStrategy : IStringBuildingStrategy
    {
        public StringBuildingState ProcessByte(byte inputByte, ref string destinationString)
        {
            if (inputByte == 0)
                return StringBuildingState.StringComplete;

            destinationString += ByteToStringConverter.ConvertToEscapedString(inputByte);

            return StringBuildingState.MoreBytesRequired;
        }
    }
}