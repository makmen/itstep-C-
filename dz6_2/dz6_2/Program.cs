using System;
using System.Collections.Generic;

namespace dz6_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack st = new Stack();
            st.Push(10);
            st.Push(5);
            st.Push(2);
            st.Push(1);
            st.Show();
            st.Pop();
            st.Push(20);
            st.Pop();
            st.Show();
            int n = st.Top();
            Console.WriteLine("{0}", n);
        }
    }
}
