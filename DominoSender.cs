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
        public List<Domino> Array { get; }
        public DominoSendingState State { get; }
        public DominoSender(DominoSendingState State, params Domino[] Array)
        {
            this.State = State;
            this.Array = Array.ToList();
        }
        public DominoSender(byte[] bytes)
        {
            List<Domino> list = new List<Domino>();
            for (int i = 1; i < bytes.Length; i += 2)
                list.Add(new Domino(bytes[i], bytes[i + 1]));
            State = (DominoSendingState)bytes[0];
        }
        public DominoSender()
        {
            Array = new List<Domino>();
        }
        public byte[] Bytes()
        {
            List<byte> list = new List<byte>();
            list.Add((byte)State);
            foreach (Domino domino in Array)
            {
                list.Add(domino.First);
                list.Add(domino.Second);
            }
            return list.ToArray();       
        } 
    }
}
