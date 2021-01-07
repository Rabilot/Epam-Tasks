using System;

namespace Task_3
{
    public class Terminal
    {
        public int Number { get; }
        public Port Port { get; }
        //Событие исходящего вызова
        public delegate void OutCallHandler(int output, int input); //object sender, OutCallEventArgs e
        public event OutCallHandler OutCallEvent;
        //Событие ответа на вызов
        public delegate void AnswerCallHandler(int output, int input);
        public event AnswerCallHandler AnswerCallEvent;
        //Событие завершения вызова
        public delegate void EndCallHandler(int number);
        public event EndCallHandler EndCallEvent;

        public Terminal(int number, Port port)
        {
            Number = number;
            Port = port;
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
                OutCallEvent?.Invoke(Number, opponentNumber);
            }
        }
        
        

        public void AnswerCall(int opponentNumber)
        {
            if (Port.State == PortState.Aviable)
            {
                Port.State = PortState.NotAviable;
                AnswerCallEvent?.Invoke(opponentNumber, Number);
                Console.WriteLine($"Абонент {Number} ответил абоненту {opponentNumber}");
            }
        }
        
        

        public void EndCall()
        {
            if (Port.State == PortState.NotAviable)
            {
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