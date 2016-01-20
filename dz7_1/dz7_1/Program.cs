using System;
using System.Collections.Generic;


namespace dz7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Search srch = new Search();
            Console.WriteLine("Search");
            ShowMenu();
            int menu;
            bool exit = false;
            int countSuccess = 0;
            while (true)
            {
                menu = GetData.GetInt(); 
                if (menu < 1 || menu > 7)
                {
                    Console.WriteLine("Введите цифру от 1 - 7");
                }
                else
                {
                    switch (menu)
                    {
                        case 7:
                            exit = true;
                            break;
                        default:
                            srch.RemoveResults();
                            srch.SetFlagSearch(menu);
                            srch.BeginSearch();
                            countSuccess = srch.ShowResults();
                            // работаем с найденным списком
                            if (countSuccess > 0)
                            {
                                WorkWithList wList = new WorkWithList(srch);
                                wList.AdditionalOperation();
                                Console.WriteLine("\nВведите данные для нового поиска");
                                ShowMenu();
                            }
                            break;
                    }
                }
                if (exit)
                {
                    break;
                }
            }
        }

        static void ShowMenu()
        {
            Console.WriteLine("Нажмите 1: Поиск по имени");
            Console.WriteLine("Нажмите 2: Поиск по размеру");
            Console.WriteLine("Нажмите 3: Поиск по дате создания");
            Console.WriteLine("Нажмите 4: Поиск по дате доступа");
            Console.WriteLine("Нажмите 5: Поиск по дате модификации");
            Console.WriteLine("Нажмите 6: Поиск по содержимому");
            Console.WriteLine("Нажмите 7: Выход");
        }
    }
}
