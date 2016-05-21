using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp;
using System.Drawing;

namespace DominoCourseWork
{
    public class Domino:IEquatable<Domino>,ICloneable
    {
        public static Size Size
        {
            get
            {
               return new Size(22, 44);
            }
        }
        public Domino(byte First, byte Second)
        {
            if (First > Second) SwapClass.Swap(ref First, ref Second);

            if (First > 6) this.First = 6;
            else if (First < 0) this.First = 0;
            else this.First = First;

            if (Second > 6) this.Second = 6;
            else if (Second < 0) this.Second = 0;
            else this.Second = Second;
        }
        public Domino (byte ID)
        {
            //byte buf = 0;
            byte k = 7;
            while (ID > k - 1)
            {
                ID -= k--;
                First++;
            }
            Second = Convert.ToByte(First+ID);
        }
        public Domino(Image image)
        {
            byte First, Second;
            int whiteCount = 0;
            for (int i = 0; i < image.Size.Height / 2; i++)
                for (int j = 0; j < image.Size.Width / 2; j++)
                    if ((image as Bitmap).GetPixel(i, j).R + (image as Bitmap).GetPixel(i, j).G + (image as Bitmap).GetPixel(i, j).B > 382.5) whiteCount++;
            First = (byte)(whiteCount/6);
            whiteCount = 0;
            if (image.Height > image.Width)
            {
                for (int i = image.Size.Height / 2 + 1; i < image.Size.Height; i++)
                    for (int j = 0; j < image.Size.Width / 2; j++)
                        if ((image as Bitmap).GetPixel(j, i).R + (image as Bitmap).GetPixel(j, i).G + (image as Bitmap).GetPixel(j, i).B > 384) whiteCount++;
            }
            else
            {
                for (int i = 0; i < image.Size.Height / 2; i++)
                    for (int j = image.Size.Width / 2 + 1; j < image.Size.Width; j++)
                        if ((image as Bitmap).GetPixel(j, i).R + (image as Bitmap).GetPixel(j, i).G + (image as Bitmap).GetPixel(j, i).B > 384) whiteCount++;
            }
            Second = (byte)(whiteCount / 6);
            whiteCount = 0;
            if (First > Second) SwapClass.Swap(ref First, ref Second);
            this.First = First;
            this.Second = Second;
        }
        public byte ID
        {
            get
            {
                return Convert.ToByte(First * (6.5 - 0.5 * First) + Second);
            }
        }
        private byte first;
        public byte First
        {
            get
            {
                return first;
            }
            set
            {
                first=Math.Min(value, (byte)6);
            }
        }
        private byte second;
        public byte Second
        {
            get
            {
                return second;
            }
            set
            {
                second = Math.Min(value, (byte)6);
            }
        }
        public bool Contains(byte number)
        {
            if (number == First || number == Second) return true;
            return false;
        }

        public bool Equals(Domino other)
        {
            if ((other.First == Second && other.Second == First) || (other.First == First && other.Second == Second)) return true;
            return false;
        }
        public object Clone()
        {
            return new Domino(First, Second);
        }
        public Image Image()
        {
            Image[] images = new Image[] { Properties.Resources.domino0, Properties.Resources.domino1, Properties.Resources.domino2, Properties.Resources.domino3, Properties.Resources.domino4, Properties.Resources.domino5, Properties.Resources.domino6 };
            Bitmap image1 = new Bitmap(images[First], new Size(Size.Height / 2, Size.Height / 2));
            Bitmap image2 = new Bitmap(images[Second], new Size(Size.Height / 2, Size.Height / 2));
            Bitmap result = new Bitmap(Size.Height, Size.Height / 2);
            int half = result.Width / 2;
            for (int i = 0; i < result.Height; i++)
                for (int j = 0; j < result.Width; j++)
                {
                    Color pixel = new Color();
                    if (j < half) pixel = image1.GetPixel(j, i);
                    else if (j > half) pixel = image2.GetPixel(j - half, i);
                    else pixel = Color.White;
                    result.SetPixel(j, i, pixel);
                }
            return result;
        }
        public override string ToString()
        {
            return string.Format("({0};{1})", First, Second);
        }
        private static class ImageDominoCreator
        {
            private static Bitmap[] images = new Bitmap[]
            {
            new Bitmap(Properties.Resources.domino0),
            new Bitmap(Properties.Resources.domino1),
            new Bitmap(Properties.Resources.domino2),
            new Bitmap(Properties.Resources.domino3),
            new Bitmap(Properties.Resources.domino4),
            new Bitmap(Properties.Resources.domino5),
            new Bitmap(Properties.Resources.domino6),
            };
        }

        private byte WhitePoints(int num)
        {
            if (num == 0) return 0;
            if (num < 5) return 1;
            if (num < 13) return 2;
            if (num < 15) return 3;
            if (num < 23) return 4;
            if (num < 30) return 5;
            return 6;
        }
    }
}
