using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class fiveWonderOfTheWorld : WonderWorld
    {
        string name = "Мавзолей в Галикарнасе";
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
