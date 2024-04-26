using System;
using System.Numerics;

namespace PokerCSharp
{
    /// <summary>
    /// Cette structure contient les méthodes pour interagir avec les joueurs et afficher les informations du jeu de poker.
    /// </summary>
    public struct interact
    {

        // <summary>
        /// Demande à l'utilisateur de spécifier le nombre de joueurs autour de la table.
        /// </summary>
        /// <param name="joueurActuel">Le nombre de joueurs spécifié par l'utilisateur.</param>
        public void NPlayer(ref int joueurActuel)
        {
            // Boucle pour demander à l'utilisateur de saisir un nombre valide de joueurs
            do
            {
                // Affiche la question pour le nombre de joueurs
                Console.WriteLine("Combien de joueur voulez-vous avoir autour de la table ? (4 minimum et 6 maximum)");
                // Lecture de l'entrée de l'utilisateur
                string? nb = Console.ReadLine();

                // Vérifie si l'entrée peut être convertie en un entier
                if (!int.TryParse(nb, out joueurActuel))
                {
                    // Efface la console et affiche un message d'erreur si l'entrée n'est pas valide
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer un nombre valide.");
                    continue;
                }

                // Vérifie si le nombre de joueurs est dans la plage autorisée (entre 4 et 6 inclus)
                if (joueurActuel < 4 || joueurActuel > 6)
                {
                    // Efface la console et affiche un message d'erreur si le nombre de joueurs n'est pas dans la plage autorisée
                    Console.Clear();
                    Console.WriteLine("Veuillez entrer un nombre entre 4 et 6.");
                    continue;
                }

                // Affiche le nombre de joueurs choisi par l'utilisateur
                Console.WriteLine(joueurActuel);
                // Sort de la boucle, car un nombre valide a été saisi
                break;
            } while (true); // Continue la boucle indéfiniment jusqu'à ce qu'un nombre valide soit saisi
        }

        /// <summary>
        /// Permet à l'utilisateur de prendre une décision pendant son tour de jeu.
        /// </summary>
        /// <param name="pot">Le montant total du pot.</param>
        /// <param name="mise">La mise actuelle.</param>
        /// <param name="argent">Les jetons disponibles pour chaque joueur.</param>
        /// <param name="tapisPlayer">Indique si le joueur a misé tous ses jetons (all-in).</param>
        /// <returns>True si le joueur se couche, sinon False.</returns>
        public bool FaireJouerUser(ref int pot, ref int mise, ref int[] argent, ref bool tapisPlayer)
        {
            // Variable pour indiquer si le joueur s'est couché
            bool couche = false;

            // Affichage des options pour le joueur
            Console.WriteLine("Que décidez-vous ?");
            Console.WriteLine("1. Suivre");
            Console.WriteLine("2. Se coucher");
            Console.WriteLine("3. Relancer");
            Console.Write("Votre choix : ");

            // Variable pour stocker le choix de l'utilisateur
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

            // Traitement du choix de l'utilisateur
            switch (choixUtilisateur)
            {
                // Suivre le jeu
                case 1:
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de suivre.");
                    // Ajout de la mise actuelle au pot et soustraction de la mise du joueur de ses jetons
                    pot = pot + mise;
                    argent[0] = argent[0] - mise;
                    break;

                // Se coucher (abandonner)
                case 2:
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de vous coucher.");
                    // Indique que le joueur s'est couché
                    couche = true;
                    break;

                // Relancer (miser plus)
                case 3:
                    Console.Clear();
                    Console.WriteLine("Vous avez choisi de relancer.");
                    Console.WriteLine($"Vous avez actuellement {argent[0]} jetons.");
                    Console.WriteLine("De combien ?");
                    // Demande au joueur le montant de la nouvelle mise
                    int nouvelleMise;

                    // Boucle pour s'assurer que le montant de la mise est valide
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

                        // Si le joueur mise tous ses jetons, il est en "all-in"
                        if (nouvelleMise == argent[0])
                        {
                            tapisPlayer = true;
                            Console.WriteLine("Vous avez misé tous vos jetons (all-in) !");
                        }

                    } while (!montantValide);

                    // Mise à jour de la mise actuelle
                    mise = nouvelleMise;
                    break;

                // Erreur dans le switch
                default:
                    Console.WriteLine("Erreur choix non reconnu.");
                    break;
            }
            // Retourne l'indicateur si le joueur s'est couché ou non
            return couche;
        }


        /// <summary>
        /// Affiche les cartes actuellement sur la table.
        /// </summary>
        /// <param name="table">Tableau contenant les cartes sur la table.</param>
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

        /// <summary>
        /// Affiche le montant actuel du pot.
        /// </summary>
        /// <param name="pot">Le montant total du pot.</param>
        public void ShowPot(ref int pot)
        {
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine($"║   Le pot est de :       ║");
            Console.WriteLine($"║   {pot}                 ║");
            Console.WriteLine("╚═══════════════════════╝");
        }

        /// <summary>
        /// Affiche le nombre de jetons restants pour le joueur.
        /// </summary>
        /// <param name="argent">Le nombre de jetons du joueur.</param>
        public void ShowPlayerMoney(ref int[] argent)
        {
            Console.WriteLine("╔═══════════════════════╗");
            Console.WriteLine($"║   Vous avez :           ║");
            Console.WriteLine($"║   {argent[0]} jetons      ║");
            Console.WriteLine("╚═══════════════════════╝");
        }

        /// <summary>
        /// Affiche les cartes du joueur.
        /// </summary>
        /// <param name="handPlayer">Matrice contenant les cartes du joueur.</param>
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

        /// <summary>
        /// Affiche les mains des autres joueurs à la table.
        /// </summary>
        /// <param name="handPlayer">Matrice contenant les cartes de tous les joueurs.</param>
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

        /// <summary>
        /// Réinitialise les différentes valeurs du jeu (pot, cartes, etc.) pour une nouvelle manche.
        /// </summary>
        /// <param name="suits">Liste des enseignes des cartes.</param>
        /// <param name="ranks">Liste des valeurs des cartes.</param>
        /// <param name="deck">Liste complète des cartes.</param>
        /// <param name="handPlayer">Matrice contenant les cartes de tous les joueurs.</param>
        /// <param name="compteur">Compteur utilisé pour suivre le déroulement du jeu.</param>
        /// <param name="table">Tableau contenant les cartes sur la table.</param>
        /// <param name="pot">Le montant total du pot.</param>
        /// <param name="tapisPlayer">Indique si le joueur a misé tous ses jetons (all-in).</param>
        public void Clear(ref List<string> suits, ref List<string> ranks, ref List<string> deck,
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
            tapisPlayer = false;
        }
    }
}
