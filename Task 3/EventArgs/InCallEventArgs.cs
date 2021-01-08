namespace Task_3.EventArgs
{
    public class InCallEventArgs
    {
        public int OutputNumber { get; }
        public int InputNumber { get; }

        public InCallEventArgs(int outputNumber, int inputNumber)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
        }
    }
}