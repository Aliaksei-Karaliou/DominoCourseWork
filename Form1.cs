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
        private GameType type;
        List<PictureBox> player1PictureBox = new List<PictureBox>();
        List<PictureBox> player2PictureBox = new List<PictureBox>();
        List<PictureBox> table = new List<PictureBox>();
        Player player1 = new Player(), player2 = new Player();
        Point rightPoint, leftPoint;
        new byte Right = 7, Left = 7;
        byte downCount = 0, upCount = 0;
        int vertRY = 273, vertLY = 273;

        public Form1(GameType type)
        {
            InitializeComponent();
            if (type!=GameType.Local)
                ServerActions();
            this.type = type;
            Text = type.ToString();
            NewRound();
        }

        private void ServerActions()
        {
            Player buf = player1;
            player1 = player2;
            player2 = buf;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            //(this as Form).Text = e.X + ";" + e.Y;
        }
        private void NewRound()
        {
            foreach (PictureBox pbox in table)
                Controls.Remove(pbox);
            foreach (PictureBox pbox in player1PictureBox)
                Controls.Remove(pbox);
            foreach (PictureBox pbox in player2PictureBox)
                Controls.Remove(pbox);
            player1PictureBox.Clear();
            player2PictureBox.Clear();
            table.Clear();
            rightPoint = new Point(0, 0);
            leftPoint = rightPoint;
            Right = 7;
            Left = 7;
            downCount = 0;
            upCount = 0;
            vertRY = 273;
            vertLY = 273;
            Buffer.UsedDomino=new UsedDomino();
            Dealt();

        }
        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pbox = sender as PictureBox;
            Domino domino = new Domino(pbox.Image);
            if (domino.Contains(Right) || domino.Contains(Left) || Right == 7)
            {
                table.Add(pbox);
                player1PictureBox.Remove(pbox);
                player1.List.Remove(domino);
                pbox.Click -= PictureBox_Click;
                if (Right == 7)
                    firstMove(domino, pbox);
                else if (domino.Contains(Right))
                    rightMove(domino, pbox);
                else if (domino.Contains(Left))
                    leftMove(domino, pbox);
                PCMove();
            }
            PullTogether(player1, 486);
            (this as Form).Text = player1.List.Count + "." + player2.List.Count;
            if (Win(player1))
            {
                int sum = 0;
                for (int i = 0; i < player2.List.Count; i++)
                    sum += player2.List[i].First + player2.List[i].Second;
                StaticForScores.Score1 += sum;
                ScoreLabel.Text = string.Format("{0}:{1}", StaticForScores.Score1, StaticForScores.Score2);
                if (StaticForScores.Score1 > 101)
                {
                    MessageBox.Show("Player Won the Game");
                    Application.Exit();
                }
                else MessageBox.Show("Player Won");
                NewRound();
            }
            else if (Draw(player1, player2))
            {
                int sum1 = 0;
                for (int i = 0; i < player1.List.Count; i++)
                    sum1 += player1.List[i].First + player1.List[i].Second;
                StaticForScores.Score2 += sum1;
                int sum2 = 0;
                for (int i = 0; i < player2.List.Count; i++)
                    sum2 += player2.List[i].First + player2.List[i].Second;
                StaticForScores.Score1 += sum2;
                ScoreLabel.Text = string.Format("{0}:{1}", StaticForScores.Score1 + sum1 > sum2 ? sum1 - sum2 : 0, StaticForScores.Score2 + sum1 < sum2 ? sum2 - sum1 : 0);
                MessageBox.Show("Draw");
                NewRound();
            }
        }

        private void PCMove()
        {
            ImageRotator rotator = new ImageRotator();
            bool move = false;
            for (int i = 0; i < player2.List.Count; i++)
            {
                if (player2.List[i].Contains(Right))
                {
                    table.Add(player2PictureBox[i]);
                    player2PictureBox[i].Image = player2.List[i].Image;
                    rightMove(player2.List[i], player2PictureBox[i]);
                    player2PictureBox.RemoveAt(i);
                    player2.List.RemoveAt(i);
                    move = true;
                    break;
                }
                else if (player2.List[i].Contains(Left))
                {
                    table.Add(player2PictureBox[i]);
                    player2PictureBox[i].Image = player2.List[i].Image;
                    leftMove(player2.List[i], player2PictureBox[i]);
                    player2PictureBox.RemoveAt(i);
                    player2.List.RemoveAt(i);
                    move = true;
                    break;
                }
                else if (Right + Left == 14)
                {
                    table.Add(player2PictureBox[i]);
                    player2PictureBox[0].Image = rotator.CounterClockWise(player2.List[0].Image);
                    firstMove(player2.List[0], player2PictureBox[0]);
                    player2PictureBox.RemoveAt(0);
                    player2.List.RemoveAt(0);
                    move = true;
                    break;
                }
            }
            if (!move)
            {
                if (!Yard(player2, 20))
                    goto final;
                PCMove();
            }
            if (Win(player2))
            {
                int sum = 0;
                for (int i = 0; i < player1.List.Count; i++)
                    sum += player1.List[i].First + player1.List[i].Second;
                StaticForScores.Score2 += sum;
                ScoreLabel.Text = string.Format("{0}:{1}", StaticForScores.Score1, StaticForScores.Score2);
                MessageBox.Show("PC Won");
                NewRound();
                PCMove();
            }
            else if (Draw(player1, player2))
            {
                int sum1 = 0;
                for (int i = 0; i < player1.List.Count; i++)
                    sum1 += player1.List[i].First + player1.List[i].Second;
                StaticForScores.Score2 += sum1;
                int sum2 = 0;
                for (int i = 0; i < player2.List.Count; i++)
                    sum2 += player2.List[i].First + player2.List[i].Second;
                StaticForScores.Score1 += sum2;
                ScoreLabel.Text = string.Format("{0}:{1}", StaticForScores.Score1 + (sum1 < sum2 ? sum2 - sum1 : 0), StaticForScores.Score2 + (sum1 > sum2 ? sum1 - sum2 : 0));
                MessageBox.Show("Draw");
                NewRound();
            }
            final:
            PullTogether(player2, 20);
            (this as Form).Text = player1.List.Count + "." + player2.List.Count;
        }

        private void yardButton_Click(object sender, EventArgs e)
        {
            Yard(player1, 486);
        }
        private bool Yard(Player player, int locY)
        {
            List<PictureBox> list = PlayerToPictureBoxList(player);
            if (Buffer.UsedDomino.Free > 0)
            {
                player.GiveFromTheYard();
                PictureBox pbox = PictureBoxCreator(player.List[player.List.Count - 1].Image, new Point(0, 0));
                Controls.Add(pbox);
                list.Add(pbox);
                PullTogether(player, locY);
                if (player.Equals(player1))
                {
                    pbox.Click += PictureBox_Click;
                }
                else
                {
                    pbox.Image = Properties.Resources.back;
                }
                return true;
            }
            else
            {
                MessageBox.Show("There is no dominos in the yard!");
                Skip.Visible = true;
            }
            if (player.Equals(player1))
            {
                PCMove();
            }
            return false;
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
            pbox.Size = pbox.Image.Size;
            label2.Text += '\n' + pbox.Location.ToString() + '-' + pbox.Size.ToString() + '-' + domino.ToString();
        }

        private void rightMove(Domino domino, PictureBox pbox)
        {
            ImageRotator rotator = new ImageRotator();
            pbox.Location = rightPoint;
            if (domino.First != domino.Second)
            {
                pbox.Image = rotator.ClockWise(pbox.Image);
                pbox.Location = new Point(pbox.Location.X, vertRY);
                if (domino.First != Right)
                    pbox.Image = rotator.HalfCircle(pbox.Image);
            }
            else
            {
                pbox.Location = new Point(pbox.Location.X, vertRY - 11);
                rotator.ClockWise(pbox.Image);
            }
            Right = (byte)(domino.First + domino.Second - Right);
            if (rightPoint.X > 700 && (downCount > 1 || domino.First != domino.Second) && downCount <= 2)
            {
                if (domino.First == domino.Second)
                {
                    pbox.Image = rotator.ClockWise(pbox.Image);
                    pbox.Location = new Point(pbox.Location.X - 11, pbox.Location.Y);
                    rotator.ClockWise(pbox.Image);
                }
                else pbox.Image = rotator.CounterClockWise(pbox.Image);
                rightPoint = new Point(domino.First == domino.Second ? rightPoint.X - 11 : rightPoint.X, vertRY);
                vertRY += pbox.Size.Height + 3;
                pbox.Location = rightPoint;
                downCount++;

            }
            else if (downCount > 2)
            {
                rightPoint = new Point(rightPoint.X - pbox.Image.Width - 3, vertRY - 11);
                pbox.Image = rotator.HalfCircle(pbox.Image);
                pbox.Location = rightPoint;
                if (domino.First == domino.Second)
                    pbox.Location = new Point(pbox.Location.X, pbox.Location.Y - 11);
            }
            else rightPoint = new Point(rightPoint.X + pbox.Image.Width + 3, vertRY);
            // (this as Form).Text = downCount.ToString();
            pbox.Size = pbox.Image.Size;
            label2.Text += '\n' + pbox.Location.ToString() + '-' + pbox.Size.ToString() + '-' + domino.ToString();
        }

        private void leftMove(Domino domino, PictureBox pbox)
        {
            ImageRotator rotator = new ImageRotator();
            if (domino.First != domino.Second)
            {
                pbox.Image = rotator.ClockWise(pbox.Image);
                leftPoint = new Point(leftPoint.X, vertLY);
                if (domino.Second != Left)
                    pbox.Image = rotator.HalfCircle(pbox.Image);
            }
            else
            {
                leftPoint = new Point(leftPoint.X, vertLY - 11);
              //  rotator.ClockWise(pbox.Image);
            }
            if (leftPoint.X < 100 && (upCount > 0 || domino.First != domino.Second) && upCount <= 2)
            {
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
            else if (leftPoint.X < 300 && upCount <= 2 && upCount > 0)
            {
                //vertLY -= 3;
                pbox.Location = new Point(domino.First == domino.Second ? leftPoint.X - 25 : leftPoint.X, vertLY);
                leftPoint = new Point(leftPoint.X, leftPoint.Y - 3);
                if (domino.First == domino.Second)
                    pbox.Location = new Point(pbox.Location.X, pbox.Location.Y - 11);
            }
            else if (upCount > 2)
            {
                pbox.Image = rotator.HalfCircle(pbox.Image);
                pbox.Location = leftPoint;
                leftPoint = new Point(leftPoint.X + pbox.Width + 3, vertLY - 22);
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

        private void Skip_Click(object sender, EventArgs e)
        {
            PCMove();
        }

        public void hover(object obj, EventArgs e)
        {
            //(this as Form).Text = new Domino((obj as PictureBox).Image).ToString();
        }
        public void Dealt()
        {
            if (type != GameType.Client)
            {
                Player player1 = new Player();
                Player player2 = new Player();
            }
            else
            {
                List<Domino> List = new List<Domino>();
                for (int i = 0; i < 12; i++)
                {
                    byte[] buf = TcpSender.Read();
                    Domino domino = new Domino(buf[0], buf[1]);
                    List.Add(domino);
                    if (i == 5)
                    {
                        player2 = new Player(List);
                        List.Clear();
                    }
                }
                player1 = new Player(List);
                List.Clear();
            }
            for (int i = 0; i < 6; i++)
            {
                Point point;
                if (i == 0)
                    point = new Point(20, 486);
                else point = new Point(Domino.Size.Width + player1PictureBox[i - 1].Location.X + 20, 486);
                ImageRotator rotator = new ImageRotator();
                PictureBox pbox1 = PictureBoxCreator(player1.List[i].Image, point);
                DominoSender sender = new DominoSender(player1.List[i], DominoSendingState.Start);
                player1PictureBox.Add(pbox1);
                Controls.Add(pbox1);
                pbox1.Click += PictureBox_Click;
                DominoSender dsender = new DominoSender(player1.List[i], DominoSendingState.Start);
                if (type == GameType.Server)
                        TcpSender.Send(dsender.Bytes());
                }
            for (int i = 0; i < 6; i++)
                {
                Point point;
                if (i == 0)
                    point = new Point(20, 20);
                else point = new Point(Domino.Size.Width + player2PictureBox[i - 1].Location.X + 20, 20);
                //PictureBox pbox2 = PictureBoxCreator(Properties.Resources.back, point);
                PictureBox pbox2 = PictureBoxCreator(player2.List[i].Image, point);
                player2PictureBox.Add(pbox2);
                Controls.Add(pbox2);
                DominoSender dsender = new DominoSender(player2.List[i], DominoSendingState.Start);
                if (type == GameType.Server)
                    TcpSender.Send(dsender.Bytes());
            }
        }
        private void PullTogether(Player player, int yLoc)
        {
            List<PictureBox> list = PlayerToPictureBoxList(player);
            if (list.Count > 0)
            {
                list[0].Location = new Point(20, yLoc);
                for (int i = 1; i < list.Count; i++)
                    list[i].Location = new Point(list[i-1].Location.X + 42, yLoc);
            }
        }
        private bool Win(Player player)
        {
            return player.List.Count == 0;
        }
        private bool Draw(Player player1, Player player2)
        {
            for (int i = 0; i < player1.List.Count; i++)
                if (player1.List[i].ContainsAny(Left, Right))
                    return false;
            for (int i = 0; i < player2.List.Count; i++)
                if (player2.List[i].ContainsAny(Left, Right))
                    return false;
            if (Buffer.UsedDomino.Free > 0)
                return false;
            return true;
        }
        private List<PictureBox> PlayerToPictureBoxList(Player player)
        {
            return player.Equals(player1) ? player1PictureBox : player2PictureBox;
        }
        private PictureBox PictureBoxCreator(Image image, Point point)
        {
            PictureBox pbox = new PictureBox();
            pbox.Size = new Size(22, 44);
            pbox.SizeMode = PictureBoxSizeMode.Zoom;
            pbox.Location = point;
            pbox.Image = image;
            return pbox;
        }
    }
}