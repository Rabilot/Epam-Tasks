using System;
using System.Text;

namespace Task_3
{
    public class Call
    {
        private readonly double _costPerMinute;
        public int OutputNumber { get; }
        public int InputNumber { get; }
        public DateTime StartTime { get; }
        private DateTime FinishTime { get; set; }
        private TimeSpan CallTime { get; set; }
        private bool IsActive { get; set; }
        public double Price { get; set; }
        public bool IsSuccessful;


        public Call(int outputNumber, int inputNumber, double costPerMinute)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
            StartTime = DateTime.Now;
            IsActive = true;
            _costPerMinute = costPerMinute;
            IsSuccessful = false;
        }

        public void End()
        {
            FinishTime = DateTime.Now;
            IsActive = false;
            if (IsSuccessful)
            {
                CallTime = FinishTime - StartTime;
                Price = (CallTime.Minutes + 1) * _costPerMinute;
            }
            else
            {
                CallTime = TimeSpan.Zero;
                Price = 0;
            }
            
        }

        public void Fail()
        {
            FinishTime = StartTime;
            IsActive = false;
            CallTime = TimeSpan.Zero;
        }

        public bool IsActiveCall()
        {
            return IsActive;
        }

        public TimeSpan GetCallTime()
        {
            return CallTime;
        }

        public void SuccessfulCall()
        {
            IsSuccessful = true;
        }
    }
}