using System;

namespace dz3_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fr = new Fraction(3, 4);
            fr.show();
            int a = 10;
            Fraction fr1 = a * fr;
            fr1.show();
            Fraction fr2 = fr * a;
            fr2.show();
            double da = 5.1;
            Fraction fr3 = fr + da;
            fr3.show();
            fr.isCorrectFraction();
            fr1.isCorrectFraction();
        }
    }

    class Fraction
    {
        private int numerator;
        private int denominator;

        public Fraction(int numerator_, int denominator_)
        {
            numerator = numerator_;
            denominator = denominator_;
        }

        public void isCorrectFraction()
        {
            if (this)
            {
                Console.WriteLine("Дробь {0} / {1} Правильная", numerator, denominator);
            }
            else
            {
                Console.WriteLine("Дробь {0} / {1} Неправильная", numerator, denominator);
            }
        }

        public void show()
        {
            Console.WriteLine("{0} / {1}", numerator, denominator);
        }

        public static Fraction operator +(Fraction obj, int a)
        {
            return new Fraction(a * obj.denominator + obj.numerator, obj.denominator);
        }

        public static Fraction operator +(Fraction obj, double a)
        {
            return new Fraction((int)(a * obj.denominator) + obj.numerator, obj.denominator);
        }

        public static Fraction operator *(Fraction obj, int a)
        {
            return new Fraction(a * obj.numerator, obj.denominator);
        }

        public static Fraction operator *(int a, Fraction obj)
        {
            return new Fraction(a * obj.numerator, obj.denominator);
        }

        public static bool operator true (Fraction obj)
        {
            return obj.denominator > obj.numerator;
        }

        public static bool operator false(Fraction obj)
        {
            return obj.denominator < obj.numerator;
        }

        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set { denominator = value; }
        }
    }
}
