using System.Globalization;
using Task_3.Enum;

namespace Task_3.ATS_entities
{
    public class Port
    {
        private int _number;
        private PortState _state;

        public Port(int number)
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