using System;
using System.Collections.Generic;

namespace dz6_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Point2D<int> dot2D = new Point2D<int>(10, 20);
            dot2D.ToString();
            Point3D dot3D = new Point3D(10, 20, 30);
            dot3D.ToString();
        }
    }
}
