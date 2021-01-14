using Task_3.Enum;

namespace Task_3.ATS.Contract.ContractEntities
{
    public class Port
    {
        private readonly int _number;
        private const int DefaultPortNumber = 2300;
        private PortState _state;

        public Port(int number = DefaultPortNumber)
        {
            _number = number;
            _state = PortState.Free;
        }

        public void Connect()
        {
            _state = PortState.Free;
        }

        public void Disconnect()
        {
            _state = PortState.Off;
        }

        public void Call()
        {
            _state = PortState.Busy;
        }

        public void EndCall()
        {
            _state = PortState.Free;
        }

        public PortState GetPortState()
        {
            return _state;
        }

        public int GetPortNumber()
        {
            return _number;
        }
    }
}