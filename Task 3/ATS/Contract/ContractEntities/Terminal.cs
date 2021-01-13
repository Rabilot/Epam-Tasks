using System;
using Task_3.Enum;
using Task_3.EventArgs;

namespace Task_3.ATS.Contract.ContractEntities
{
    public class Terminal
    {
        public int Number { get; }

        public Port Port { get; }

        //Событие исходящего вызова
        public delegate void OutCallHandler(OutCallEventArgs eventArgs);

        public event OutCallHandler OutCallEvent;

        //Событие ответа на вызов
        public delegate void AnswerCallHandler(InCallEventArgs eventArgs);

        public event AnswerCallHandler AnswerCallEvent;

        //Событие завершения вызова
        public delegate void EndCallHandler(int number);

        public event EndCallHandler EndCallEvent;

        //Событие подключения порта
        public delegate void ConnectPortHandler(PortInfo portInfo);

        public event ConnectPortHandler ConnectPortEvent;

        //Событие отключения порта
        public delegate void DisconnectPortHandler(PortInfo portInfo);

        public event DisconnectPortHandler DisconnectPortEvent;

        public Terminal(int number)
        {
            Number = number;
            Port = new Port(2300);
        }

        public void ConnectPort()
        {
            Port.Connect();
            ConnectPortEvent?.Invoke(new PortInfo(Number, Port.GetPortNumber(), Port.GetPortState(), DateTime.Now));
        }

        public void DisconnectPort()
        {
            Port.Disconnect();
            DisconnectPortEvent?.Invoke(new PortInfo(Number, Port.GetPortNumber(), Port.GetPortState(), DateTime.Now));
        }

        public void OutCall(int opponentNumber)
        {
            if (Number != opponentNumber && Port.GetPortState() == PortState.Free)
            {
                Port.Call();
                OutCallEvent?.Invoke(new OutCallEventArgs(Number, opponentNumber));
            }
        }

        public void IncomingCall()
        {
            Port.Call();
        }

        public void AnswerCall()
        {
            if (Port.GetPortState() == PortState.Busy)
            {
                AnswerCallEvent?.Invoke(new InCallEventArgs(Number));
            }
        }

        public void EndCall()
        {
            if (Port.GetPortState() == PortState.Busy)
            {
                Port.EndCall();
                EndCallEvent?.Invoke(Number);
            }
        }

        public void TerminalEndCall()
        {
            Port.EndCall();
        }

        public PortState GetPortState()
        {
            return Port.GetPortState();
        }
    }
}