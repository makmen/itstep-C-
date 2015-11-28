using System;
using Russia;
using Belarus;
using Ukraine;

namespace dz3_5
{
    class Program
    {
        static private int population;
        static private string city;
        static void Main(string[] args)
        {
            Moscow firstCity = new Moscow(10000000);
            Minsk secondCity = new Minsk(2000000);
            Kiev thirdCity = new Kiev(2800000);
            Console.WriteLine("The largest population is in {0} {1} people", city, population);
        }

        public static void definePopulation(int population_, string city_)
        {
            if (population < population_)
            {
                population = population_;
                city = city_;
            }
        }
    }
}
