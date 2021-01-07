namespace Task_3
{
    public class Port
    {
        public int Number { get; }
        public PortState State { get; set; }

        public Port(int portNumber)
        {
            Number = portNumber;
            State = PortState.Aviable;
        }

        public void Connect()
        {
            State = PortState.Aviable;
        }

        public void Disconnect()
        {
            State = PortState.Off;
        }

        public void Call()
        {
            State = PortState.NotAviable;
        }
    }
}