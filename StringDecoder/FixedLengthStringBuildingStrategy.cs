using System;

namespace StringDecoder
{
    internal class FixedLengthStringBuildingStrategy : IStringBuildingStrategy
    {
        private int desiredNumberOfBytes;
        private int bytesProcessedSoFar;

        public FixedLengthStringBuildingStrategy(int desiredNumberOfBytes)
        {
            if (desiredNumberOfBytes < 1)
                throw new ArgumentOutOfRangeException("DesiredNumberOfBytes must be at least 1");
            if (desiredNumberOfBytes > 255)
                throw new ArgumentOutOfRangeException("DesiredNumberOfBytes must be less than 255");

            this.desiredNumberOfBytes = desiredNumberOfBytes;
        }

        public StringBuildingState ProcessByte(byte inputByte, ref string destinationString)
        {
            if (bytesProcessedSoFar >= desiredNumberOfBytes)
                throw new InvalidOperationException("The desired number of bytes have already been processed.");

            destinationString += ByteToStringConverter.ConvertToEscapedString(inputByte);

            bytesProcessedSoFar++;

            if (bytesProcessedSoFar == desiredNumberOfBytes)
                return StringBuildingState.StringComplete;
            else
                return StringBuildingState.MoreBytesRequired;
        }
    }
}