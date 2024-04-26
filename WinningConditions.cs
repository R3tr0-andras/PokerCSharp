using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCSharp
{
    /// <summary>
    /// Cette structure représente les conditions de victoire dans le jeu de poker.
    /// </summary>
    public struct WinningConditions
    {
        /// <summary>
        /// Méthode pour déterminer le gagnant parmi les joueurs actifs.
        /// </summary>
        /// <param name="handPlayer">Les mains des joueurs.</param>
        /// <param name="table">Les cartes sur la table.</param>
        /// <param name="argent">Les jetons des joueurs.</param>
        /// <param name="pot">Le pot.</param>
        public void DetermineWinner(ref string[,] handPlayer, ref string[] table, ref int[] argent, ref int pot)
        {
            // Définir les valeurs des mains des joueurs actifs
            Dictionary<int, int> playerValues = new Dictionary<int, int>(); // Mapping joueur -> valeur de la main
            for (int i = 0; i < handPlayer.GetLength(0); i++)
            {
                List<string> hand = new List<string>();
                for (int j = 0; j < handPlayer.GetLength(1); j++)
                {
                    // Ajouter les cartes non vides de la main du joueur à une liste
                    if (!string.IsNullOrEmpty(handPlayer[i, j]))
                    {
                        hand.Add(handPlayer[i, j]);
                    }
                }
                // Ajouter les cartes sur la table à la main du joueur
                hand.AddRange(table);

                // Évaluer la main du joueur seulement s'il n'est pas couché
                if (hand.Count > 0) // Vérifier si le joueur a au moins une carte en main
                {
                    // Évaluer la force de la main du joueur
                    int value = EvaluateHand(hand.ToArray());
                    // Ajouter la valeur de la main du joueur dans le dictionnaire
                    playerValues.Add(i, value);
                }
            }

            // Vérifier si un joueur s'est couché
            bool anyPlayerFolded = playerValues.Count < handPlayer.GetLength(0);

            if (!anyPlayerFolded)
            {
                // Trouver la valeur maximale parmi les mains des joueurs actifs
                int maxValue = playerValues.Values.Max();

                // Trouver les joueurs actifs avec la meilleure main
                List<int> activeWinners = playerValues.Where(kv => kv.Value == maxValue).Select(kv => kv.Key).ToList();

                // Vérifier s'il n'y a qu'un seul gagnant actif
                if (activeWinners.Count == 1)
                {
                    // S'il y a un seul gagnant, il remporte tout le pot
                    int winner = activeWinners[0];
                    argent[winner] += pot;
                    Console.WriteLine($"Le joueur {winner + 1} remporte le pot de {pot} jetons !");
                    pot = 0; // Remettre le pot à zéro
                }
                else
                {
                    // S'il y a plusieurs gagnants, le pot est partagé entre eux
                    int potPerWinner = pot / activeWinners.Count;
                    foreach (int winner in activeWinners)
                    {
                        argent[winner] += potPerWinner;
                    }
                    Console.WriteLine("Il y a une égalité ! Le pot est partagé entre les joueurs gagnants.");
                    pot = 0; // Remettre le pot à zéro
                }
            }
            else
            {
                // Si un joueur s'est couché, il ne peut pas gagner le pot
                Console.WriteLine("Un joueur s'est couché, il ne peut pas gagner le pot.");
            }
        }

        /// <summary>
        /// Fonction pour évaluer la force d'une main de poker donnée.
        /// </summary>
        /// <param name="hand">La main à évaluer.</param>
        /// <returns>Le score correspondant à la force de la main.</returns>
        public int EvaluateHand(string[] hand)
        {
            // Compter les occurrences de chaque rang et chaque couleur
            Dictionary<string, int> rankCount = new Dictionary<string, int>(); // Compteur pour les rangs
            Dictionary<string, int> suitCount = new Dictionary<string, int>(); // Compteur pour les couleurs

            foreach (string card in hand)
            {
                // Séparer la carte en rang et couleur
                string rank = card.Split(' ')[0]; // Le premier élément est le rang
                string suit = card.Split(' ')[1]; // Le deuxième élément est la couleur

                // Incrémenter le compteur de rangs
                if (!rankCount.ContainsKey(rank))
                    rankCount[rank] = 1;
                else
                    rankCount[rank]++;

                // Incrémenter le compteur de couleurs
                if (!suitCount.ContainsKey(suit))
                    suitCount[suit] = 1;
                else
                    suitCount[suit]++;
            }

            // Vérifier les combinaisons possibles
            bool isFlush = suitCount.ContainsValue(5); // Vérifier s'il y a une couleur
            bool isStraight = IsStraight(rankCount); // Vérifier s'il y a une suite

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

        /// <summary>
        /// Méthode pour vérifier si une main contient une suite.
        /// </summary>
        /// <param name="rankCount">Le nombre de cartes de chaque rang.</param>
        /// <returns>True si une suite est présente, sinon False.</returns>
        public bool IsStraight(Dictionary<string, int> rankCount)
        {
            int count = 0; // Compteur pour suivre le nombre de rangs consécutifs

            // Parcourir le dictionnaire contenant le nombre de cartes de chaque rang
            foreach (var kvp in rankCount)
            {
                // Vérifier si le nombre de cartes du rang actuel est égal à 1 (carte unique)
                if (kvp.Value == 1)
                {
                    count++; // Incrémenter le compteur de rangs consécutifs

                    // Vérifier si une suite de 5 cartes consécutives a été trouvée
                    if (count == 5)
                        return true; // Retourner vrai si une suite a été trouvée
                }
                else
                {
                    count = 0; // Réinitialiser le compteur si une carte n'est pas unique
                }
            }

            return false; // Retourner faux si aucune suite n'a été trouvée
        }

        /// <summary>
        /// Méthode pour vérifier si une main contient deux paires.
        /// </summary>
        /// <param name="rankCount">Le nombre de cartes de chaque rang.</param>
        /// <returns>True si deux paires sont présentes, sinon False.</returns>
        public bool IsTwoPair(Dictionary<string, int> rankCount)
        {
            int pairCount = 0; // Compteur pour suivre le nombre de paires trouvées

            // Parcourir le dictionnaire contenant le nombre de cartes de chaque rang
            foreach (var kvp in rankCount)
            {
                // Vérifier si le nombre de cartes du rang actuel est égal à 2 (une paire)
                if (kvp.Value == 2)
                    pairCount++; // Incrémenter le compteur de paires trouvées

                // Vérifier si deux paires ont été trouvées
                if (pairCount == 2)
                    return true; // Retourner vrai si deux paires ont été trouvées
            }

            return false; // Retourner faux si moins de deux paires ont été trouvées
        }
    }
}
