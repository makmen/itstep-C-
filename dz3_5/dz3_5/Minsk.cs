using System;
using dz3_5;

namespace Belarus
{
    class Minsk
    {
        private int population;
        private string name;
        public Minsk(int population_)
        {
            population = population_;
            name = "Minsk";
            Program.definePopulation(population, name);
        }
        public int Population
        {
            get { return population; }
            set { population = (value < 0) ? 0 : value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
