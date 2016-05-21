using System;
using System.Drawing;

namespace DominoCourseWork
{
    class ImageRotator
    {
        public Image ClockWise(Image image)
        {
            Bitmap result = new Bitmap(image.Height, image.Width);
            for (int i = 0; i < result.Height; i++)
                for (int j = 0; j < result.Width; j++)
                    result.SetPixel(j, i, (image as Bitmap).GetPixel(image.Width - i - 1, j));
            return result;
        }
        public Image CounterClockWise(Image image)
        {
            Bitmap result = new Bitmap(image.Height, image.Width);
            for (int i = 0; i < result.Height; i++)
                for (int j = 0; j < result.Width; j++)
                    result.SetPixel(j, i, (image as Bitmap).GetPixel(i, image.Height - j - 1));
            return result;
        }
        public Image HalfCircle(Image image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < result.Height; i++)
                for (int j = 0; j < result.Width; j++)
                    result.SetPixel(j, i, (image as Bitmap).GetPixel(image.Width - j - 1, image.Height - i - 1));
            return result;
        }
    }
}
