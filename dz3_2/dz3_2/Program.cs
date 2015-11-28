using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            double A, B;
            string enter = "Введите коэффициент А и B через пробел";
            string readEnter; 
            while (true)
            {
                Console.WriteLine(enter);
                readEnter = Console.ReadLine();
                if (LinearEquation.parse(readEnter, out A, out B))
                {
                    break;
                }
            }
            LinearEquation lE = new LinearEquation(A, B);
            lE.ShowResult();
        }
    }

    class LinearEquation // A*X + B = 0
    {
        private double A;
        private double B;
        private double X;
        public LinearEquation(double A_, double B_)
        {
            A = A_;
            B = B_;
            X = (-1) * B / A;
        }

        public void ShowResult()
        {
            Console.WriteLine("Результат урванения {0} * X + {1} = 0, есть число {2}", A, B, X);
        }

        static public bool parse(string str, out double A, out double B)
        {
            A = B = 0;
            string[] stArray = str.Split(' ');
            if (stArray.Length > 2)
            {
                return false; 
            }

            try
            {
                A = double.Parse(stArray[0]);
                B = double.Parse(stArray[1]);
            }
            catch (FormatException)
            {
                Console.WriteLine("Недопустимый ввод коэффициетов");
                return false;
            }

            return true;
        }

        public double getA
        {
            get { return A; }
            set { A = value; }
        }

        public double getB
        {
            get { return B; }
            set { B = value; }
        }

        public double getX
        {
            get { return X; }
            set { X = value; }
        }
    }
}
