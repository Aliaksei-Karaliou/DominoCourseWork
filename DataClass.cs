using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    [Serializable]
    public class DataClass
    {
        public Player player1;
        public Player player2;

        public UsedDomino UsedDomino;
        // public StaticForScores Score;
        public DataClass() { }

    }
}
