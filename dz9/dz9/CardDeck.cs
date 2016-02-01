using System;
using System.Collections.Generic;

namespace dz9
{
    class CardDeck
    {
        private Queue<Kart> allKarts;

        public CardDeck()
        {
            allKarts = new Queue<Kart>();
            createCardDeck();
        }

        public Queue<Kart> AllKarts
        {
            get { return allKarts; }
        }

        public Kart getNextKart()
        {
            return allKarts.Dequeue();
        }

        // создаем калоду карт
        public void createCardDeck()
        {
            if (allKarts.Count > 0)
            {
                allKarts.Clear();
            }
            int[] colorKart = { 3, 4, 5, 6 };
            Dictionary<string, int> karts = new Dictionary<string, int>();
            FillDictionary(karts);
            List<Kart> cardDeck = new List<Kart>();
            for (int i = 0, count = colorKart.Length; i < count; ++i)
            {
                foreach (KeyValuePair<string, int> p in karts)
                {
                    cardDeck.Add(new Kart(p.Key, Convert.ToString(Convert.ToChar(colorKart[i])), p.Value));
                }
            }
            // тасуем колоду
            shuffleeCardDeck(cardDeck);
        }

        public void shuffleeCardDeck(List<Kart> cardDeck)
        {
            Random r = new Random();
            Kart tempKart;
            while (cardDeck.Count > 0)
            {
                tempKart = cardDeck[r.Next(0, cardDeck.Count)];
                cardDeck.Remove(tempKart);
                allKarts.Enqueue(tempKart);
            }
        }

        public void ShowCardDeck()
        {
            foreach (Kart p in allKarts)
            {
                p.ShowKart();
            }
        }

        public void FillDictionary(Dictionary<string, int> karts)
        {
            karts.Add("2", 2);
            karts.Add("3", 3);
            karts.Add("4", 4);
            karts.Add("5", 5);
            karts.Add("6", 6);
            karts.Add("7", 7);
            karts.Add("8", 8);
            karts.Add("9", 9);
            karts.Add("10", 10);
            karts.Add("J", 10);
            karts.Add("D", 10);
            karts.Add("K", 10);
            karts.Add("A", 11);
        }
    }
}
