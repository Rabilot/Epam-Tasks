using System;
using System.Linq;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ATS ats = new ATS();
            Tariff tariff = new Tariff(0.1);
            ats.AddContract(new Contract(new Client("Nick"), new Terminal(265874, new Port(1235)), tariff));
            ats.Contracts.Last().Terminal.OutCallEvent += ats.CallOutHandler;
            ats.Contracts.Last().Terminal.EndCallEvent += ats.EndCallHandler;
            ats.AddContract(new Contract(new Client("Mike"), new Terminal(578854, new Port(1235)), tariff));
            ats.Contracts.Last().Terminal.OutCallEvent += ats.CallOutHandler;
            ats.Contracts.Last().Terminal.EndCallEvent += ats.EndCallHandler;
            ats.AddContract(new Contract(new Client("Alex"), new Terminal(986245, new Port(1235)), tariff));
            ats.Contracts.Last().Terminal.OutCallEvent += ats.CallOutHandler;
            ats.Contracts.Last().Terminal.EndCallEvent += ats.EndCallHandler;
            

            ats.Contracts[0].Terminal.OutCall(ats.Contracts[1].Terminal.Number);
            ats.Contracts[1].Terminal.AnswerCall(ats.Contracts[0].Terminal.Number);
            ats.Contracts[2].Terminal.OutCall(ats.Contracts[0].Terminal.Number);
            ats.Contracts[1].Terminal.EndCall();
            Console.WriteLine();
        }
    }
}