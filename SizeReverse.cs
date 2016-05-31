using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoCourseWork
{
    static class SizeReverse
    {
        public static System.Drawing.Size Reverse(this System.Drawing.Size size)
        {
            return new System.Drawing.Size(size.Height, size.Width);
        }
    }
}
