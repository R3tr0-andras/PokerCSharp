using System;
using System.Numerics;

namespace PokerCSharp
{
    public struct interact
    {

        //Demander à L'utilisateur le nombre de joueurs autour de la table
        public void NPlayer(ref int joueurActuel) 
        {
            do
            {
                Console.WriteLine("Combien de joueur voulez-vous avoir autour de la table ? (4 minimum et 6 maximum)");
                string nb = Console.ReadLine();

                if (!int.TryParse(nb, out joueurActuel))
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                    continue;
                }

                if (joueurActuel < 4 || joueurActuel > 6)
                {
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer un nombre entre 4 et 6.");
                    continue;
                }

                Console.WriteLine(joueurActuel);
                break; // Exit
            } while (true);

        }

        public bool FaireJouerUser(ref int pot, ref int mise, ref int[] argent, ref bool tapisPlayer)
        {
            bool couche = false;
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
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de suivre.");
                    pot = pot + mise;
                    argent[0] = argent[0] - mise;
                    break;

                // Se coucher (abondonner)
                case 2:
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de vous coucher.");
                    couche = true;
                    break;

                // Relancer (miser plus)
                case 3:
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de relancer.");
                    Console.WriteLine($"Vous avez actuellement {argent[0]} jetons.");
                    Console.WriteLine("De combien ?");
                    int nouvelleMise;

                    bool montantValide = false;
                    do
                    {
                        if (!int.TryParse(Console.ReadLine(), out nouvelleMise) || nouvelleMise <= mise || nouvelleMise > argent[0])
                        {
                            Console.WriteLine("Veuillez saisir un montant valide.");
                        }
                        else
                        {
                            montantValide = true;
                        }

                        if (nouvelleMise == argent[0])
                        {
                            tapisPlayer = true;
                            Console.WriteLine("Vous avez misé tous vos jetons (all-in) !");
                        }

                    } while (!montantValide);

                    mise = nouvelleMise;
                    break;

                // Erreur dans le switch
                default:
                    Console.WriteLine("Erreur choix non reconnu.");
                    break;
            }
            return couche;
        }

        //Montrer les cartes sur la table
        public void ShowTable(ref string[] table)
        {
            // Affichage des cartes sur la table
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║  Cartes sur la table  ║");
            Console.WriteLine("╠═══════════════════════╣");

            if (table == null || table.Length == 0)
            {
                Console.WriteLine("║        Aucune carte    ║");
            }
            else
            {
                for (int i = 0; i < table.Length; i++)
                {
                    if (table[i] != null)
                    {
                        Console.WriteLine("║   " + table[i].PadRight(18) + "  ║");
                    }
                }
            }

            Console.WriteLine("╚═══════════════════════╝");
        }

        //Montrer Les cartes du joueur
        public void ShowCardPlayer(ref string[,] handPlayer)
        {
            // Affichage des cartes du joueur PP
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine("║   Vos cartes (PP)     ║");
            Console.WriteLine("╠═══════════════════════╣");
            for (int j = 0; j < handPlayer.GetLength(1); j++)
            {
                Console.WriteLine("║   " + handPlayer[0, j].ToString().PadRight(18) + "  ║");
            }
            Console.WriteLine("╚═══════════════════════╝");
        }

        public void ShowOtherPlayersHands(ref string[,] handPlayer)
        {
            Console.WriteLine("╔═════════════════════════════════════╗");
            Console.WriteLine("║        Mains des autres joueurs        ║");
            Console.WriteLine("╠═════════════════════════════════════╣");

            for (int i = 1; i < handPlayer.GetLength(0); i++)
            {
                Console.Write($"║ Joueur {i + 1}: ");
                for (int j = 0; j < handPlayer.GetLength(1); j++)
                {
                    if (!string.IsNullOrEmpty(handPlayer[i, j]))
                    {
                        Console.Write(handPlayer[i, j] + " ");
                    }
                }
                Console.WriteLine("".PadRight(37 - handPlayer.GetLength(1) * 3) + "║");
            }

            Console.WriteLine("╚═════════════════════════════════════╝");
        }
    }
}
