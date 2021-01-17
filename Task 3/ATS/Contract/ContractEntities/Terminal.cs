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

        #region EndCall

        public delegate void EndCallHandler(int number);

        public event EndCallHandler EndCallEvent;

        #endregion

        public Terminal(int terminalNumber)
        {
            TerminalNumber = terminalNumber;
            Port = new Port();
            Port.DisconnectPortEvent += DisconnectPortHandler;
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

        private void DisconnectPortHandler(PortRecord portRecord)
        {
            if (Port.GetPortState() == PortState.Busy)
            {
                EndCall();
            }
        }
    }
}