using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5_3
{


    class Program
    {
        public const int NEEDELEM = 2;

        public delegate bool GetNeedResult(int x);

        static void Main(string[] args)
        {
            Random r = new Random();
            int n = r.Next(10, 20);
            int[] arr = new int[n];
            GetNeedResult getNeedResult = new GetNeedResult(isNeedElem);
            fillArray(arr);
            if (searchFill(arr, getNeedResult))
            {
                Console.WriteLine("{0} присутствует в массиве", NEEDELEM);
            }
            else
            {
                Console.WriteLine("{0} отсутствует в массиве", NEEDELEM);
            }

            showArray(arr);
        }

        static void showArray(int[] arr)
        {
            Console.Out.NewLine = "";
            for (int i = 0, count = arr.Length; i < count; ++i)
            {
                Console.WriteLine("{0} ", arr[i]);
            }
            Console.WriteLine("\n");
            Console.Out.NewLine = "\r\n";
        }

        static bool searchFill(int[] arr, GetNeedResult getNeedResult)
        {
            for (int i = 0, count = arr.Length; i < count; ++i)
            {
                if (getNeedResult(arr[i]))
                {
                    return true;
                }
            }

            return false;
        }

        static bool isNeedElem(int x)
        {
            if (NEEDELEM == x)
            {
                return true;
            }

            return false;
        }

        static void fillArray(int[] arr)
        {
            Random r = new Random();
            for (int i = 0, count = arr.Length; i < count; ++i)
            {
                arr[i] = r.Next(-10, 10);
            }
        }
    }
}
