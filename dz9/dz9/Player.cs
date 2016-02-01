using System;
using System.Collections.Generic;

namespace dz9
{
    class Player
    {
        private List<Kart> playerKarts;
        private int playerScore;
        private string playerName;
        private bool computer;
        private int countWinGame;

        public Player(string playerName_, CardDeck cardDeck_, bool computer_ = false)
        {
            playerName = playerName_;
            playerScore = 0;
            playerKarts = new List<Kart>();
            computer = computer_;
            countWinGame = 0;
        }

        public void ShowPlayer()
        {
            Console.WriteLine("{0} - Счёт: {1}", playerName, playerScore);
        }

        public void ShowPlayerKarts()
        {
            foreach (Kart p in playerKarts)
            {
                p.ShowKart();
            }
        }

        public void ShowScore()
        {
            if (computer)
            {
                Console.WriteLine("Очки компьютера {0}", playerScore);
            }
            else
            {
                Console.WriteLine("Ваши очки {0}", playerScore);
            }
        }

        public void ShowPlayerLastKart()
        {
            playerKarts[(playerKarts.Count - 1)].ShowKart();
            ShowScore();
        }

        public void TakeKart(CardDeck cd)
        {
            playerKarts.Add(cd.getNextKart());
            playerScore += playerKarts[(playerKarts.Count - 1)].Score;
        }

        public void ClearPlayer()
        {
            playerScore = 0;
            playerKarts.Clear();
        }

        public string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }
        
        public int PlayerScore
        {
            get { return playerScore; }
            set { playerScore = value; }
        }
        
        public int CountWinGame
        {
            get { return countWinGame; }
            set { countWinGame = value; }
        }

        public bool Computer
        {
            get { return computer; }
            set { computer = value; }
        }

    }
}
