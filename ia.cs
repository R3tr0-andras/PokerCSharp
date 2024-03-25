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
        static void JouerIa(int indexJoueur, ref int[] argent, ref string[,] handPlayer)
        {
            Random rand = new Random();
            int choix = rand.Next(3); // Générer un nombre aléatoire entre 0 et 2

            switch (choix)
            {
                case 0:
                    // Relancer
                    Console.WriteLine($"Joueur {indexJoueur} a choisi de relancer.");

                    // Générer un montant de relance aléatoire entre 1 et l'argent disponible
                    int montantRelance = rand.Next(1, argent[indexJoueur] + 1);
                    Console.WriteLine($"Joueur {indexJoueur} relance de {montantRelance}.");

                    // Mettre à jour l'argent du joueur en conséquence
                    argent[indexJoueur] -= montantRelance;
                    break;

                case 1:
                    // Suivre
                    Console.WriteLine($"Joueur {indexJoueur} a choisi de suivre.");
                    // Il n'y a rien à faire ici car le joueur suit simplement la mise en cours
                    break;

                case 2:
                    // Se coucher
                    Console.WriteLine($"Joueur {indexJoueur} a choisi de se coucher.");
                    // Enlever les cartes du joueur de la matrice handPlayer
                    for (int i = 0; i < handPlayer.GetLength(1); i++)
                    {
                        handPlayer[indexJoueur, i] = null; // ou handPlayer[indexJoueur, i] = ""; selon votre préférence
                    }
                    break;

                default:
                    Console.WriteLine("Choix non valide.");
                    break;
            }
        }
    }
}
