using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class sixthWonderOfTheWorld : WonderWorld
    {
        string name = "Колосс Родосский";
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public override void print()
        {
            Console.WriteLine(name);
        }
    }
}
