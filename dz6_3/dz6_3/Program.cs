using System;
using System.Collections.Generic;

namespace dz6_3
{
    class Program
    {
        public const string langRu = "RU";
        public const string langEn = "EN";

        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary");
            Console.WriteLine("Нажмите 1: Изменить язык перевода");
            Console.WriteLine("Нажмите 2: Перевод слова");
            Console.WriteLine("Нажмите 3: Выход");

            bool exit = false;
            // Добавляем слова в словарь
            MyDictionary md = new MyDictionary(langRu, langEn);
            md.FillDictionary();

            int menu;
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
                            Console.WriteLine("Изменить язык перевода");
                            Console.WriteLine(md.ChangeLanguage());
                            break;
                        case 2:
                            Console.WriteLine("Перевод слова");
                            Console.WriteLine(md.CurrentLanguageOption());
                            Console.Write("Ведите ваше слово: ");
                            string resultTranslate = md.TranslateWord(Console.ReadLine());
                            if (resultTranslate != "")
                            {
                                Console.WriteLine("Перевод: " + resultTranslate);
                            } 
                            else
                            {
                                Console.WriteLine("Нет такого слова");
                            }
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
