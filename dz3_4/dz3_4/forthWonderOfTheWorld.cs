using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class forthWonderOfTheWorld : WonderWorld
    {
        string name = "Храм Артемиды в Эфесе";

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
