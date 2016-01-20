using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace dz7_1
{
    class Search
    {
        private string[] nameOperation;
        private string[] textExtensionContent;
        private int currentSearch;              // тип операции
        private string needStringSearch;        // что ищем по названию
        private DateTime needDateSearch;        // что ищем по дате 
        private double needSizeSearch;          // что ищем по размеру 
        private bool isDir;                     // если true ищем дирректорию, false ищем файл
        private string fromSearch;              // указываем параметр где искать, если пустой ищем на диске D
        private List<string> searchResults;     // будем хранить результаты поиска здесь  
        private SearchNeedDate delegSearchDate;
        public delegate void SearchNeedDate(string str, bool isDir);

        public string NeedStringSearch
        {
            get { return needStringSearch; }
        }

        public List<string> SearchResults
        {
            get { return searchResults; }
        }

        public Search()
        {
            nameOperation = new string[] { "Поиск по имени", "Поиск по размеру", "Поиск по дате создания", "Поиск по дате доступа", "Поиск по дате модификации", "Поиск по содержимому" };
            textExtensionContent = new string[] { ".txt", ".xml"};
            searchResults = new List<string>();
            isDir = false;
        }

        public void SetFlagSearch(int flag)
        {
            currentSearch = --flag;
        }

        public void BeginSearch()
        {
            Console.WriteLine(nameOperation[currentSearch]);
            // определяем необходимые данные для поиска
            Console.WriteLine("Где ищем? Укажите каталог");
            // fromSearch = Console.ReadLine();
            // fromSearch = "D:\\net\\AAA";
            fromSearch = GetData.GetPath();
            Console.WriteLine("__________________");
            
            switch (currentSearch) 
            {
                case 0:
                    Console.WriteLine("Введите ключевое слова для поиска");
                    needStringSearch = Console.ReadLine();
                    // needStringSearch = "222.jpg";
                    Console.WriteLine(needStringSearch);
                    if (Path.GetExtension(needStringSearch) == "")
                    {
                        isDir = true;
                    }
                    StartSearchName();
                    break;
                case 1:
                    Console.WriteLine("Введите размер файлов и папок для поиска в байтах");
                    needSizeSearch = GetData.GetDouble();
                    StartSearchBySize();
                    break;
                case 2:
                    Console.WriteLine("Введите дату создания");
                    needDateSearch = GetData.GetDate();
                    delegSearchDate = new SearchNeedDate(StartSearchByDateCreate);
                    StartSearchByDate();
                    break;
                case 3:
                    Console.WriteLine("Введите дату доступа");
                    needDateSearch = GetData.GetDate();
                    delegSearchDate = new SearchNeedDate(StartSearchByDateAccess);
                    StartSearchByDate();
                    break;
                case 4:
                    Console.WriteLine("Введите дату модификации");
                    needDateSearch = GetData.GetDate();
                    delegSearchDate = new SearchNeedDate(StartSearchByDateWrite);
                    StartSearchByDate();
                    break;
                case 5:
                    Console.WriteLine("Поиск по содержимому в файлах");
                    needStringSearch = Console.ReadLine();
                    // needStringSearch = "hello ";
                    StartSearchByContent();
                    break;
            }
        }

        public bool LinearSearch(string[] array, string x)
        {
            for (int i = 0, count = array.Length; i < count; ++i)
            {
                if (array[i] == x)
                {
                    return true;
                }
            }

            return false;
        }

        public void StartSearchByContent(string currentDir = "")
        {
            if (currentDir == "")
            {
                currentDir = fromSearch;
            }
            DirectoryInfo di = new DirectoryInfo(currentDir);
            FileInfo[] fiArr = di.GetFiles();
            string fileNameContent, textContent;
            foreach (FileInfo f in fiArr)
            {
                if (LinearSearch(textExtensionContent, Path.GetExtension(f.Name)))
                {
                    // читаем файл и делаем поиск в этом файле
                    fileNameContent = currentDir + "\\" + f.Name;
                    textContent = ReadFile(fileNameContent);
                    // выполняем поиск по содержимому
                    if (textContent.IndexOf(needStringSearch) >= 0)
                    {
                        searchResults.Add(fileNameContent);
                    }
                }
            }
            string[] resultDirectory = Directory.GetDirectories(currentDir);
            foreach (string tempStr in resultDirectory)
            {
                StartSearchByContent(tempStr);
            }
        }

        public void WriteFile(string pathName, string content)
        {
            FileStream fsWriter = new FileStream(
                pathName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None
            );
            StreamWriter sw = new StreamWriter(fsWriter, Encoding.UTF8);
            sw.Write(content);
            sw.Dispose();
        }

        public string ReadFile(string pathName)
        {
            StreamReader sr = new StreamReader(pathName, Encoding.UTF8);
            string readText = sr.ReadToEnd();
            sr.Dispose();

            return readText;
        }

        public void StartSearchByDate(string currentDir = "")
        {
            if (currentDir == "")
            {
                currentDir = fromSearch;
            }
            string[] resultDirectory = Directory.GetDirectories(currentDir);
            foreach (string tempStr in resultDirectory)
            {
                delegSearchDate(tempStr, true);
                StartSearchByDate(tempStr);
            }
            string[] resultFiles = Directory.GetFiles(currentDir);
            foreach (string tempStr in resultFiles)
            {
                delegSearchDate(tempStr, false);
            }
        }

        public void StartSearchByDateWrite(string tempStr, bool isDir)
        {
            if (isDir)
            {
                if (Directory.GetLastWriteTime(tempStr) >= needDateSearch)
                {
                    searchResults.Add(tempStr);
                }
            }
            else
            {
                if (File.GetLastWriteTime(tempStr) >= needDateSearch)
                {
                    searchResults.Add(tempStr);
                }
            }
        }

        public void StartSearchByDateAccess(string tempStr, bool isDir)
        {
            if (isDir)
            {
                if (Directory.GetLastAccessTime(tempStr) >= needDateSearch)
                {
                    searchResults.Add(tempStr);
                }
            }
            else
            {
                if (File.GetLastAccessTime(tempStr) >= needDateSearch)
                {
                    searchResults.Add(tempStr);
                }
            }
        }

        public void StartSearchByDateCreate(string tempStr, bool isDir)
        {
            if (isDir)
            {
                if (Directory.GetCreationTime(tempStr) >= needDateSearch)
                {
                    searchResults.Add(tempStr);
                }
            }
            else
            {
                if (File.GetCreationTime(tempStr) >= needDateSearch)
                {
                    searchResults.Add(tempStr);
                }
            }
        }

        public void StartSearchBySize(string currentDir = "")
        {
            if (currentDir == "")
            {
                currentDir = fromSearch;
            }
            // получаем текущий 
            DirectoryInfo di = new DirectoryInfo(currentDir);
            FileInfo[] fiArr = di.GetFiles();
            foreach (FileInfo f in fiArr)
            {
                if (needSizeSearch <= f.Length)
                {
                    searchResults.Add(f.DirectoryName + "\\" + f.Name);
                }
            }
            string[] resultDirectory = Directory.GetDirectories(currentDir);
            foreach (string tempStr in resultDirectory)
            {
                StartSearchBySize(tempStr);
            }
        }


        // поиск по имени
        public void StartSearchName(string currentDir = "")
        {
            if (currentDir == "")
            {
                currentDir = fromSearch;
            }
            string[] resultDirectory;
            if (isDir)
            {
                resultDirectory = Directory.GetDirectories(currentDir);
                foreach (string tempStr in resultDirectory)
                {
                    if (Path.GetFileName(tempStr) == needStringSearch)
                    {
                        searchResults.Add(tempStr);
                    } 
                    else
                    {
                        StartSearchName(tempStr);
                    }
                }
            }
            else
            {
                string[] resultFiles = Directory.GetFiles(currentDir);
                foreach (string tempStr in resultFiles)
                {
                    if (Path.GetFileName(tempStr) == needStringSearch)
                    {
                        searchResults.Add(tempStr);
                    }
                }
                // дальше смотрим оставшиеся дирректории
                resultDirectory = Directory.GetDirectories(currentDir);
                foreach (string tempStr in resultDirectory)
                {
                    StartSearchName(tempStr);
                }
            }
        }

        public int ShowResults()
        {
            foreach (string tempStr in searchResults)
            {
                Console.WriteLine("Success " + tempStr);
            }
            if (searchResults.Count == 0)
            {
                Console.WriteLine("Нет результата для запроса");
            }
            return searchResults.Count;
        }

        public void RemoveResults()
        {
            searchResults.Clear();

        }

    }
}
