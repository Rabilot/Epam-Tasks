using System;

namespace Task_1.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) : base(message)
        {
            
        }
    }
}