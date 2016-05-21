using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DominoCourseWork
{
    public partial class Form1 : Form
    {
        bool againstPC = true;
        List<Domino> Field = new List<Domino>();
        Player player1 = new Player(486), player2 = new Player(20);
        Point rightPoint, leftPoint;
        byte Right = 7, Left = 7, downCount = 0, upCount = 0;
        int vertRY=273, vertLY=273;
        public Form1()
        {
            InitializeComponent();
            Dealt();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //(this as Form).Text = e.X + ";" + e.Y;
        }
        private void PictureBox_Click(object sender,EventArgs e)
        {
            PictureBox pbox = sender as PictureBox;
            Domino domino = new Domino(pbox.Image);
            if (domino.Contains(Right) || domino.Contains(Left) || Right == 7)
            {
                player2.PictureBoxList.Remove(pbox);
                player2.List.Remove(domino);
                (this as Form).Text = domino.ToString();
                pbox.Click -= PictureBox_Click;
                if (Right == 7)
                    firstMove(domino, pbox);
                else if (domino.Contains(Right))
                    rightMove(domino, pbox);
                else if (domino.Contains(Left))
                    leftMove(domino, pbox);           
            }
            PCMove();
            //PullTogether();
        }

        private void PCMove()
        {
            ImageRotator rotator = new ImageRotator();
            for (int i = 0; i < player2.List.Count; i++)
            {
                if (player2.List[i].Contains(Right))
                {
                    player2.PictureBoxList[i].Image = rotator.CounterClockWise(player2.List[i].Image());
                    rightMove(player2.List[i], player2.PictureBoxList[i]);
                    player2.PictureBoxList.RemoveAt(i);
                    player2.List.RemoveAt(i);
                    break;
                }
                else if (player2.List[i].Contains(Left))
                {
                    player2.PictureBoxList[i].Image = rotator.CounterClockWise(player2.List[i].Image());
                    leftMove(player2.List[i], player2.PictureBoxList[i]);
                    player2.PictureBoxList.RemoveAt(i);
                    player2.List.RemoveAt(i);
                    break;
                }
            }
           // PullTogether();
        }

        private void firstMove(Domino domino, PictureBox pbox)
        {
            pbox.Size = Domino.Size;
            pbox.Location = new Point(392 - pbox.Image.Width / 2, domino.First != domino.Second ? vertRY : 261);
            if (domino.First != domino.Second)
            {
                pbox.Size = pbox.Size.Reverse();
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.ClockWise(pbox.Image);
            }
            rightPoint = new Point(pbox.Location.X + pbox.Size.Width + 3, pbox.Location.Y);
            leftPoint = pbox.Location;
            Left = domino.First;
            Right = domino.Second;
            label2.Text += '\n' + pbox.Location.ToString() + '-' + pbox.Size.ToString() + '-' + domino.ToString();
        }

        private void rightMove(Domino domino, PictureBox pbox)
        {
            pbox.Location = rightPoint;
            if (domino.First != domino.Second)
            {
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.ClockWise(pbox.Image);
                pbox.Location = new Point(pbox.Location.X, vertRY);
                if (domino.First != Right)
                    pbox.Image = rotator.HalfCircle(pbox.Image);
            }
            else
                pbox.Location = new Point(pbox.Location.X, vertRY - 11);
            Right = (byte)(domino.First + domino.Second - Right);
            if (rightPoint.X > 450 && (downCount > 1 || domino.First != domino.Second) && downCount<=2)
            {
                ImageRotator rotator = new ImageRotator();
                if (domino.First == domino.Second)
                {
                    pbox.Image = rotator.ClockWise(pbox.Image);
                    pbox.Location = new Point(pbox.Location.X - 11, pbox.Location.Y);
                }
                else pbox.Image = rotator.CounterClockWise(pbox.Image);
                rightPoint = new Point(domino.First == domino.Second ? rightPoint.X - 11 : rightPoint.X, vertRY);
                vertRY += pbox.Size.Height + 3;
                pbox.Location = rightPoint;
                if (downCount == 0)
                    vertRY += 32;
                downCount++;

            }
            else if (downCount > 2)
            {
                rightPoint = new Point(rightPoint.X - pbox.Image.Width - 3, vertRY - 11);
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.HalfCircle(pbox.Image);
                pbox.Location = rightPoint;
                if (domino.First == domino.Second)
                    pbox.Location = new Point(pbox.Location.X, pbox.Location.Y - 11);
            }
            else rightPoint = new Point(rightPoint.X + pbox.Image.Width + 3, vertRY);
           (this as Form).Text = downCount.ToString();
            pbox.Size = pbox.Image.Size;
            label2.Text += '\n' + pbox.Location.ToString() + '-' + pbox.Size.ToString() + '-' + domino.ToString();
        }

        private void leftMove(Domino domino, PictureBox pbox)
        {
            if (domino.First != domino.Second)
            {
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.ClockWise(pbox.Image);
                leftPoint = new Point(leftPoint.X, vertLY);
                if (domino.Second != Left)
                    pbox.Image = rotator.HalfCircle(pbox.Image);
            }
            else
                leftPoint = new Point(leftPoint.X, vertLY - 11);
            if (leftPoint.X < 300 && (upCount > 0 || domino.First != domino.Second) && upCount <= 2)
            {
                ImageRotator rotator = new ImageRotator();
                pbox.Size = pbox.Size.Reverse();
                pbox.Image = rotator.CounterClockWise(pbox.Image);
                vertLY -= pbox.Size.Height + 3;
                leftPoint = new Point(domino.First == domino.Second ? leftPoint.X - 11 : leftPoint.X, vertLY);
                if (upCount == 0)
                    vertLY -= 32;
                upCount++;
                pbox.Location = leftPoint;
                if (upCount == 3)
                    leftPoint.X += 25;
                if (domino.First == domino.Second)
                {
                    pbox.Image = rotator.ClockWise(pbox.Image);
                    pbox.Location = new Point(pbox.Location.X - 11, pbox.Location.Y);
                }
                pbox.Size = pbox.Image.Size;
            }
            else if (leftPoint.X < 300 && upCount <= 2)
            {
                //vertLY -= 3;
                pbox.Location = new Point(domino.First == domino.Second ? leftPoint.X - 25 : leftPoint.X, vertLY);
                leftPoint = new Point(leftPoint.X - 22, leftPoint.Y - 3);
                if (domino.First == domino.Second)
                    pbox.Location = new Point(pbox.Location.X, pbox.Location.Y - 11);
            }
            else if (upCount > 2)
            {
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.HalfCircle(pbox.Image);
                pbox.Location = leftPoint;
                leftPoint = new Point(leftPoint.X + pbox.Width + 3, vertLY);
              /*  if (domino.First == domino.Second)
                    pbox.Location = new Point(pbox.Location.X, pbox.Location.Y - 11);*/
            }
            else
            {
                leftPoint = new Point(leftPoint.X - pbox.Image.Width - 3, leftPoint.Y);
                pbox.Location = leftPoint;
            }
            Left = (byte)(domino.First + domino.Second - Left);
            pbox.Size = pbox.Image.Size;
            label2.Text += '\n' + pbox.Location.ToString() + '-' + pbox.Size.ToString() + '-' + domino.ToString();
        }
        public void hover(object obj, EventArgs e)
        {
            //(this as Form).Text = new Domino((obj as PictureBox).Image).ToString();
        }
        public void Dealt()
        {
            foreach (PictureBox pbox in player1.PictureBoxList)
            {
                pbox.Size = Domino.Size;
                pbox.Click += PictureBox_Click;
                pbox.MouseHover += hover;
                Controls.Add(pbox);
            }
            foreach (PictureBox pbox in player2.PictureBoxList)
            {
                pbox.Size = Domino.Size;
                ImageRotator rotator = new ImageRotator();
                pbox.Image = rotator.HalfCircle(pbox.Image);
                Controls.Add(pbox);
            }
        }
        private void PullTogether()
        {
            ImageRotator rotator = new ImageRotator();
            int x1 = 20, x2 = x1;
            for (int i = 0; i < player1.DominoCount; i++)
            {
                player1.PictureBoxList[i].Image = rotator.CounterClockWise(player1.List[i].Image());
                PictureBox pbox = player1.PictureBoxList[i];
                if (i == 0)
                    pbox.Location = new Point(20, 486);
                else pbox.Location = new Point(Domino.Size.Width + player1.PictureBoxList[i - 1].Location.X + 20, 486);
            }
            for (int i = 0; i < player2.DominoCount; i++)
            {
                player2.PictureBoxList[i].Image = rotator.CounterClockWise(player2.List[i].Image());
                PictureBox pbox = player2.PictureBoxList[i];
                if (i == 0)
                    pbox.Location = new Point(20, 20);
                else pbox.Location = new Point(Domino.Size.Width + player1.PictureBoxList[i - 1].Location.X + 20, 20);
            }
        }
    }
}
