using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCSharp
{
    public struct Card
    {
        public List<string> CreateDeck(List<string> suits, List<string> ranks)
        {
            List<string> deck = new List<string>();

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add(rank + " de " + suit);
                }
            }

            return deck;
        }

        public void ShuffleDeck(List<string> deck)
        {
            Random rng = new Random();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }
    }
}
