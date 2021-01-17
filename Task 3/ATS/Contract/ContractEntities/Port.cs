using System;
using Task_3.Enum;

namespace Task_3.ATS.Contract.ContractEntities
{
    public class Port
    {
        private readonly int _number;
        private const int DefaultPortNumber = 2300;
        private PortState _state;
        private const PortState DefaultPortState = PortState.Free;

        #region ConnectPort

        public delegate void ConnectPortHandler(PortRecord portRecord);

        public event ConnectPortHandler ConnectPortEvent;

        #endregion

        #region DisconnectPort

        public delegate void DisconnectPortHandler(PortRecord portRecord);

        public event DisconnectPortHandler DisconnectPortEvent;

        #endregion

        public Port(int number = DefaultPortNumber, PortState state = DefaultPortState)
        {
            _number = number;
            _state = state;
        }

        public void Connect()
        {
            ConnectPortEvent?.Invoke(new PortRecord(_number, PortState.Free, DateTime.Now));
            _state = PortState.Free;
        }

        public void Disconnect()
        {
            DisconnectPortEvent?.Invoke(new PortRecord(_number, PortState.Off, DateTime.Now));
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