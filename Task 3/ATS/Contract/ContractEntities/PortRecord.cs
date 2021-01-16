using System;
using Task_3.Enum;

namespace Task_3.ATS.Contract.ContractEntities
{
    public class PortRecord
    {
        private readonly int _terminalNumber;
        private readonly int _portNumber;
        private readonly PortState _portState;
        private readonly DateTime _dateTime;

        public PortRecord(int terminalNumber, int portNumber, PortState portState, DateTime dateTime)
        {
            _terminalNumber = terminalNumber;
            _portNumber = portNumber;
            _portState = portState;
            _dateTime = dateTime;
        }

        public int GetTerminalNumber()
        {
            return _terminalNumber;
        }

        public override string ToString()
        {
            return $"{_terminalNumber} {_portNumber} {_portState} {_dateTime}";
        }
    }
}