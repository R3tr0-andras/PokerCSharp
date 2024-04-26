using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCSharp
{
    /// <summary>
    /// Cette structure contient les méthodes pour interagir avec les cartes.
    /// </summary>
    public struct Card
    {
        /// <summary>
        /// Crée un jeu de cartes en combinant des symboles (suits) et des valeurs (ranks).
        /// </summary>
        /// <param name="suits">Liste des symboles des cartes (par exemple, "Coeur", "Carreau", etc.).</param>
        /// <param name="ranks">Liste des valeurs des cartes (par exemple, "As", "Roi", etc.).</param>
        /// <returns>Le jeu de cartes créé.</returns>
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

        /// <summary>
        /// Mélange le jeu de cartes.
        /// </summary>
        /// <param name="deck">Le jeu de cartes à mélanger.</param>
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

        /// <summary>
        /// Initialise et distribue les cartes aux joueurs.
        /// </summary>
        /// <param name="joueurActuel">Le nombre de joueurs actuels.</param>
        /// <param name="deck">Le jeu de cartes.</param>
        /// <returns>Les cartes distribuées aux joueurs sous forme de tableau.</returns>
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

        /// <summary>
        /// Distribue les cartes sur la table au début de la partie.
        /// </summary>
        /// <param name="deck">Le jeu de cartes.</param>
        /// <param name="table">La table où sont placées les cartes.</param>
        /// <param name="compteur">Compteur pour suivre le nombre de cartes distribuées.</param>
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

        /// <summary>
        /// Distribue une carte supplémentaire sur la table pendant le jeu.
        /// </summary>
        /// <param name="deck">Le jeu de cartes.</param>
        /// <param name="table">La table où sont placées les cartes.</param>
        /// <param name="compteur">Compteur pour suivre le nombre de cartes distribuées.</param>
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
