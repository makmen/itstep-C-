using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz6_5
{
    class straight<T>
    {
        private Point2D<T> dotX;
        private Point2D<T> dotY;

        public straight(T x1, T y1, T x2, T y2)
        {
            dotX = new Point2D<T>(x1, y1);
            dotY = new Point2D<T>(x2, y2);
        }

        public straight(Point2D<T> dotX_, Point2D<T> dotY_)
        {
            dotX = dotX_;
            dotY = dotY_;
        }
        
        public new void ToString()
        {
            dotX.ToString();
            dotY.ToString();
            Separator();
        }

        public void Separator()
        {
            string separator = "*";
            separator = separator.PadLeft(33, '*') + separator.PadRight(33, '*');
            Console.WriteLine(separator);
        }
    }
}
