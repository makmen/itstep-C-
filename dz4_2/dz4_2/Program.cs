using System;
using System.Collections.Generic;

namespace dz4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> lShape = new List<Shape>();
            string separator = "*";
            separator = separator.PadLeft(33, '*') + separator.PadRight(33, '*');
            List<SimpleNAngel> sAngel = new List<SimpleNAngel>();
            // обычные фигуры
            try
            {
                lShape.Add(new Triangle(4, 10, 12));
                lShape.Add(new Foursquare(3));
                lShape.Add(new Rhombus(10, 30));
                lShape.Add(new Rectangle(5, 11));
                lShape.Add(new Parallelogram(10, 8, 30));
                lShape.Add(new Circle(2));
                lShape.Add(new Ellipse(1, 5));
            }
            catch(Exception err)
            {
                Console.WriteLine(err.Message);
                Console.WriteLine(separator);
            }
            // показываем площади обычных фигур
            foreach(Shape sh in lShape) 
            {
                sh.Show();
                sh.SquareShape();
                sh.PerimeterShape();
                Console.WriteLine(separator);
            }

            // многоугольники
            try
            {
                sAngel.Add(new SimpleNAngel(10, 6, 10, 3, 8));
                sAngel.Add(new SimpleNAngel(12, 5, 25, 4, 9));
                sAngel.Add(new SimpleNAngel(9, 5, 20, 6, 7));
                sAngel.Add(new SimpleNAngel(9, 4, 20, 6, 7));
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                Console.WriteLine(separator);
            }
            CompositeShape cs = new CompositeShape();
            // показываем площади многоугольников
            foreach (SimpleNAngel sa  in sAngel)
            {
                sa.Show();
                Console.WriteLine("Площадь многоугольника: {0}", sa.SquareShape());
                Console.WriteLine("Периметр многоугольника: {0}", sa.PerimeterShape());
                Console.WriteLine(separator);
                cs.AddSimplePolygon(sa);
            }
            // показываем площади составных фигур
            Console.WriteLine("Площадь составной фигуры: {0}", cs.SquareShape());
            Console.WriteLine("Периметр составной фигуры: {0}", cs.PerimeterShape());
        }
    }

    class CompositeShape
    {
        private List<SimpleNAngel> compShape = new List<SimpleNAngel>();

        public void AddSimplePolygon(SimpleNAngel obj)
        {
            compShape.Add(obj);
        }

        public double SquareShape()
        {
            double square = 0;
            foreach (SimpleNAngel li in compShape)
            {
                square += li.SquareShape();
            }

            return square;
        }

        public double PerimeterShape()
        {
            double perimeter = 0;
            foreach (SimpleNAngel li in compShape)
            {
                perimeter += li.PerimeterShape();
            }

            return perimeter;
        }
    }

    class SimpleNAngel : I_SimplePolygon
    {
        private double height;
        private double basePolygon;
        private double angel;
        private int sidesNum;
        private double lengthSide;
        private string name;

        public SimpleNAngel(double height_, double basePolygon_, double angel_, int sidesNum_, double lengthSide_)
        {
            height = height_;
            basePolygon = basePolygon_;
            angel = angel_;
            sidesNum = sidesNum_;
            lengthSide = lengthSide_;
            name = "Многоугольник";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }

        public bool CheckData(out string str)
        {
            if (height <= 0 || basePolygon <= 0 || lengthSide <= 0 || sidesNum <= 0)
            {
                str = "Введены не верные значения сторон";

                return false;
            }
            else if (angel <= 0 || angel >= 180)
            {
                str = "Введены не верные значения угла";

                return false;
            }

            str = name + " создан";

            return true;
        }

        public void Show()
        {
            Console.WriteLine("Многоугольник\n\rВысота: {0}, Основание: {1}, Угол: {2}, Количество сторон: {3}, Длина сторон: {4}", height, basePolygon, angel, sidesNum, lengthSide);
        }

        public double SquareShape()
        {
            return ((double)sidesNum / 4) * (lengthSide * lengthSide) * (1 / Math.Tan(Math.PI / sidesNum));
        }

        public double PerimeterShape()
        {
            return lengthSide * sidesNum;
        }

        public double Height
        {
            get { return height; }
            set { height = value; }
        }

        public double BasePolygon
        {
            get { return basePolygon; }
            set { basePolygon = value; }
        }

        public double Angel
        {
            get { return angel; }
            set { angel = value; }
        }
        public int SidesNum
        {
            get { return sidesNum; }
            set { sidesNum = value; }
        }

        public double LengthSide
        {
            get { return lengthSide; }
            set { lengthSide = value; }
        }
    }

    public interface I_SimplePolygon
    {
        double Height { get; set; }

        double BasePolygon { get; set; }

        double Angel { get; set; }

        int SidesNum { get; set; }

        double LengthSide { get; set; }

        bool CheckData(out string str);

        void Show();

        double SquareShape();

        double PerimeterShape();
    }

    abstract class Shape
    {
        public virtual void Show()
        {

        }

        public virtual void SquareShape()
        {

        }

        public virtual void PerimeterShape()
        {

        }
    }

    class Triangle : Shape
    {
        private string name;
        private double A;
        private double B;
        private double C;

        public Triangle(double A_, double B_, double C_)
        {
            A = A_;
            B = B_;
            C = C_;
            name = "Треугольник";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }

        public bool CheckData(out string str)
        {
            if (A <= 0 || B <= 0 || C <= 0)
            {
                str = "Введены не верные длины сторон";

                return false;
            }
            else if (!CheckLengthTriangle()) 
            {
                str = "Существует пара сторон сумма длин которых меньше третьей";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public bool CheckLengthTriangle()
        {
            if (A + B < C)
            {
                return false;
            } 
            else if (A + C < B)
            {
                return false;
            }
            else if (B + C < A)
            {
                return false;
            }

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1}, {2}, {3})", name, A, B, C);
        }

        public override void SquareShape()
        {
            double p = (A + B + C) / (double)2;
            double S = p * (p - A) * (p - B) * (p - C);
            Console.WriteLine("Площадь треугольника: {0}", S);
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр треугольника: {0}", A + B + C);
        }
    }
    
    class Foursquare : Shape
    {
        private string name;
        private double A;

        public Foursquare(double A_)
        {
            A = A_;
            name = "Квадрат";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }
        public bool CheckData(out string str)
        {
            if (A <= 0)
            {
                str = "Введены не верные длины сторон";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1})", name, A);
        }

        public override void SquareShape()
        {
            Console.WriteLine("Площадь квадрата: {0}", A * A);
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр квадрата: {0}", A + A);
        }
    }

    class Rhombus : Shape
    {
        private string name;
        private double A;
        private double angle;

        public Rhombus(double A_, double angle_)
        {
            A = A_;
            angle = angle_;
            name = "Ромб";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }

        public bool CheckData(out string str)
        {
            if (A <= 0  )
            {
                str = "Введены не верные длины сторон";

                return false;
            }
            else if (angle <= 0 || angle >= 90)
            {
                str = "Введены не верные значения угла";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1}, угол: {2})", name, A, angle);
        }

        public override void SquareShape()
        {
            Console.WriteLine("Площадь ромба: {0}", A * A * Math.Sin(Math.PI * angle / 180));
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр ромба: {0}", A * 4);
        }
    }

    class Rectangle : Shape
    {
        private string name;
        private double A;
        private double B;

        public Rectangle(double A_, double B_)
        {
            A = A_;
            B = B_;
            name = "Прямоугольник";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }

        public bool CheckData(out string str)
        {
            if (A <= 0 || B <= 0)
            {
                str = "Введены не верные длины сторон";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1}, {2})", name, A, B);
        }

        public override void SquareShape()
        {
            Console.WriteLine("Площадь прямоугольника: {0}", A * B);
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр прямоугольника: {0}", A + B + A + B);
        }
    }

    class Parallelogram : Shape
    {
        private string name;
        private double A;
        private double B;
        private double angle;

        public Parallelogram(double A_, double B_, double angle_)
        {
            A = A_;
            B = B_;
            angle = angle_;
            name = "Параллелограмм";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }

        public bool CheckData(out string str)
        {
            if (A <= 0 || B <= 0)
            {
                str = "Введены не верные длины сторон";

                return false;
            }
            else if (angle <= 0 || angle >= 90)
            {
                str = "Введены не верные значения угла";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1}, {2}, угол: {3})", name, A, B, angle);
        }

        public override void SquareShape()
        {
            Console.WriteLine("Площадь параллелограмма: {0}", A * B * Math.Sin(Math.PI * angle / 180));
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр параллелограмма: {0}", A + B + A + B);
        }
    }

    class Circle : Shape
    {
        private string name;
        private double R;

        public Circle(double R_)
        {
            R = R_;
            name = "Круг";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }
        public bool CheckData(out string str)
        {
            if (R <= 0)
            {
                str = "Не верный радиус";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1})", name, R);
        }

        public override void SquareShape()
        {
            Console.WriteLine("Площадь круга: {0}", Math.PI * R * R);
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр круга: {0}", 2 * Math.PI * R);
        }
    }
    class Ellipse : Shape
    {
        private string name;
        private double R1;
        private double R2;
        public Ellipse(double R1_, double R2_)
        {
            R1 = R1_;
            R2 = R2_;
            name = "Эллипс";
            string str;
            bool error = CheckData(out str);
            if (!error)
            {
                Show();
                Console.WriteLine("{0} не создан", name);
                throw new Exception(str);
            }
        }

        public bool CheckData(out string str)
        {
            if (R1 <= 0 || R2 <= 0)
            {
                str = str = "Введены не верные значения радиусов";

                return false;
            }
            str = name + " создан";

            return true;
        }

        public override void Show()
        {
            Console.WriteLine("{0} ({1}, {2})", name, R1, R2);
        }

        public override void SquareShape()
        {
            Console.WriteLine("Площадь эллипса: {0}", Math.PI * 2 * R1 * 2 * R2);
        }
        public override void PerimeterShape()
        {
            Console.WriteLine("Периметр эллипса: {0}", 2 * Math.PI * Math.Sqrt((R1 * R1 + R2 * R2) / 2));
        }
    }
}
