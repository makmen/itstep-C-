using System;

namespace dz3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double A1, A2, B1,B2, C1, C2;
            Console.WriteLine("Метод решения для системы 2 линейных уравнений");
            A1 = getDouble("A1");
            A2 = getDouble("A2");
            B1 = getDouble("B1");
            B2 = getDouble("B2");
            C1 = getDouble("С1");
            C2 = getDouble("С2");

            double X, Y;
            Console.WriteLine("Система двух линейных уравнений вида:");
            if (B1 > 0)
            {
                Console.WriteLine("{0} * X + {1} * Y = {2}", A1, B1, C1);
            }
            else
            {
                Console.WriteLine("{0} * X - {1} * Y = {2}", A1, Math.Abs(B1), C1);
            }

            if (B2 > 0)
            {
                Console.WriteLine("{0} * X + {1} * Y = {2}", A2, B2, C2);
            }
            else
            {
                Console.WriteLine("{0} * X - {1} * Y = {2}", A2, Math.Abs(B2), C2);
            }

            if (linesystem(A1, A2, B1, B2, C1, C2, out X, out Y))
            {
                Console.WriteLine("Имеет решение! X = {0} Y = {1}", X, Y);
            }
        }

        static bool linesystem(double A1, double A2, double B1, double B2, double C1, double C2, out double X, out double Y)
        {
            X = 0; Y = 0;
            double k = 0;
            try
            {
                // решим с помощью методом сложения
                k = (-1) * A2 / A1;
                B1 = (B1* k) + B2;
                if ((B1 == 0) || (A2 == 0))
                {
                    throw new ArgumentOutOfRangeException("не имеет решений");
                }
                C1 = (C1 * k) + C2;
                Y = C1 / B1;
                X = (C2 - B2 * Y) / A2;
            }
            catch (ArgumentOutOfRangeException er)
            {
                Console.WriteLine(er.ParamName);
                return false;
            }

            return true;
        }

        static double getDouble(string str)
        {
            double temp;
            while (true)
            {
                Console.WriteLine("Введите коэффициет {0}:", str);
                try
                {
                    temp = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Недопустимый ввод коэффициета {0}", str);
                }
            }

            return temp;
        }
    }
}
