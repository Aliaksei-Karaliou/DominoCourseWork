using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    [Serializable]
    public class Player:IEquatable<Player>,ICloneable
    {
        public List<Domino> List { get; private set; }
        public Player()
        {
           List = new List<Domino>();
           List.Clear();
           for (int i = 0; i < 6; i++)
                List.Add(Buffer.UsedDomino.RandomFree());
        }
        public Player(List<Domino> List)
        {
            this.List = new List<Domino>(List);
        }
        public void Move(Domino domino)
        {
            List.Remove(domino);
        }
        public Domino GiveFromTheYard()
        {
            Domino result = Buffer.UsedDomino.RandomFree();
            List.Add(result);
            System.Windows.Forms.PictureBox box = new System.Windows.Forms.PictureBox();
            box.Image = result.Image;          
            return result;
        }

        public bool Equals(Player other)
        {
            return other.List.Equals(List);
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        public int DominoCount { get { return List.Count; } }
    }
}
