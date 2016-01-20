using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace dz7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Чистим файл от xml тегов");
            string path = "..//..//..//Cars.xml";
            Console.WriteLine(Path.GetFullPath(path));
            // Console.WriteLine("Введите путь к xml файлу");
            // string path = Console.ReadLine();

            if (File.Exists(path))
            {
                string pathWrite = Path.GetDirectoryName(path) + "\\" + 
                     Path.GetFileNameWithoutExtension(path) + "Write.txt";
                Console.WriteLine("Обработанный файл: " + Path.GetFullPath(pathWrite));

                // пишем результат
                FileStream fsWriter = new FileStream(
                    pathWrite,
                    FileMode.Create,
                    FileAccess.ReadWrite,
                    FileShare.None
                );
                StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
                StreamReader sr = new StreamReader(path, Encoding.UTF8);
                string readText;
                // обрабатываем построчно
                while (!sr.EndOfStream) 
                {
                    readText = sr.ReadLine();
                    // вычищаем теги xml
                    foreach (Match match in Regex.Matches(readText, @".*?>(.*)</",
                        RegexOptions.IgnoreCase))
                    {
                        //Console.WriteLine(match.Value);
                        //Console.WriteLine(match.Groups[1].Value);
                        sw.Write(match.Groups[1].Value + "\r\n");
                    }
                }
                sw.Dispose();
                sr.Dispose();
            }
            else
            {
                Console.WriteLine("Файл {0} не обнаружен", path);
            }
        }
    }
}
