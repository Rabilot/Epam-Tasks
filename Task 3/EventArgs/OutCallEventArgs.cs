namespace Task_3.EventArgs
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