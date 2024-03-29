﻿using System;

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

            //couche
            bool couche = false;

            //Mise en place du pot
            int pot = 0;

            //Mise en place des mises
            int mise = 20;
            bool continuerJeu = true;
            bool tapisPlayer = false;

            while (continuerJeu)
            {
                table = player.FirstDistribution(ref deck);

                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine(table[i]);
                }

                // Faire jouer le joueur
                if (couche == false)
                {
                    couche = FaireJouerUser(ref pot, ref mise, ref argent, ref tapisPlayer);
                } else if(couche == true)
                {
                    Console.WriteLine("Le joueur s'est couché(e), alors il passe son tour");
                }

                // Faire jouer les ordinateurs
                for (int i = 1; i < joueurActuel; i++)
                {
                    player.JouerIa(i, ref mise, ref argent);
                }

                table = player.DistributionToTable(ref deck);
                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine(table[i]);
                }

                // Faire jouer le joueur
                if (couche == false)
                {
                    couche = FaireJouerUser(ref pot, ref mise, ref argent, ref tapisPlayer);
                }
                else if (couche == true) { }
                {
                    Console.WriteLine("Le joueur s'est couché(e), alors il passe son tour");
                }

                // Faire jouer les ordinateurs ludo le bg
                for (int i = 1; i < joueurActuel; i++)
                {
                    player.JouerIa(i,ref mise, ref argent);
                }

                table = player.DistributionToTable(ref deck);
                for (int i = 0; i < table.Length; i++)
                {
                    Console.WriteLine(table[i]);
                }
            }

            static bool FaireJouerUser(ref int pot, ref int mise, ref int[] argent, ref bool tapisPlayer)
            {
                bool couche = false;
                byte compteurDeroulement;
                Console.WriteLine("Que décidez-vous ?");
                Console.WriteLine("1. Suivre");
                Console.WriteLine("2. Se coucher");
                Console.WriteLine("3. Relancer");
                Console.Write("Votre choix : ");

                byte choixUtilisateur;

                // Boucle pour demander à l'utilisateur de saisir un choix valide
                do
                {
                    do
                    {
                        Console.WriteLine("Veuillez saisir un choix valide (1, 2 ou 3) : ");
                    }
                    while (!byte.TryParse(Console.ReadLine(), out choixUtilisateur));
                } while (choixUtilisateur < 1 || choixUtilisateur > 3);

                switch (choixUtilisateur)
                {
                    // Suivre le jeu
                    case 1:
                        Console.WriteLine("Vous avez choisi de suivre.");
                        pot = pot + mise;
                        argent[0] = argent[0] - mise;
                        break;

                    // Se coucher (abondonner)
                    case 2:
                        Console.WriteLine("Vous avez choisi de vous coucher.");
                        couche = true;
                        break;

                    // Relancer (miser plus)
                    case 3:
                        Console.WriteLine("Vous avez choisi de relancer.");
                        Console.WriteLine("De combien ?");
                        int nouvelleMise;
                        do
                        {
                            do
                            {
                                Console.WriteLine("Veuillez saisir un montant valide valide : ");
                            }
                            while (!int.TryParse(Console.ReadLine(), out nouvelleMise));
                        } while (nouvelleMise > mise && nouvelleMise <= argent[0]); 
                        mise = nouvelleMise;
                        break;

                    // Erreur dans le switch
                    default:
                        Console.WriteLine("Erreur choix non reconnu.");
                        break;
                }
                return couche;
            }
        }
    }
}