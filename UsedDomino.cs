using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    static class UsedDomino
    {
        private static List<Domino> freeDomino = new List<Domino>(new Domino[]
        {
            new Domino(0),
            new Domino(1),
            new Domino(2),
            new Domino(3),
            new Domino(4),
            new Domino(5),
            new Domino(6),
            new Domino(7),
            new Domino(8),
            new Domino(9),
            new Domino(10),
            new Domino(11),
            new Domino(12),
            new Domino(13),
            new Domino(14),
            new Domino(15),
            new Domino(16),
            new Domino(17),
            new Domino(18),
            new Domino(19),
            new Domino(20),
            new Domino(21),
            new Domino(22),
            new Domino(23),
            new Domino(24),
            new Domino(25),
            new Domino(26),
            new Domino(27)
        });
        public static Domino RandomFree()
        {
            Random rand = new Random();
            byte num = Convert.ToByte(rand.Next(0, freeDomino.Count));
            Domino result = freeDomino[num];
            freeDomino.RemoveAt(num);
            return result;
        }
        public static void Default()
        {
            freeDomino = new List<Domino>(new Domino[]
        {
            new Domino(0),
            new Domino(1),
            new Domino(2),
            new Domino(3),
            new Domino(4),
            new Domino(5),
            new Domino(6),
            new Domino(7),
            new Domino(8),
            new Domino(9),
            new Domino(10),
            new Domino(11),
            new Domino(12),
            new Domino(13),
            new Domino(14),
            new Domino(15),
            new Domino(16),
            new Domino(17),
            new Domino(18),
            new Domino(19),
            new Domino(20),
            new Domino(21),
            new Domino(22),
            new Domino(23),
            new Domino(24),
            new Domino(25),
            new Domino(26),
            new Domino(27)
        });
        }
        public static int Free { get { return freeDomino.Count; } }
    }
}
