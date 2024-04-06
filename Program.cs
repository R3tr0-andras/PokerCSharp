using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

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

                traitementCard.FirstDistribution(ref deck, ref table, ref compteur);
                ui.ShowTable(ref table);

                Console.WriteLine("╔═══════════════════════╗");
                Console.WriteLine($"║   Le pot est de :       ║");
                Console.WriteLine($"║   {pot}                 ║");
                Console.WriteLine("╚═══════════════════════╝");

                // Faire jouer le joueur
                if (!couche)
                {
                    ui.ShowCardPlayer(ref handPlayer);
                    Console.WriteLine("╔═══════════════════════╗");
                    Console.WriteLine($"║   Vous avez :           ║");
                    Console.WriteLine($"║   {argent[0]} jetons      ║");
                    Console.WriteLine("╚═══════════════════════╝");
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

                    traitementCard.DistributionToTable(ref deck, ref table, ref compteur);
                    traitementCard.DistributionToTable(ref deck, ref table, ref compteur);
                    ui.ShowTable(ref table);

                    Console.WriteLine("╔═══════════════════════╗");
                    Console.WriteLine($"║   Le pot est de :       ║");
                    Console.WriteLine($"║   {pot}                 ║");
                    Console.WriteLine("╚═══════════════════════╝");

                    //Montrer les cartes des ia
                    ui.ShowOtherPlayersHands(ref handPlayer);

                    // Appel de DetermineWinner pour déterminer le gagnant
                    DetermineWinner(ref handPlayer,ref table,ref argent, ref pot);

                }
                else
                {
                    // Faire jouer les ordinateurs
                    for (int i = 1; i < joueurActuel; i++)
                    {
                        player.JouerIa(i, ref mise, ref argent, ref pot);
                    }

                    traitementCard.DistributionToTable(ref deck, ref table, ref compteur);
                    ui.ShowTable(ref table);

                    Console.WriteLine("╔═══════════════════════╗");
                    Console.WriteLine($"║   Le pot est de :       ║");
                    Console.WriteLine($"║   {pot}                 ║");
                    Console.WriteLine("╚═══════════════════════╝");

                    // Faire jouer le joueur
                    if (!couche)
                    {
                        ui.ShowCardPlayer(ref handPlayer);
                        Console.WriteLine("╔═══════════════════════╗");
                        Console.WriteLine($"║   Vous avez :           ║");
                        Console.WriteLine($"║   {argent[0]} jetons      ║");
                        Console.WriteLine("╚═══════════════════════╝");
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

                        traitementCard.DistributionToTable(ref deck, ref table, ref compteur);
                        ui.ShowTable(ref table);

                        Console.WriteLine("╔═══════════════════════╗");
                        Console.WriteLine($"║   Le pot est de :       ║");
                        Console.WriteLine($"║   {pot}                 ║");
                        Console.WriteLine("╚═══════════════════════╝");

                        //Montrer les cartes des ia
                        ui.ShowOtherPlayersHands(ref handPlayer);

                        // Appel de DetermineWinner pour déterminer le gagnant
                        DetermineWinner(ref handPlayer, ref table, ref argent, ref pot);
                    }
                    else
                    {
                        // Faire jouer les ordinateurs ludo le bg
                        for (int i = 1; i < joueurActuel; i++)
                        {
                            player.JouerIa(i, ref mise, ref argent, ref pot);
                        }

                        traitementCard.DistributionToTable(ref deck, ref table, ref compteur);
                        ui.ShowTable(ref table);

                        Console.WriteLine("╔═══════════════════════╗");
                        Console.WriteLine($"║   Le pot est de :       ║");
                        Console.WriteLine($"║   {pot}                 ║");
                        Console.WriteLine("╚═══════════════════════╝");

                        // Faire jouer le joueur
                        if (!couche)
                        {
                            ui.ShowCardPlayer(ref handPlayer);
                            Console.WriteLine("╔═══════════════════════╗");
                            Console.WriteLine($"║   Vous avez :           ║");
                            Console.WriteLine($"║   {argent[0]} jetons      ║");
                            Console.WriteLine("╚═══════════════════════╝");
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

                        //Montrer les cartes des ia
                        ui.ShowOtherPlayersHands(ref handPlayer);

                        // Appel de DetermineWinner pour déterminer le gagnant
                        DetermineWinner(ref handPlayer, ref table, ref argent, ref pot);
                    }

                    Console.WriteLine("Voulez-vous continuer à jouer ? (Oui/Non)");
                    string choixContinuerInput = Console.ReadLine();

                    choixContinuerInput = choixContinuerInput.ToLower();

                    if (choixContinuerInput == "oui")
                    {
                        // Continuer le jeu
                        Clear(ref suits, ref ranks, ref deck, ref handPlayer, ref compteur, ref table, ref pot, ref tapisPlayer);
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

            static void DetermineWinner(ref string[,] handPlayer,ref string[] table,ref int[] argent, ref int pot)
            {
                // Définir les valeurs des mains des joueurs
                List<int> values = new List<int>();
                for (int i = 0; i < handPlayer.GetLength(0); i++)
                {
                    List<string> hand = new List<string>();
                    for (int j = 0; j < handPlayer.GetLength(1); j++)
                    {
                        if (!string.IsNullOrEmpty(handPlayer[i, j]))
                        {
                            hand.Add(handPlayer[i, j]);
                        }
                    }
                    hand.AddRange(table);

                    // Évaluer la main du joueur
                    int value = EvaluateHand(hand.ToArray());
                    values.Add(value);
                }

                // Trouver le joueur avec la meilleure main
                int maxIndex = 0;
                for (int i = 1; i < values.Count; i++)
                {
                    if (values[i] > values[maxIndex])
                    {
                        maxIndex = i;
                    }
                }

                // Afficher le joueur gagnant
                Console.WriteLine($"Le joueur {maxIndex + 1} remporte la partie avec la meilleure main !");

                // Ajouter le pot à l'argent du joueur gagnant
                argent[maxIndex] += pot;

                // Remettre le pot à zéro
                pot = 0;
            }

            // Fonction pour évaluer la main des joueurs
            static int EvaluateHand(string[] hand)
            {
                // Compter les occurrences de chaque rang et chaque couleur
                Dictionary<string, int> rankCount = new Dictionary<string, int>();
                Dictionary<string, int> suitCount = new Dictionary<string, int>();

                foreach (string card in hand)
                {
                    string rank = card.Split(' ')[0];
                    string suit = card.Split(' ')[1];

                    if (!rankCount.ContainsKey(rank))
                        rankCount[rank] = 1;
                    else
                        rankCount[rank]++;

                    if (!suitCount.ContainsKey(suit))
                        suitCount[suit] = 1;
                    else
                        suitCount[suit]++;
                }

                // Vérifier les combinaisons possibles
                bool isFlush = suitCount.ContainsValue(5);
                bool isStraight = IsStraight(rankCount);

                // Évaluer la force de la main en fonction des combinaisons possibles
                if (isFlush && isStraight)
                {
                    return 9; // Quinte flush
                }
                else if (rankCount.ContainsValue(4))
                {
                    return 8; // Carré
                }
                else if (rankCount.ContainsValue(3) && rankCount.ContainsValue(2))
                {
                    return 7; // Full
                }
                else if (isFlush)
                {
                    return 6; // Couleur
                }
                else if (isStraight)
                {
                    return 5; // Quinte
                }
                else if (rankCount.ContainsValue(3))
                {
                    return 4; // Brelan
                }
                else if (IsTwoPair(rankCount))
                {
                    return 3; // Double paire
                }
                else if (rankCount.ContainsValue(2))
                {
                    return 2; // Paire
                }
                else
                {
                    return 1; // Carte haute
                }
            }

            // Fonction pour vérifier si une main contient une suite
            static bool IsStraight(Dictionary<string, int> rankCount)
            {
                int count = 0;
                foreach (var kvp in rankCount)
                {
                    if (kvp.Value == 1)
                    {
                        count++;
                        if (count == 5)
                            return true;
                    }
                    else
                    {
                        count = 0;
                    }
                }
                return false;
            }

            // Fonction pour vérifier si une main contient deux paires
            static bool IsTwoPair(Dictionary<string, int> rankCount)
            {
                int pairCount = 0;
                foreach (var kvp in rankCount)
                {
                    if (kvp.Value == 2)
                        pairCount++;

                    if (pairCount == 2)
                        return true;
                }
                return false;
            }

            static void Clear(ref List<string> suits, ref List<string> ranks, ref List<string> deck,
                ref string[,] handPlayer, ref short compteur, ref string[] table, ref int pot, ref bool tapisPlayer)
            {
                // List
                suits.Clear();
                ranks.Clear();
                deck.Clear();

                // Tableau
                Array.Clear(table, 0, table.Length);

                // Compteur
                compteur = 0;

                // Matrice
                int rows = handPlayer.GetLength(0);
                int columns = handPlayer.GetLength(1);

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        handPlayer[i, j] = null;
                    }
                }

                // Pot
                pot = 0;

                //Mises et Tapis
                int mise = 20;
                tapisPlayer = false;
            }
        }
    }
}