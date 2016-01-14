using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringDecoder
{
    public class HexStringProcessor
    {
        public HexStringProcessor(IOutputter outputter)
        {
            _outputter = outputter;
        }

        IOutputter _outputter;

        public void ProcessInputHexString(string inputText)
        {
            byte[] inputBytes = HexConverter.ConvertToBytes(inputText);

            foreach (var inputByte in inputBytes)
                ProcessByte(inputByte);
        }

        private void ProcessByte(byte inputByte)
        {
            if (_currentByteProcessingStrategy == null)
            {
                if (inputByte == 0)
                    _currentByteProcessingStrategy = new ZeroTerminateStringBuildingStrategy();
                else
                    _currentByteProcessingStrategy = new FixedLengthStringBuildingStrategy(inputByte);
            }
            else
            {
                var stringBuildingState = _currentByteProcessingStrategy.ProcessByte(inputByte, ref _currentOutputString);
                if (stringBuildingState == StringBuildingState.StringComplete)
                {
                    _currentByteProcessingStrategy = null;
                    _outputter.OutputText(_currentOutputString);
                    _currentOutputString = "";
                }
            }
        }

        IStringBuildingStrategy _currentByteProcessingStrategy;
        string _currentOutputString = "";
    }

    interface IStringBuildingStrategy
    {
        StringBuildingState ProcessByte(byte inputByte, ref string destinationString);
    }

    enum StringBuildingState
    {
        MoreBytesRequired,
        StringComplete,
    };
}