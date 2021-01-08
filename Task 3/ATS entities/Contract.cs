using System;

namespace Task_3.ATS_entities
{
    public class Contract
    {
        public Client Client { get; }
        public Terminal Terminal { get; }
        public DateTime StartDate { get; }
        public Tariff Tariff { get; }
        
        public Contract(Client client, Terminal terminal,  Tariff tariff)
        {
            Client = client;
            Terminal = terminal;
            StartDate = DateTime.Now;
            Tariff = tariff;
        }
    }
}