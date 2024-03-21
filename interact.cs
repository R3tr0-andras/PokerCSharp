using System;

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
        
    }
}
