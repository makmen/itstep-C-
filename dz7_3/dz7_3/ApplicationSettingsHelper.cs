using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace dz7_3
{
    class ApplicationSettingsHelper
    {
        private string path;

        public ApplicationSettingsHelper()
        {
            // ищем файл если его нет создаем по умолчанию
            path = "..//..//..//config.txt";
            if (!File.Exists(path))
            {
                // создать его
                File.Create(path);
            }
        }

        // читаем файл
        public void ReadInFile()
        {
            string readText;
            byte[] readBytes;
            // работа с байтами
            using (FileStream fs = new FileStream(
                    path,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read
                    )
                )
            {
                fs.Seek(0, SeekOrigin.Begin);
                readBytes = new byte[(int)fs.Length];
                fs.Read(readBytes, 0, readBytes.Length);
                readText = Encoding.UTF8.GetString(readBytes);
                Console.WriteLine(readText);
                fs.Close();
            }
        }

        public void WriteInFile()
        {
            string readText, writeText;
            Console.WriteLine("Введите цвет консоли: ");
            readText = Console.ReadLine();
            writeText = "Цвет консоли: " + readText + "\r\n";

            Console.WriteLine("Введите размер окна: ");
            readText = Console.ReadLine();
            writeText += "Размер окна: " + readText + "\r\n";

            Console.WriteLine("Введите заголовок окна: ");
            readText = Console.ReadLine();
            writeText += "Заголовок окна: " + readText + "\r\n";

            using (FileStream fs = new FileStream(
                    path,
                    FileMode.Create,
                    FileAccess.Write,
                    FileShare.Write
                    )
                )
            {
                fs.Seek(0, SeekOrigin.Begin);
                byte[] writeBytes = Encoding.UTF8.GetBytes(writeText);
                fs.Write(writeBytes, 0, writeBytes.Length);
                fs.Flush();
                fs.Close();
            }
        }
    }
}
