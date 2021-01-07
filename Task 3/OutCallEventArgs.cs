namespace Task_3
{
    public class OutCallEventArgs
    {
        public int OutputNumber { get; }
        public int InputNumber { get; }

        public OutCallEventArgs(int outputNumber, int inputNumber)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
        }
    }
}