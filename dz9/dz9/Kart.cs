using System;
using System.Collections.Generic;

namespace dz9
{
    class Kart
    {
        private string kartName;
        private string colorKart;
        private int score;

        public Kart(string kartName_, string colorKart_, int score_)
        {
            kartName = kartName_;
            colorKart = colorKart_;
            score = score_;
        }

        public void ShowKart()
        {
            Console.WriteLine("{0} {1} {2}", kartName, colorKart, score);
        }

        public string ColorKart
        {
            get { return colorKart; }
            set { colorKart = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public string KartName
        {
            get { return kartName; }
            set { kartName = value; }
        }
    }
}
