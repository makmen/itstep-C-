using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz9
{
    class Game
    {
        private Queue<Player> allPlayers;
        private int countGame;
        private CardDeck cardDeck;
        private const int minCountKartsInCardDeck = 20;

        public Game()
        {
            allPlayers = new Queue<Player>();
            countGame = 0;
            cardDeck = new CardDeck();
            allPlayers.Enqueue(new Player("Игрок", cardDeck)); // сразу ходит игрок
            allPlayers.Enqueue(new Player("Komputer", cardDeck, true));
            playGame();
        }

        public void playGame()
        {
            // начинаем игру 
            while (true)
            {
                ++countGame;
                // раздаем по две карты всем игрокам
                foreach (Player tempObjectPlayer in allPlayers)
                {
                    tempObjectPlayer.TakeKart(cardDeck);
                    tempObjectPlayer.TakeKart(cardDeck);
                }

                GetTurn(allPlayers.Peek());
                ChangeTurn();
                GetTurn(allPlayers.Peek());
                ChangeTurn();
                ShowResults(); // выводим результаты игры

                // продолжим 
                if (GetData.GetChoiceYesNo("Вы хотите сыграть еще раз?"))
                {
                    // чистим результаты
                    foreach (Player tempObjectPlayer in allPlayers)
                    {
                        tempObjectPlayer.ClearPlayer();
                    }
                    // перетусовка колоды
                    if (cardDeck.AllKarts.Count < minCountKartsInCardDeck)
                    {
                        cardDeck.createCardDeck();
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public void ShowResults()
        {
            bool draw = false;
            List<Player> results = new List<Player>();
            foreach (Player tempObjectPlayer in allPlayers)
            {
                tempObjectPlayer.ShowPlayer();
                tempObjectPlayer.ShowPlayerKarts();
                results.Add(tempObjectPlayer);
            }
            if (results[0].PlayerScore < 21 && results[1].PlayerScore < 21) // когда нет перебора
            {
                if (results[0].PlayerScore > results[1].PlayerScore)
                {
                    Console.WriteLine("{0} вы выйграли.", results[0].PlayerName);
                    ++results[0].CountWinGame;
                }
                else if (results[0].PlayerScore < results[1].PlayerScore)
                {
                    Console.WriteLine("{0} вы проиграли.", results[0].PlayerName);
                    ++results[1].CountWinGame;
                }
                else
                {
                    draw = true;
                }
            }
            else if (results[0].PlayerScore > 21 || results[1].PlayerScore > 21) // когда есть у кого-то перебор
            {

                if (results[0].PlayerScore > 21 && results[1].PlayerScore <= 21)
                {
                    Console.WriteLine("{0} вы проиграли.", results[0].PlayerName);
                    ++results[1].CountWinGame;
                }
                else if (results[0].PlayerScore <= 21 && results[1].PlayerScore > 21)
                {
                    Console.WriteLine("{0} вы выйграли.", results[0].PlayerName);
                    ++results[0].CountWinGame;
                }
                else
                {
                    draw = true;
                }
            }
            else // когда у кого-то 21 а у другого нет перебора
            {
                if (results[0].PlayerScore == 21 && results[1].PlayerScore < 21)
                {
                    Console.WriteLine("{0} вы выйграли.", results[0].PlayerName);
                    ++results[0].CountWinGame;
                }
                else if (results[0].PlayerScore < 21 && results[1].PlayerScore == 21)
                {
                    Console.WriteLine("{0} вы проиграли.", results[0].PlayerName);
                    ++results[1].CountWinGame;
                }
                else // results[0].PlayerScore == 21 && results[1].PlayerScore == 21
                {
                    draw = true;
                }
            }
            if (draw)
            {
                Console.WriteLine("Ничья");
            }
            // общий счёт игры
            Console.WriteLine("\nСыграно игр: {0}", countGame);
            Console.WriteLine("Количество выйгранных сражений: {0}", results[0].CountWinGame);
            Console.WriteLine("Количество проигранных сражений: {0}\n", results[1].CountWinGame);
        }

        public void GetTurnCoumputer(Player tempObjectPlayer)
        {
            Console.WriteLine("\nХод компьютера");
            // задержка 
            System.Threading.Thread.Sleep(1000);
            // у компа всё просто он играет до 17 очков
            while (tempObjectPlayer.PlayerScore < 17)
            {
                tempObjectPlayer.TakeKart(cardDeck);
            }
            tempObjectPlayer.ShowPlayerKarts();
            tempObjectPlayer.ShowScore();
            // задержка 
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine();
        }

        public void GetTurn(Player tempObjectPlayer)
        {
            if (tempObjectPlayer.Computer)
            {
                GetTurnCoumputer(tempObjectPlayer);
                return;
            }
            Console.WriteLine("Ваши карты");
            tempObjectPlayer.ShowPlayerKarts();
            tempObjectPlayer.ShowScore();
            while (true)
            {
                if (tempObjectPlayer.PlayerScore == 21)
                {
                    Console.WriteLine("У вас 21");
                    break;
                }
                else if (tempObjectPlayer.PlayerScore > 21)
                {
                    Console.WriteLine("У вас перебор.");
                    break;
                }
                else
                {
                    if (GetData.GetChoiceYesNo("Взять еще карту?"))
                    {
                        tempObjectPlayer.TakeKart(cardDeck);
                        tempObjectPlayer.ShowPlayerLastKart();
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void ChangeTurn()
        {
            Player tempPlayer = allPlayers.Dequeue();
            allPlayers.Enqueue(tempPlayer);
        }
    }
}
