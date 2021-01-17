using System;
using Task_3.Enum;

namespace Task_3.ATS
{
    public class Call
    {
        public int OutputNumber { get; }
        public int InputNumber { get; }
        public DateTime StartTime { get; }

        private double _price;
        private DateTime _finishTime;
        private TimeSpan _callTime;
        private CallResult _callResult;
        private readonly double _costPerMinute;

        public Call(int outputNumber, int inputNumber, double costPerMinute)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
            StartTime = DateTime.Now;
            _costPerMinute = costPerMinute;
            _callResult = CallResult.Fail;
        }

        public void End()
        {
            _finishTime = DateTime.Now;
            if (_callResult == CallResult.Successful)
            {
                _callTime = _finishTime - StartTime;
                _price = (_callTime.Minutes + 1) * _costPerMinute;
            }
            else
            {
                _callTime = TimeSpan.Zero;
                _price = 0;
            }
        }

        public void Fail()
        {
            _finishTime = StartTime;
            _callTime = TimeSpan.Zero;
        }

        public TimeSpan GetCallTime()
        {
            return _callTime;
        }

        public void SuccessfulCall()
        {
            _callResult = CallResult.Successful;
        }

        public double GetPrice()
        {
            return _price;
        }

        public CallResult GetCallResult()
        {
            return _callResult;
        }
    }
}