using System;
using Task_3.Enum;
using Task_3.EventArgs;

namespace Task_3.ATS_entities
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

        public Terminal(int number)
        {
            Number = number;
            Port = new Port();
        }

        public void ConnectPort()
        {
            Port.Connect();
        }

        public void DisconnectPort()
        {
            Port.Disconnect();
        }

        

        public void OutCall(int opponentNumber)
        {
            if (Number != opponentNumber && Port.State == PortState.Aviable)
            {
                Port.Call();
                Console.WriteLine($"Абонент {Number} звонит абоненту {opponentNumber}");
                OutCallEvent?.Invoke(new OutCallEventArgs(Number, opponentNumber));
            }
        }
        
        

        public void AnswerCall(int opponentNumber)
        {
            if (Port.State == PortState.Aviable)
            {
                Port.State = PortState.NotAviable;
                AnswerCallEvent?.Invoke(new InCallEventArgs(opponentNumber, Number));
                Console.WriteLine($"Абонент {Number} ответил абоненту {opponentNumber}");
            }
        }

        public void EndCall()
        {
            if (Port.State == PortState.NotAviable)
            {
                Port.State = PortState.Aviable;
                EndCallEvent?.Invoke(Number);
            }
        }

        public void TerminalEndCall()
        {
            Port.State = PortState.Aviable;
        }

        public PortState GetPortState()
        {
            return Port.State;
        }
    }
}