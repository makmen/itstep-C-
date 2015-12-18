using System;
using System.Collections.Generic;

namespace dz6_3
{
    class MyDictionary
    {
        private Dictionary<string, string> allWords;  // (RU, EN)
        private List<string> allLanguage;

        public MyDictionary(string langnRu, string langEn)
        {
            allWords = new Dictionary<string, string>();
            allLanguage = new List<string>();
            allLanguage.Add(langnRu);
            allLanguage.Add(langEn);
        }
        public void FillDictionary()
        {
            AddWord("Россия", "Russia");
            AddWord("Россия", "Russia");
            AddWord("Беларусь", "Belarus");
            AddWord("Беларусь", "Belarus");
        }

        public void AddWord(string wordRu, string wordEn)
        {
            try
            {
                allWords.Add(wordRu, wordEn);
            }
            catch(ArgumentException ex)
            {
                //Console.WriteLine(ex.Message);
            }

        }

        public string TranslateWord(string search)
        {
            ICollection<string> keys = allWords.Keys;
            foreach (string need in keys)
            {
                if (allLanguage[0] == "RU")
                {
                    if (need.ToLower() == search.ToLower())
                    {
                        return allWords[need];
                    }
                }
                else
                {
                    if (allWords[need].ToLower() == search.ToLower())
                    {
                        return need;
                    }
                }
            }

            return "";
        }

        public string ChangeLanguage()
        {
            string temp = allLanguage[0];
            allLanguage[0] = allLanguage[1];
            allLanguage[1] = temp;

            return CurrentLanguageOption();
        }

        public string CurrentLanguageOption()
        {
            return allLanguage[0] + " => " + allLanguage[1];
        }

        public string CurrentLanguage()
        {
            return allLanguage[0];
        }
    }
}
