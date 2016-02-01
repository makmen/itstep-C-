using System;
using System.Collections.Generic;


namespace dz9
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру 21");
            if (GetData.GetChoiceYesNo("Вы хотите начать игру?"))
            {
                Game newGame = new Game();
            }
            Console.WriteLine("Успехов");
        }
    }
}
