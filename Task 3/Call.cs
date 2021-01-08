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
        

        public Call(int outputNumber, int inputNumber, double costPerMinute)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
            StartTime = DateTime.Now;
            IsActive = true;
            _costPerMinute = costPerMinute;
        }

        public void End()
        {
            FinishTime = DateTime.Now;
            IsActive = false;
            CallTime = FinishTime - StartTime;
            Price = (CallTime.Minutes + 1) * _costPerMinute;
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
    }
}