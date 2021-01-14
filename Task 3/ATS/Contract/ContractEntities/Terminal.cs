using System;
using Task_3.Enum;
using Task_3.EventArgs;

namespace Task_3.ATS.Contract.ContractEntities
{
    public class Terminal
    {
        public int TerminalNumber { get; }
        public Port Port { get; }

        #region OutCall
        public delegate void OutCallHandler(OutCallEventArgs eventArgs);
        public event OutCallHandler OutCallEvent;
        #endregion

        #region AnswerCall
        public delegate void AnswerCallHandler(InCallEventArgs eventArgs);
        public event AnswerCallHandler AnswerCallEvent;
        #endregion

        //Событие завершения вызова
        public delegate void EndCallHandler(int number);

        public event EndCallHandler EndCallEvent;

        //Событие подключения порта
        public delegate void ConnectPortHandler(PortInfo portInfo);

        public event ConnectPortHandler ConnectPortEvent;

        //Событие отключения порта
        public delegate void DisconnectPortHandler(PortInfo portInfo);

        public event DisconnectPortHandler DisconnectPortEvent;

        public Terminal(int terminalNumber)
        {
            TerminalNumber = terminalNumber;
            Port = new Port();
        }

        public void ConnectPort()
        {
            Port.Connect();
            ConnectPortEvent?.Invoke(new PortInfo(TerminalNumber, Port.GetPortNumber(), Port.GetPortState(), DateTime.Now));
        }

        public void DisconnectPort()
        {
            Port.Disconnect();
            DisconnectPortEvent?.Invoke(new PortInfo(TerminalNumber, Port.GetPortNumber(), Port.GetPortState(), DateTime.Now));
        }

        public void OutCall(int opponentNumber)
        {
            if (TerminalNumber != opponentNumber && Port.GetPortState() == PortState.Free)
            {
                Port.Call();
                OutCallEvent?.Invoke(new OutCallEventArgs(TerminalNumber, opponentNumber));
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
                AnswerCallEvent?.Invoke(new InCallEventArgs(TerminalNumber));
            }
        }

        public void EndCall()
        {
            if (Port.GetPortState() == PortState.Busy)
            {
                Port.EndCall();
                EndCallEvent?.Invoke(TerminalNumber);
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