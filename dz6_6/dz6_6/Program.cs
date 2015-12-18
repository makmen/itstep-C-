using System;
using System.Collections.Generic;

namespace dz6_6
{
    class Program
    {
        private static Dictionary<string, int> allWordsDictionary;

        static void Main(string[] args)
        {
            allWordsDictionary = new Dictionary<string, int>();
            string task = "В осенние дни как слышали ребята, прощаясь с милой родиной, курлыкали в небе пролетные журавли. С каким-то особым чувством долго смотрели им вслед, как будто журавли уносили с собой лето.";
            task = task.Replace(",", "");
            task = task.Replace(".", "");
            string[] stArray = task.Split(' ');

            for (int i = 0, count = stArray.Length; i < count; ++i)
            {
                AddWord(stArray[i]);
            }
            foreach (KeyValuePair<string, int> p in allWordsDictionary)
            {
                Console.WriteLine("{0} {1}", p.Key, p.Value);
            }
        }
        public static void AddWord(string word)
        {
            try
            {
                allWordsDictionary.Add(word.ToLower(), 1);
            }
            catch (ArgumentException)
            {
                ++allWordsDictionary[word.ToLower()];
            }
        }
    }
}
