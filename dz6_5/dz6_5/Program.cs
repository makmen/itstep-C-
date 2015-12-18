using System;
using System.Collections.Generic;

namespace dz6_5
{
    class Program
    {
        static void Main(string[] args)
        {
            straight<int> str = new straight<int>(10, 15, 11, 14);
            str.ToString();
            straight<int> str1 = new straight<int>(new Point2D<int>(12, 16), new Point2D<int>(8, 11));
            str1.ToString();
        }
    }
}
