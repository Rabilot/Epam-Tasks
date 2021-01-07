using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    public class ATS
    {
        public List<Contract> Contracts { get; }
        public List<Call> Calls { get; }

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

        public Contract FindContractByPhoneNumber(int number)
        {
            return Contracts.FirstOrDefault(contract => contract.Terminal.Number == number);
        }

        public Call FindCallByPhoneNumber(int number)
        {
            return Calls.FirstOrDefault(call =>
                call.IsActiveCall() == true && call.InputNumber == number || call.OutputNumber == number);
        }

        public void CallOutHandler(int outputNumber, int inputNumber)
        {
            var outputClient = FindContractByPhoneNumber(outputNumber);
            var inputClient = FindContractByPhoneNumber(inputNumber);
            Call call = new Call(outputNumber, inputNumber);
            switch (inputClient.Terminal.Port.State)
            {
                case PortState.Aviable:
                    inputClient.Terminal.AnswerCall(outputNumber);
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
            // if (call == null)
            // {
            //     throw new ArgumentNullException();
            // }
            call.End();
            Console.WriteLine($"Звонок между {call.OutputNumber} и {call.InputNumber} завершён");
        }
    }
}