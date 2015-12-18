using System;
using System.Collections.Generic;

namespace dz6_1
{
    class Circle
    {
        public double radius;

        public Circle(double radius_)
        {
            radius = radius_;
        }

        public void PrintRadius()
        {
            Console.WriteLine("Радиус равен: {0}", radius);
        }

        public void PrintDiametr()
        {
            Console.WriteLine("Диаметр равен: {0}", 2 * radius);
        }

        public void PrintLength()
        {
            Console.WriteLine("Длина окружности: {0}", 2 * Math.PI * radius);
        }
    }
}
