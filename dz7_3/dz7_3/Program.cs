using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace dz7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Побитовая запись настроек в файл");
            Console.WriteLine("Нажмите 1: Читать файл config.txt");
            Console.WriteLine("Нажмите 2: Записать в файл config.txt");
            Console.WriteLine("Нажмите 3: Выход");
            ApplicationSettingsHelper helper = new ApplicationSettingsHelper();
            int menu;
            bool exit = false;
            while (true)
            {
                menu = GetInt();
                if (menu < 1 || menu > 3)
                {
                    Console.WriteLine("Введите цифру от 1 - 3");
                }
                else
                {
                    switch (menu)
                    {
                        case 1:
                            Console.WriteLine("Читаем файл config.txt");
                            helper.ReadInFile();
                            break;
                        case 2:
                            Console.WriteLine("Пишем в файл config.txt");
                            helper.WriteInFile();
                            break;
                        case 3:
                            exit = true;
                            break;
                    }
                    if (exit)
                    {
                        break;
                    }
                }
            }
        }

        static int GetInt()
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

    }
}
