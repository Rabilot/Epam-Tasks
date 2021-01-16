using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task_3.ATS.Contract.ContractEntities;
using Task_3.Enum;

namespace Task_3.ATS.Contract
{
    public class Contract : IContract
    {
        public Client Client { get; }
        public Terminal Terminal { get; }
        public DateTime StartDate { get; }
        public Tariff Tariff { get; }

        public Contract(string name, int number, Tariff tariff)
        {
            Client = new Client(name);
            Terminal = new Terminal(number);
            StartDate = DateTime.Now;
            Tariff = tariff;
        }
    }
}