using System;
using System.Numerics;

namespace PokerCSharp
{
    public struct interact
    {
        public int NumberPlayer()
        {
            int nbj = 0;
            do
            {
                Console.WriteLine("Combien de joueur voulez-vous avoir autour de la table ? (4 minimum et 6 maximum)");
                string nb = Console.ReadLine();

                if (!int.TryParse(nb, out nbj))
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                    continue;
                }

                if (nbj < 4 || nbj > 6)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer un nombre entre 4 et 6.");
                    continue;
                }

                Console.WriteLine(nbj);
                break; // Exit
            } while (true);

            return nbj;
        }

        public void JouerUser()
        {
            //Distribution de deux cartes par joueurs
            string[,] handPlayer = player.initializeAndDistribute(joueurActuel, ref deck);

            //Mise des cartes sur la table
            table = player.FirstDistribution(ref deck);

            int compteurDeroulement;
            Console.WriteLine("Que décidez-vous ?");
            Console.WriteLine("1. Suivre");
            Console.WriteLine("2. Se coucher");
            Console.WriteLine("3. Relancer");
            Console.Write("Votre choix : ");

            int choixUtilisateur;

            // Boucle pour demander à l'utilisateur de saisir un choix valide
            while (!int.TryParse(Console.ReadLine(), out choixUtilisateur) || choixUtilisateur < 1 || choixUtilisateur > 3)
            {
                Console.WriteLine("Veuillez saisir un choix valide (1, 2 ou 3) : ");
            }

            switch (choixUtilisateur)
            {
                case 1:
                    Console.WriteLine("Vous avez choisi de suivre.");
                    pot = pot + mise;
                    argent[0] = argent[0] - mise;
                    break;

                case 2:
                    Console.WriteLine("Vous avez choisi de vous coucher.");
                    ifCouche = true;
                    break;

                case 3:
                    Console.WriteLine("Vous avez choisi de relancer.");
                    break;

                default:
                    Console.WriteLine("Erreur choix non reconnu.");
                    break;
            }
        }

    }
}
