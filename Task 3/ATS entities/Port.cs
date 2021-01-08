using Task_3.Enum;

namespace Task_3.ATS_entities
{
    public class Port
    {
        public PortState State { get; set; }

        public Port()
        {
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