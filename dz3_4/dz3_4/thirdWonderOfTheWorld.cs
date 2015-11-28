using System;
using dz3_4;

namespace WonderOfTheWorld
{
    class thirdWonderOfTheWorld : WonderWorld
    {
        string name = "Статуя Зевса в Олимпии";
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
