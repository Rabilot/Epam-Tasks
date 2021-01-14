using System.Collections;
using System.Collections.Generic;
using Task_3.ATS.Contract;
using Task_3.ATS.Contract.ContractEntities;

namespace Task_3.ATS
{
    public interface IATS
    {
        void AddContract(string name, Tariff tariff);
        void DelContract(IContract contract);
        IContract FindContractByIndex(int index);
        IEnumerable<PortInfo> GetPortsHistory();
    }
}