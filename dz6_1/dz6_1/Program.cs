using System;
using System.Collections.Generic;

namespace dz6_1
{
    class Program
    {
        private delegate void MyDelegate();

        static void Main(string[] args)
        {
            Circle cr = new Circle(5);
            List<MyDelegate> listMyDelegate = new List<MyDelegate>();
            listMyDelegate.Add(cr.PrintRadius);
            listMyDelegate.Add(cr.PrintDiametr);
            listMyDelegate.Add(cr.PrintLength);
            foreach(MyDelegate myDelegate in listMyDelegate)
            {
                myDelegate();
            }
        }
    }
}
