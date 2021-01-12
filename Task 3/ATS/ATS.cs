using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Task_3.ATS.Contract;
using Task_3.ATS.Contract.ContractEntities;
using Task_3.Enum;
using Task_3.EventArgs;

namespace Task_3.ATS
{
    public class ATS : IATS
    {
        private readonly List<IContract> _contractList;
        public List<ActiveCall> ActiveCalls { get; } // Изменить

        private readonly List<PortInfo> _portStateHistory;
        public IEnumerable Contracts => _contractList;

        public ATS()
        {
            _contractList = new List<IContract>();
            ActiveCalls = new List<ActiveCall>();
            _portStateHistory = new List<PortInfo>();
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
                number = _contractList.Last().Terminal.Number + 1;
            }

            IContract contract = new Contract.Contract(name, number, tariff);
            contract.Terminal.OutCallEvent += CallOutHandler;
            contract.Terminal.EndCallEvent += EndCallHandler;
            contract.Terminal.ConnectPortEvent += ConnectPortHandler;
            contract.Terminal.DisconnectPortEvent += DisconnectPortHandler;
            contract.Terminal.AnswerCallEvent += AnswerCallHandler;
            _contractList.Add(contract);
        }

        public void DelContract(IContract contract)
        {
            _contractList.Remove(contract);
        }

        public IContract FindContractByIndex(int index)
        {
            if (index < 0 && index < _contractList.Count())
            {
                throw new ArgumentException();
            }

            return _contractList[index];
        }

        public List<PortInfo> GetPortsHistory()
        {
            return _portStateHistory;
        }

        private void DisconnectPortHandler(PortInfo portInfo)
        {
            _portStateHistory.Add(portInfo);
        }

        private void ConnectPortHandler(PortInfo portInfo)
        {
            _portStateHistory.Add(portInfo);
        }

        private void CallOutHandler(OutCallEventArgs eventArgs)
        {
            var outputClient = FindContractByPhoneNumber(eventArgs.OutputNumber); // Нужна ли проверка на null?
            var inputClient = FindContractByPhoneNumber(eventArgs.InputNumber);
            if (inputClient != null)
            {
                var call = new ActiveCall(eventArgs.OutputNumber, eventArgs.InputNumber, outputClient.Tariff.CostPerMinute);
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
                        outputClient.AddCall(call, CallType.Outgoing);
                        break;
                    case PortState.Off:
                        outputClient.Terminal.TerminalEndCall();
                        Console.WriteLine(
                            "Абонент выключил терминал"); // Данный вывод на консоль необходим для демонстрации работы кода
                        call.Fail();
                        outputClient.AddCall(call, CallType.Outgoing);
                        break;
                }

                ActiveCalls.Add(call);
            }
            else
            {
                Console.WriteLine(
                    "Такого номера не существует"); // Данный вывод на консоль необходим для демонстрации работы кода
            }
        }

        private void EndCallHandler(int number)
        {
            var call = FindCallByPhoneNumber(number);
            var opponentNumber = number == call.OutputNumber ? call.InputNumber : call.OutputNumber;
            FindContractByPhoneNumber(opponentNumber).Terminal.ConnectPort();
            call.End();
            var outputClient = FindContractByPhoneNumber(call.OutputNumber);
            var inputClient = FindContractByPhoneNumber(call.InputNumber);
            outputClient.AddCall(call, CallType.Outgoing);
            inputClient.AddCall(call, CallType.Incoming);
            ActiveCalls.Remove(call);
            Console.WriteLine(
                $"Звонок между {call.OutputNumber} и {call.InputNumber} завершён"); // Данный вывод на консоль необходим для демонстрации работы кода
        }

        private void AnswerCallHandler(InCallEventArgs eventArgs)
        {
            var call = FindCallByPhoneNumber(eventArgs.InputNumber);
            call?.SuccessfulCall();
        }

        private ActiveCall FindCallByPhoneNumber(int number)
        {
            return ActiveCalls.FirstOrDefault(call =>
                call.IsActiveCall() && (call.InputNumber == number || call.OutputNumber == number));
        }

        private IContract FindContractByPhoneNumber(int number)
        {
            return _contractList.FirstOrDefault(contract => contract.Terminal.Number == number);
        }
    }
}