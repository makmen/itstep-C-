using System;
using dz3_5;

namespace Ukraine
{
    class Kiev
    {
        private int population;
        private string name;
        public Kiev(int population_)
        {
            population = population_;
            name = "Kiev";
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
