using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace PokerCSharp
{
    /// <summary>
    /// Classe principale du programme de poker.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Méthode principale du programme.
        /// </summary>
        /// <param name="args">Arguments de la ligne de commande.</param>
        static void Main(string[] args)
        {
            //Mes librairies
            Card traitementCard = new Card();
            ia player = new ia();
            interact ui = new interact();
            WinningConditions wc = new WinningConditions();

            //Mise en place des joueurs
            int joueurActuel = 0;
            ui.NPlayer(ref joueurActuel);
            Console.Clear();

            //Mise en place des jettons joueurs
            int[] argent = new int[joueurActuel];

            //mettre l'argent dans la partie
            for (int i = 0; i < joueurActuel; i++)
            {
                argent[i] = 2500;
            }

            bool continuerJeu = true;
            while (continuerJeu)
            {
                //Mise en place des cartes
                List<string> suits = new List<string> { "Coeur", "Carreau", "Trèfle", "Pique" };
                List<string> ranks = new List<string> { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Roi", "Reine", "Valet" };
                List<string> deck = traitementCard.CreateDeck(suits, ranks);
                traitementCard.ShuffleDeck(deck);

                //Mise en place de la table 
                string[] table = new string[5];
                short compteur = 0;

                string[,] handPlayer = traitementCard.initializeAndDistribute(joueurActuel, ref deck);
                // PP ia ia ia   ia   ia
                // [] [] [] []   []   []
                // [] [] [] []   []   []

                //couche
                bool couche = false;

                //Mise en place du pot
                int pot = 0;

                //Mise en place des mises
                int mise = 20;
                bool tapisPlayer = false;

                //1ere distribution de 3 cartes
                traitementCard.FirstDistribution(ref deck, ref table, ref compteur);

                //Montrer la table
                ui.ShowTable(ref table);

                //Montrer la valeur du pot
                ui.ShowPot(ref pot);

                // Faire jouer le joueur
                if (!couche)
                {
                    //Montrer les cartes du joueur
                    ui.ShowCardPlayer(ref handPlayer);

                    //Montrer le nombre de jetons du joueur
                    ui.ShowPlayerMoney(ref argent);
                    
                    //Faire jouer l'urilisateur et vérifier si il se couche
                    couche = ui.FaireJouerUser(ref pot, ref mise, ref argent, ref tapisPlayer);
                }
                else
                {
                    Console.WriteLine("Le joueur s'est couché(e), alors il passe son tour");
                }

                if (tapisPlayer == true)
                {
                    // Faire jouer les ordinateurs
                    for (int i = 1; i < joueurActuel; i++)
                    {
                        player.JouerIa(i, ref mise, ref argent, ref pot);
                    }

                    //Distribuer les cartes manquantes pour finaliser la partie
                    traitementCard.DistributionToTable(ref deck, ref table, ref compteur);
                    traitementCard.DistributionToTable(ref deck, ref table, ref compteur);

                    //Montrer la table
                    ui.ShowTable(ref table);

                    //Montrer la valeur du pot
                    ui.ShowPot(ref pot);

                    //Montrer la table
                    ui.ShowTable(ref table);

                    //Montrer les cartes des ia
                    ui.ShowOtherPlayersHands(ref handPlayer);

                    // Appel de DetermineWinner pour déterminer le gagnant
                    wc.DetermineWinner(ref handPlayer, ref table, ref argent, ref pot);

                }
                else
                {
                    // Faire jouer les ordinateurs
                    for (int i = 1; i < joueurActuel; i++)
                    {
                        player.JouerIa(i, ref mise, ref argent, ref pot);
                    }

                    //Distribuer une carte
                    traitementCard.DistributionToTable(ref deck, ref table, ref compteur);

                    //Montrer la table
                    ui.ShowTable(ref table);

                    //Montrer la valeur du pot
                    ui.ShowPot(ref pot);

                    // Faire jouer le joueur
                    if (!couche)
                    {
                        //Montrer les cartes du joueur
                        ui.ShowCardPlayer(ref handPlayer);

                        //Montrer le nombre de jetons du joueur
                        ui.ShowPlayerMoney(ref argent);

                        //Faire jouer l'urilisateur et vérifier si il se couche
                        couche = ui.FaireJouerUser(ref pot, ref mise, ref argent, ref tapisPlayer);
                    }
                    else
                    {
                        Console.WriteLine("Le joueur s'est couché(e), alors il passe son tour");
                    }

                    if (tapisPlayer == true)
                    {
                        // Faire jouer les ordinateurs ludo le bg
                        for (int i = 1; i < joueurActuel; i++)
                        {
                            player.JouerIa(i, ref mise, ref argent, ref pot);
                        }

                        //Distribuer une carte
                        traitementCard.DistributionToTable(ref deck, ref table, ref compteur);

                        //Montrer la table
                        ui.ShowTable(ref table);

                        //Montrer la valeur du pot
                        ui.ShowPot(ref pot);

                        //Montrer la table
                        ui.ShowTable(ref table);

                        //Montrer les cartes des ia
                        ui.ShowOtherPlayersHands(ref handPlayer);

                        // Appel de DetermineWinner pour déterminer le gagnant
                        wc.DetermineWinner(ref handPlayer, ref table, ref argent, ref pot);
                    }
                    else
                    {
                        // Faire jouer les ordinateurs ludo le bg
                        for (int i = 1; i < joueurActuel; i++)
                        {
                            player.JouerIa(i, ref mise, ref argent, ref pot);
                        }

                        //Distribuer les cartes manquantes pour finaliser la partie
                        traitementCard.DistributionToTable(ref deck, ref table, ref compteur);

                        //Montrer la table
                        ui.ShowTable(ref table);

                        //Montrer la valeur du pot
                        ui.ShowPot(ref pot);

                        // Faire jouer le joueur
                        if (!couche)
                        {
                            //Montrer les cartes du joueur
                            ui.ShowCardPlayer(ref handPlayer);

                            //Montrer le nombre de jetons du joueur
                            ui.ShowPlayerMoney(ref argent);

                            //Faire jouer l'urilisateur et vérifier si il se couche
                            couche = ui.FaireJouerUser(ref pot, ref mise, ref argent, ref tapisPlayer);
                        }
                        else
                        {
                            Console.WriteLine("Le joueur s'est couché(e), alors il passe son tour");
                        }

                        // Faire jouer les ordinateurs ludo le bg
                        for (int i = 1; i < joueurActuel; i++)
                        {
                            player.JouerIa(i, ref mise, ref argent, ref pot);
                        }

                        //Montrer la table
                        ui.ShowTable(ref table);

                        //Montrer les cartes des ia
                        ui.ShowOtherPlayersHands(ref handPlayer);

                        // Appel de DetermineWinner pour déterminer le gagnant
                        wc.DetermineWinner(ref handPlayer, ref table, ref argent, ref pot);
                    }

                    Console.WriteLine("Voulez-vous continuer à jouer ? (Oui/Non)");
                    string? choixContinuerInput = Console.ReadLine();

                    if (choixContinuerInput != null)
                    {
                        choixContinuerInput = choixContinuerInput.ToLower();
                    }

                    if (choixContinuerInput == "oui")
                    {
                        // Continuer le jeu
                        ui.Clear(ref suits, ref ranks, ref deck, ref handPlayer, ref compteur, ref table, ref pot, ref tapisPlayer);
                        Console.Clear();
                    }
                    else if (choixContinuerInput == "non")
                    {
                        // Terminer le jeu
                        continuerJeu = false;
                    }
                    else
                    {
                        // Choix invalide
                        Console.WriteLine("Choix non valide. Le jeu se terminera.");
                        continuerJeu = false;
                    }
                }
            }
        }
    }
}