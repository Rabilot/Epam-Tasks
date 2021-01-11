using System;
using Task_3.Enum;

namespace Task_3.ATS_entities
{
    public class PortInfo
    {
        private int _terminalNumber;
        private int _portNumber;
        private PortState _portState;
        private DateTime _dateTime;

        public PortInfo(int terminalNumber, int portNumber, PortState portState, DateTime dateTime)
        {
            _terminalNumber = terminalNumber;
            _portNumber = portNumber;
            _portState = portState;
            _dateTime = dateTime;
        }
    }
}