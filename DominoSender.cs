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
        public Domino Domino { get; set; }
        public DominoSendingState State { get; set; }
        public DominoSender(Domino Domino, DominoSendingState State)
        {
            this.Domino = Domino;
            this.State = State;
        }
        public string Serialize()
        {
            XMLSerializer<DominoSender> xml = new XMLSerializer<DominoSender>();
            return xml.Write(this);
        }
    }
}
