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
            int pot;

            //Mise des cartes sur la table
            //3 cartes puis une par une jusqu'à 5 cartes
            table = player.FirstDistribution(ref deck);

            for(int i = 0;i < table.Length; i++)
            {
                Console.WriteLine(table[i]);
            }

            table = player.DistributionToTable(ref deck);
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine(table[i]);
            }

            table = player.DistributionToTable(ref deck);
            for (int i = 0; i < table.Length; i++)
            {
                Console.WriteLine(table[i]);
            }

            bool finPartie = false;

            do
            {

                //Distribution de deux cartes par joueurs
                string[,] handPlayer = player.initializeAndDistribute(joueurActuel, ref deck);

                //Mise des cartes sur la table
                table = player.FirstDistribution(ref deck);


            } while (finPartie == true);
        }
    }
}