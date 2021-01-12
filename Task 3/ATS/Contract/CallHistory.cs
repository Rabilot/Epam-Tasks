using System;
using System.Text;
using Task_3.Enum;

namespace Task_3.ATS.Contract
{
    public class CallHistory
    {
        private readonly StringBuilder _stringBuilder;
        private readonly CallType _callType;
        private readonly int _opponentNumber;
        private readonly DateTime _startTime;
        private readonly TimeSpan _callTime;
        private readonly double _price;
        private readonly bool _isSuccessful;


        public CallHistory(ActiveCall activeCall, CallType callType)
        {
            _startTime = activeCall.StartTime;
            _callTime = activeCall.GetCallTime();
            _callType = callType;
            _isSuccessful = activeCall.IsSuccessful;
            switch (callType)
            {
                case CallType.Outgoing:
                    _opponentNumber = activeCall.InputNumber;
                    _price = activeCall.Price;
                    break;
                case CallType.Incoming:
                    _opponentNumber = activeCall.OutputNumber;
                    _price = 0;
                    break;
            }

            _stringBuilder = new StringBuilder();
        }

        public DateTime GetStartTime()
        {
            return _startTime;
        }

        public double GetPrice()
        {
            return _price;
        }

        public override string ToString()
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(
                $"{_callType} {_startTime} {_opponentNumber} Call time: {_callTime} Price: {_price} {_isSuccessful}");
            return _stringBuilder.ToString();
        }
    }
}