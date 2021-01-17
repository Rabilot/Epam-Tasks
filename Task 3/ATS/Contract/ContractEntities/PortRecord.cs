using System;
using Task_3.Enum;

namespace Task_3.ATS.Contract.ContractEntities
{
    public class PortRecord
    {
        private readonly int _portNumber;
        private readonly PortState _portState;
        private readonly DateTime _dateTime;

        public PortRecord(int portNumber, PortState portState, DateTime dateTime)
        {
            _portNumber = portNumber;
            _portState = portState;
            _dateTime = dateTime;
        }

        public override string ToString()
        {
            return $"{_portNumber} {_portState} {_dateTime}";
        }
    }
}