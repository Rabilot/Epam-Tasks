using System;

namespace Task_3
{
    public class EndCallEventArgs
    {
        public int OutputNumber { get; }
        public int InputNumber { get; }

        public EndCallEventArgs(int outputNumber, int inputNumber)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
        }
    }
}