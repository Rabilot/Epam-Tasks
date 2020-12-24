using System;

namespace Task_2.Writer
{
    public class ConsoleWriter : IInfoWriter
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
        
        public void Write(string str)
        {
            Console.Write(str);
        }
    }
}