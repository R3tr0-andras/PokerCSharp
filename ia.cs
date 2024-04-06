using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerCSharp
{
    public struct ia
    {
        public void JouerIa(int i, ref int mise, ref int[] argent, ref int pot)
        {
            Random rand = new Random();
            int choix = rand.Next(2);
            int montantMinimum = mise + 1;
            int montantMaximum = argent[i];

            // Assurer que montantMinimum est inférieur ou égal à montantMaximum
            if (montantMinimum > montantMaximum)
            {
                int temp = montantMinimum;
                montantMinimum = montantMaximum;
                montantMaximum = temp;
            }

            int montantRelance = rand.Next(montantMinimum, montantMaximum + 1);

            if (argent[i] > mise && choix == 0)
            {
                // Relancer
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine($"║ Joueur ia {i} a choisi de relancer.            ║");
                Console.WriteLine($"║ Joueur ia {i} relance de {montantRelance}.                  ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");

                // Déduire le montant de relance de l'argent du joueur
                argent[i] -= montantRelance;
                // Ajouter le montant de relance au pot
                pot += montantRelance;
                // Définir la nouvelle mise
                mise = montantRelance;
            }
            else
            {
                // Suivre
                Console.WriteLine("╔══════════════════════════════════════════════╗");
                Console.WriteLine($"║ Joueur ia {i} a choisi de suivre.              ║");
                Console.WriteLine("╚══════════════════════════════════════════════╝");

                // Le joueur suit en ajoutant sa mise actuelle au pot
                pot += mise;
                // Mettre à zéro la mise du joueur
                argent[i] -= mise;
            }
        }
    }
}
