namespace Task_3.EventArgs
{
    public class InCallEventArgs
    {
        public int InputNumber { get; }

        public InCallEventArgs(int inputNumber)
        {
            InputNumber = inputNumber;
        }
    }
}