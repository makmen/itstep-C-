using System;
using System.Collections.Generic;

namespace dz6_4
{

    public class Point3D : Point2D<int>
    {
        private int Z { get; set; }

        public Point3D() :
			base()
        {
            Z = default(int);
        }
        public Point3D(int x_, int y_, int z_) :
            base(x_, y_)
        {
            Z = z_;
        }

        public new void ToString()
        {
            Console.WriteLine("X = {0}, Y = {1}, Z = {2}", X, Y, Z);

        }
    }
}
