using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCSharp
{
    public struct ia
    {
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

        public string[] FirstDistribution(ref List<string> deck)
        {
            string[] table = new string[3];
            Random rand = new Random();
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = rand.Next(deck.Count);
                table[i] = deck[randomIndex];
                deck.RemoveAt(randomIndex);
            }
            return table;
        }

        public string[] DistributionToTable(ref List<string> deck)
        {
            string[] table = new string[1];
            Random rand = new Random();

            for (int i = 0; i < 1; i++)
            {
                int randomIndex = rand.Next(deck.Count);
                table[i] = deck[randomIndex];
                deck.RemoveAt(randomIndex);
            }
            return table;
        }
    }
}
