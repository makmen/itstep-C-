using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class firstWonderOfTheWorld : WonderWorld
    {
        private string name = "Пирамида Хеопса";

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
