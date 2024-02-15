namespace PokerCSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int joueurActuel = 4;

            //Mes librairies
            Card traitementCard = new Card();
            ia player = new ia();

            List<string> suits = new List<string> { "Coeur", "Carreau", "Trèfle", "Pique" };
            List<string> ranks = new List<string> { "As", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Roi", "Reine", "Valet" };

            List<string> deck = traitementCard.CreateDeck(suits, ranks);
            traitementCard.ShuffleDeck(deck);

            List<string> players = new List<string>();


            //foreach (string decks in deck)
            //{
            //Console.WriteLine(decks);
            //}

            string[,] handPlayer = player.initializeAndDistribute(joueurActuel, deck);
            // Afficher la matrice
            for (int i = 0; i < joueurActuel; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(handPlayer[i, j] + " ");
                }
                Console.WriteLine();
            }


        }
    }
}