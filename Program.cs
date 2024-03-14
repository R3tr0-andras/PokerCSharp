using System;

namespace PokerCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Mes librairies
            Card traitementCard = new Card();
            ia player = new ia();
            interact ui = new interact();

            //Mise en place des cartes
            List<string> suits = new List<string> { "Coeur", "Carreau", "Trèfle", "Pique" };
            List<string> ranks = new List<string> { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Roi", "Reine", "Valet" };
            List<string> deck = traitementCard.CreateDeck(suits, ranks);
            traitementCard.ShuffleDeck(deck);

            //Mise en place des joueurs
            int joueurActuel = ui.NumberPlayer();
            List<string> players = new List<string>();

            //Distribution de deux cartes par joueurs
            string[,] handPlayer = player.initializeAndDistribute(joueurActuel, deck);

            // Afficher les mains
            for (int i = 0; i < joueurActuel; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(handPlayer[i, j] + " ");
                }
                Console.WriteLine();
            }

            //Mise des cartes sur la table

            //3 cartes puis une par une jusqu'à 5 cartes
            

        }
    }
}