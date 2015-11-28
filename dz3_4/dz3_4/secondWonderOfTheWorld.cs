using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class secondWonderOfTheWorld : WonderWorld
    {
        private string name = "Висячие сады Семирамиды";

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
