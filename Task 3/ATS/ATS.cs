using System;
using System.Collections.Generic;
using System.Linq;
using Task_3.ATS.Billing;
using Task_3.ATS.Billing.Interfaces;
using Task_3.ATS.Contract;
using Task_3.ATS.Contract.ContractEntities;
using Task_3.Enum;
using Task_3.EventArgs;

namespace Task_3.ATS
{
    public class ATS : IATS
    {
        private readonly List<IContract> _contractList;
        private readonly List<Call> _activeCalls;
        private readonly List<PortRecord> _portStateHistory;
        private readonly IBillingSystem _billingSystem;

        public ATS(IBillingSystem billingSystem)
        {
            _contractList = new List<IContract>();
            _activeCalls = new List<Call>();
            _portStateHistory = new List<PortRecord>();
            _billingSystem = billingSystem;
        }

        public void AddContract(string name, Tariff tariff)
        {
            int number;
            if (!_contractList.Any())
            {
                number = 1000000;
            }
            else
            {
                number = _contractList.Last().Terminal.TerminalNumber + 1;
            }

            IContract contract = new Contract.Contract(name, number, tariff);
            contract.Terminal.OutCallEvent += CallOutHandler;
            contract.Terminal.EndCallEvent += EndCallHandler;
            contract.Terminal.Port.ConnectPortEvent += ConnectPortHandler;
            contract.Terminal.Port.DisconnectPortEvent += DisconnectPortHandler;
            contract.Terminal.AnswerCallEvent += AnswerCallHandler;
            _contractList.Add(contract);
        }

        public void DelContract(IContract contract)
        {
            contract.Terminal.OutCallEvent -= CallOutHandler;
            contract.Terminal.EndCallEvent -= EndCallHandler;
            contract.Terminal.Port.ConnectPortEvent -= ConnectPortHandler;
            contract.Terminal.Port.DisconnectPortEvent -= DisconnectPortHandler;
            contract.Terminal.AnswerCallEvent -= AnswerCallHandler;
            _contractList.Remove(contract);
        }

        public IContract FindContractByIndex(int index)
        {
            if (index < 0 || index >= _contractList.Count())
            {
                throw new ArgumentException();
            }

            return _contractList[index];
        }

        public IEnumerable<PortRecord> GetPortsHistory()
        {
            return _portStateHistory;
        }

        public List<CallRecord> GetBilling(BillingFilter billingFilter, IContract contract)
        {
            return _billingSystem.GetBilling(billingFilter, contract);
        }

        private void DisconnectPortHandler(PortRecord portRecord)
        {
            _portStateHistory.Add(portRecord);
        }

        private void ConnectPortHandler(PortRecord portRecord)
        {
            _portStateHistory.Add(portRecord);
        }

        private void CallOutHandler(OutCallEventArgs eventArgs)
        {
            var outputClient = FindContractByPhoneNumber(eventArgs.OutputNumber);
            var inputClient = FindContractByPhoneNumber(eventArgs.InputNumber);
            if (inputClient != null)
            {
                var call = new Call(eventArgs.OutputNumber, eventArgs.InputNumber,
                    outputClient.Tariff.CostPerMinute);
                switch (inputClient.Terminal.Port.GetPortState())
                {
                    case PortState.Free:
                        inputClient.Terminal.IncomingCall();
                        _activeCalls.Add(call);
                        break;
                    case PortState.Busy:
                        outputClient.Terminal.TerminalEndCall();
                        Console.WriteLine(
                            "Абoнент занят");
                        call.Fail();
                        _billingSystem.AddCall(call);
                        break;
                    case PortState.Off:
                        outputClient.Terminal.TerminalEndCall();
                        Console.WriteLine(
                            "Абонент выключил терминал");
                        call.Fail();
                        _billingSystem.AddCall(call);
                        break;
                }
            }
            else
            {
                Console.WriteLine(
                    "Такого номера не существует");
            }
        }

        private void EndCallHandler(int number)
        {
            var call = FindCallByPhoneNumber(number);
            var opponentNumber = number == call.OutputNumber ? call.InputNumber : call.OutputNumber;
            FindContractByPhoneNumber(opponentNumber).Terminal.Port.EndCall();
            call.End();
            _billingSystem.AddCall(call);
            _activeCalls.Remove(call);
            Console.WriteLine(
                $"Звонок между {call.OutputNumber} и {call.InputNumber} завершён");
        }

        private void AnswerCallHandler(InCallEventArgs eventArgs)
        {
            var call = FindCallByPhoneNumber(eventArgs.InputNumber);
            call?.SuccessfulCall();
        }

        private Call FindCallByPhoneNumber(int number)
        {
            return _activeCalls.FirstOrDefault(call =>
                call.InputNumber == number || call.OutputNumber == number);
        }

        private IContract FindContractByPhoneNumber(int number)
        {
            return _contractList.FirstOrDefault(contract => contract.Terminal.TerminalNumber == number);
        }
    }
}