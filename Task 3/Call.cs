using System;

namespace Task_3
{
    public class Call
    {
        public int OutputNumber { get; }
        public int InputNumber { get; }
        private DateTime StartTime { get; }
        private DateTime FinishTime { get; set; }
        private bool IsActive { get; set; }

        public Call(int outputNumber, int inputNumber)
        {
            OutputNumber = outputNumber;
            InputNumber = inputNumber;
            StartTime = DateTime.Now;
            IsActive = true;
        }

        public void End()
        {
            FinishTime = DateTime.Now;
            IsActive = false;
        }

        public void Fail()
        {
            FinishTime = StartTime;
            IsActive = false;
        }

        public bool IsActiveCall()
        {
            return IsActive;
        }
    }
}