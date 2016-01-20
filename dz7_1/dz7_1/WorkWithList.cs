using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace dz7_1
{
    class WorkWithList
    {
        Search srch;

        public WorkWithList(Search srch_)
        {
            srch = srch_;
        }

        public void AdditionalOperation()
        {
            List<string> workList = srch.SearchResults;
            ShowWorkingMenu();
            int menu;
            bool success = false;
            string path;
            for (int i = 0, count = workList.Count; i < count; ++i)
            {
                Console.WriteLine("Выберите операцию: {0}. {1}", i + 1, workList[i]);
                menu = GetData.GetInt();
                if (menu < 1 || menu > 5)
                {
                    Console.WriteLine("Введите цифру от 1 - 5");
                }
                else
                {
                    switch(menu)
                    {
                        case 1: // Удалить
                            success = DeleteFile(workList[i]);
                            if (success)
                            {
                                Console.WriteLine("Удаление завершено успешно {0}", workList[i]);
                            }
                            break;
                        case 2: // Переместить
                            Console.WriteLine("Введите путь для папки назначения");
                            path = GetData.GetPath();
                            // копируем файл в папку назначения
                            success = CopyFile(workList[i], path + "\\" + Path.GetFileName(workList[i]));
                            if (success)
                            {
                                success = DeleteFile(workList[i]);
                                if (success)
                                {
                                    Console.WriteLine("Перемещение завершено успешно {0} в папку {1}", workList[i], path);
                                }
                            }
                            break;
                        case 3: // Копировать
                            Console.WriteLine("Введите путь для папки назначения");
                            path = GetData.GetPath();
                            // копируем файл в папку назначения
                            success = CopyFile(workList[i], path + "\\" + Path.GetFileName(workList[i]));
                            if (success)
                            {
                                Console.WriteLine("Перемещение завершено успешно {0} в папку {1}", workList[i], path);
                            }
                            break;
                        case 4: // Замена в текстовых файлах
                            Console.WriteLine("Введите строку для замены");
                            string newString = Console.ReadLine();
                            string textContent = srch.ReadFile(workList[i]);
                            textContent = textContent.Replace(srch.NeedStringSearch, newString);
                            srch.WriteFile(workList[i], textContent);
                            Console.WriteLine("Выполнено");
                            break;
                        default: // не трогаем файл
                            break;
                    }
                }
            }
        }

        public bool CopyFile(string tempStr, string dest)
        {
            bool done = false;
            if (Path.GetExtension(tempStr) != "") // если разрешение есть удаляем файл
            {
                File.Move(tempStr, dest);
                if (!File.Exists(tempStr))
                {
                    done = true;
                }
            }

            return done;
        }

        public bool DeleteFile(string tempStr)
        {
            bool done = false;
            // определяем файл или папка
            if (Path.GetExtension(tempStr) != "") // если разрешение есть удаляем файл
            {
                File.Delete(tempStr);
                if (!File.Exists(tempStr))
                {
                    done = true;
                }
            }

            return done;
        }

        public void ShowWorkingMenu()
        {
            Console.WriteLine("\nРабота с найденным списком");
            Console.WriteLine("Нажмите 1: Удалить");
            Console.WriteLine("Нажмите 2: Переместить");
            Console.WriteLine("Нажмите 3: Копировать");
            Console.WriteLine("Нажмите 4: Замена в текстовых файлах");
            Console.WriteLine("Нажмите 5: Продолжить");
        }
    }
}
