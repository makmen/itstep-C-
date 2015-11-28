using System;
using dz3_5;

namespace Russia
{
    class Moscow
    {
        private int population;
        private string name;
        public Moscow(int population_)
        {
            population = population_;
            name = "Moscow";
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
