using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    [Serializable]
    public class DominoSender
    {
        public Domino Domino { get; }
        public DominoSendingState State { get; }
        public DominoSender(Domino Domino, DominoSendingState State)
        {
            this.Domino = Domino;
            this.State = State;
        }
        public DominoSender(byte[] bytes)
        {
            Domino = new Domino(bytes[0], bytes[1]);
            State = (DominoSendingState)bytes[2];
        }
        public byte[] Bytes()
        {
            return new byte[] { Domino.First, Domino.Second, (byte)State };
        } 
    }
}
