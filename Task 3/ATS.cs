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
        
        public List<Contract> Contracts { get; }
        public List<Call> Calls { get; }
       // public IEnumerable<Contract> cContracts => _contracts;

        public ATS()
        {
            Contracts = new List<Contract>();
            Calls = new List<Call>();
        }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
        }

        public void DelContract(Contract contract)
        {
            Contracts.Remove(contract);
        }

        private Contract FindContractByPhoneNumber(int number)
        {
            return Contracts.FirstOrDefault(contract => contract.Terminal.Number == number);
        }

        public void CallOutHandler(OutCallEventArgs eventArgs)
        {
            var outputClient = FindContractByPhoneNumber(eventArgs.OutputNumber);  //Проверка на null
            var inputClient = FindContractByPhoneNumber(eventArgs.InputNumber);
            var call = new Call(eventArgs.OutputNumber, eventArgs.InputNumber, outputClient.Tariff.CostPerMinute);
            switch (inputClient.Terminal.Port.State)
            {
                case PortState.Aviable:
                    inputClient.Terminal.AnswerCall(eventArgs.OutputNumber);
                    break;
                case PortState.NotAviable:
                    outputClient.Terminal.TerminalEndCall();
                    Console.WriteLine("Абoнент занят");
                    call.Fail();
                    break;
                case PortState.Off:
                    outputClient.Terminal.TerminalEndCall();
                    Console.WriteLine("Абонент выключил терминал");
                    call.Fail();
                    break;
            }
            Calls.Add(call);
        }

        public void EndCallHandler(int number)
        {
            Call call = FindCallByPhoneNumber(number);
            int opponentNumber;
            opponentNumber = number == call.OutputNumber ? call.InputNumber : call.OutputNumber;
            FindContractByPhoneNumber(opponentNumber).Terminal.ConnectPort();
            // if (call == null)
            // {
            //     throw new ArgumentNullException();
            // }
            call.End();
            Console.WriteLine($"Звонок между {call.OutputNumber} и {call.InputNumber} завершён");
        }
        
        private Call FindCallByPhoneNumber(int number)
        {
            return Calls.FirstOrDefault(call =>
                call.IsActiveCall() && (call.InputNumber == number || call.OutputNumber == number));
        }
    }
}