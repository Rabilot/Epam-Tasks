using System;
using Task_3.ATS.Contract.ContractEntities;

namespace Task_3.ATS.Contract
{
    public interface IContract
    {
        Client Client { get; }
        Terminal Terminal { get; }
        DateTime StartDate { get; }
        Tariff Tariff { get; }
    }
}