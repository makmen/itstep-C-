using System;
using System.Collections.Generic;

namespace dz6_4
{
    public class Point2D<T>
    {
        protected T X { get; set; }
        protected T Y { get; set; }

        public Point2D()
        {
            X = default(T);
            Y = default(T);
        }

        public Point2D(T X_, T Y_)
        {
            X = X_;
            Y = Y_;
        }

        public new void ToString()
        {
            Console.WriteLine("X = {0}, Y = {1}", X, Y);
        }
    }
}
