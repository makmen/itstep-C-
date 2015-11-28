using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class seventhWonderOfTheWorld : WonderWorld
    {
        string name = "Александрийский маяк";
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
