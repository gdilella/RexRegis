using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RexRegisConsole
{
    class Program
    {
        public static Game game;

        static void Main(string[] args)
        {
            bool stop = false;
            Console.WriteLine("Rex Regis by Gianmarco Di Lella.");


            game = new Game();

            while (!stop)
            {
                game.PlayMatch();

				Console.WriteLine ("Continuare? [s/n]");
                string response = Console.ReadLine();

				if (response == "s")
					stop = false;
				else
					stop = true;
            }

			Console.WriteLine("Partita finita, premi un tasto qualsiasi per chiudere");
			Console.ReadLine();
        }
    }
}
