using System;
using System.Collections.Generic;
using System.Linq;
using Task_3.ATS_entities;
using Task_3.Enum;
using Task_3.EventArgs;

namespace Task_3
{
    public class ATS
    {
        private List<Contract> ContractList { get; }
        public List<Call> Calls { get; }

        private List<PortInfo> _portStateHistory; 
        public IEnumerable<Contract> Contracts => ContractList;

        public ATS()
        {
            ContractList = new List<Contract>();
            Calls = new List<Call>();
            _portStateHistory = new List<PortInfo>();
        }

        public void AddContract(Contract contract)
        {
            ContractList.Add(contract);
        }

        public void DelContract(Contract contract)
        {
            ContractList.Remove(contract);
        }

        public Contract FindContractByIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentException();
            }

            return ContractList[index];
        }

        private Contract FindContractByPhoneNumber(int number)
        {
            return ContractList.FirstOrDefault(contract => contract.Terminal.Number == number);
        }

        public void ConnectPortHandler(PortInfo portInfo)
        {
            _portStateHistory.Add(portInfo);
        }

        public void DisconnectPortHandler(PortInfo portInfo)
        {
            _portStateHistory.Add(portInfo);
        }

        public void CallOutHandler(OutCallEventArgs eventArgs)
        {
            var outputClient = FindContractByPhoneNumber(eventArgs.OutputNumber); // Нужна ли проверка на null?
            var inputClient = FindContractByPhoneNumber(eventArgs.InputNumber);
            if (inputClient != null)
            {
                var call = new Call(eventArgs.OutputNumber, eventArgs.InputNumber, outputClient.Tariff.CostPerMinute);
                switch (inputClient.Terminal.Port.GetPortState())
                {
                    case PortState.Free:
                        inputClient.Terminal.IncomingCall();
                        break;
                    case PortState.Busy:
                        outputClient.Terminal.TerminalEndCall();
                        Console.WriteLine(
                            "Абoнент занят"); // Данный вывод на консоль необходим для демонстрации работы кода
                        call.Fail();
                        break;
                    case PortState.Off:
                        outputClient.Terminal.TerminalEndCall();
                        Console.WriteLine(
                            "Абонент выключил терминал"); // Данный вывод на консоль необходим для демонстрации работы кода
                        call.Fail();
                        break;
                }

                Calls.Add(call);
            }
            else
            {
                Console.WriteLine(
                    "Такого номера не существует"); // Данный вывод на консоль необходим для демонстрации работы кода
            }
        }

        public void EndCallHandler(int number)
        {
            Call call = FindCallByPhoneNumber(number);
            var opponentNumber = number == call.OutputNumber ? call.InputNumber : call.OutputNumber;
            FindContractByPhoneNumber(opponentNumber).Terminal.ConnectPort();
            call.End();
            Console.WriteLine(
                $"Звонок между {call.OutputNumber} и {call.InputNumber} завершён"); // Данный вывод на консоль необходим для демонстрации работы кода
        }

        public void AnswerCallHandler(InCallEventArgs eventArgs)
        {
            var call = FindCallByPhoneNumber(eventArgs.InputNumber);
            call?.SuccessfulCall();
        }

        private Call FindCallByPhoneNumber(int number)
        {
            return Calls.FirstOrDefault(call =>
                call.IsActiveCall() && (call.InputNumber == number || call.OutputNumber == number));
        }
    }
}