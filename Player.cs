using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    class Player
    {
        public List<Domino> List { get; private set; }
        public List<System.Windows.Forms.PictureBox> PictureBoxList { get; private set; }
        public Player(int height)
        {
           List = new List<Domino>();
           PictureBoxList = new List<System.Windows.Forms.PictureBox>();
           for (int i = 0; i < 6; i++)
           { 
                List.Add(UsedDomino.RandomFree());
                System.Windows.Forms.PictureBox pbox = new System.Windows.Forms.PictureBox();
                pbox.Size = new System.Drawing.Size(28, 56);
                pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                if (i == 0)
                    pbox.Location = new System.Drawing.Point(20, height);
                else pbox.Location = new System.Drawing.Point(Domino.Size.Width + PictureBoxList[i - 1].Location.X + 20, height);
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.CounterClockWise(List[i].Image);
                PictureBoxList.Add(pbox);
           }
        }
        public void Move(Domino domino)
        {
            List.Remove(domino);
        }
        public Domino GiveFromTheYard()
        {
            Domino result = UsedDomino.RandomFree();
            List.Add(result);
            System.Windows.Forms.PictureBox box = new System.Windows.Forms.PictureBox();
            box.Image = result.Image;
            PictureBoxList.Add(box);           
            return result;
        }
        public int DominoCount { get { return List.Count; } }
    }
}
