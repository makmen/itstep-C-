using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace dz8
{
    static class GetData
    {
       
        public static int GetInt()
        {
            int res;
            while (true)
            {
                try
                {
                    res = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Недопустимый ввод. Введите число типа integer");
                }
            }

            return res;
        }

        public static bool GetChoiceYesNo(string question)
        {
            string strTemp;
            bool res = false;
            Console.WriteLine("{0} Нажмите y/n?", question);
            while (true)
            {
                strTemp = Console.ReadLine();
                if ( (strTemp == "y") || (strTemp == "Y") )
                {
                    res = true;
                    break;
                }
                else if ((strTemp == "n") || (strTemp == "N")) 
                {
                    res = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Нажмите y/n?");
                }
            }

            return res;
        }

        public static string GetPath()
        {
            string res;
            while (true)
            {
                res = Console.ReadLine();
                if (Directory.Exists(res))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Недопустимый ввод. Папка {0} не существует", res);
                }
            }

            return res;
        }

        public static DateTime GetDate()
        {
            DateTime res;
            while (true)
            {
                try
                {
                    res = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Недопустимый ввод. Введите дату в формате xx.xx.xxxx");
                }
            }

            return res;
        }

        public static double GetDouble()
        {
            double res;
            while (true)
            {
                try
                {
                    res = double.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Недопустимый ввод. Введите число типа double");
                }
            }

            return res;
        }
    }
}
