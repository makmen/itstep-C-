using System;
using WonderOfTheWorld;

namespace WonderOfTheWorld
{
    class WonderWorld
    {
        virtual public void print()
        {

        }
    }
}

namespace dz3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 7;
            WonderWorld[] masWonder = new WonderWorld[n];
            masWonder[0] = new firstWonderOfTheWorld();
            masWonder[1] = new secondWonderOfTheWorld();
            masWonder[2] = new thirdWonderOfTheWorld();
            masWonder[3] = new forthWonderOfTheWorld();
            masWonder[4] = new fiveWonderOfTheWorld();
            masWonder[5] = new sixthWonderOfTheWorld();
            masWonder[6] = new seventhWonderOfTheWorld();

            for (int i = 0; i < n; ++i)
            {
                masWonder[i].print();
            }
        }
    }
}
