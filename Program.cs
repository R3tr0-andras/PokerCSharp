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

            //Mise en place de la table 
            string[] table = new string[5];

            //Mise en place des joueurs
            int joueurActuel = ui.NumberPlayer();
            List<string> players = new List<string>();

            //Mise en place des jettons joueurs
            int[] argent = new int[joueurActuel];

            //mettre l'argent dans la partie
            for (int i = 0; i < joueurActuel; i++)
            {
                argent[i] = 2500;
            }

            //Mise en place du pot
            int pot = 0;

            //Mise en place des mises
            int mise = 0;
            int miseBase = 20;

            bool continuerJeu = true;

            while (continuerJeu)
            {
                table = player.FirstDistribution(ref deck);

                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine(table[i]);
                }

                interact.JouerUser();
                
                for (int i = 1; i < joueurActuel; i++)
                {
                    ia.JouerIa(i, ref argent, ref handPlayer);
                }

                table = player.DistributionToTable(ref deck);
                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine(table[i]);
                }

                interact.JouerUser();

                for (int i = 1; i < joueurActuel; i++)
                {
                    ia.JouerIa(i, ref argent, ref handPlayer);
                }

                table = player.DistributionToTable(ref deck);
                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine(table[i]);
                }
            }
        }
    }
}