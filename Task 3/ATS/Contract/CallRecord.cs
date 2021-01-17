using System;
using Task_3.Enum;

namespace Task_3.ATS.Contract
{
    public class CallRecord
    {
        private readonly CallType _callType;
        private readonly int _opponentNumber;
        private readonly DateTime _startDateTime;
        private readonly TimeSpan _callTime;
        private readonly double _price;
        private readonly CallResult _callResult;

        public CallRecord(Call call, CallType callType)
        {
            _startDateTime = call.StartTime;
            _callTime = call.GetCallTime();
            _callType = callType;
            _callResult = call.GetCallResult();
            switch (callType)
            {
                case CallType.Outgoing:
                    _opponentNumber = call.InputNumber;
                    _price = call.GetPrice();
                    break;
                case CallType.Incoming:
                    _opponentNumber = call.OutputNumber;
                    _price = 0;
                    break;
            }
        }

        public int GetOpponentNumber()
        {
            return _opponentNumber;
        }

        public double GetPrice()
        {
            return _price;
        }

        public override string ToString()
        {
            return
                $"{_callType,7}   {_startDateTime,19}   {_opponentNumber,12}   {_callTime,16}   {_price,4}   {_callResult,11}";
        }
    }
}