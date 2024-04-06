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

        public string[,] initializeAndDistribute(int joueurActuel, ref List<string> deck)
        {
            string[,] handPlayer = new string[joueurActuel, 2];
            Random rand = new Random();
            int index;
            for (int i = 0; i < joueurActuel; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    index = rand.Next(deck.Count);
                    handPlayer[i, j] = deck[index];
                    deck.RemoveAt(index);
                }
            }

            return (handPlayer);
        }

        public void FirstDistribution(ref List<string> deck, ref string[] table, ref short compteur)
        {

            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = rand.Next(deck.Count);
                table[i] = deck[randomIndex];
                deck.RemoveAt(randomIndex);
                compteur++;
            }
        }
        public void DistributionToTable(ref List<string> deck, ref string[] table, ref short compteur)
        {
            Random rand = new Random();

            int randomIndex = rand.Next(deck.Count);
            table[compteur] = deck[randomIndex];
            deck.RemoveAt(randomIndex);
            compteur++;
        }
    }
}
