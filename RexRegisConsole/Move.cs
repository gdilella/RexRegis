using System;
using System.Collections.Generic;

namespace RexRegisConsole
{
    public class Move
    {
        int playerID;
		bool passed;
		List<Card> playedCards;

        public int PlayerID
        {
            get
            {
                return playerID;
            }
        }
		public bool Passed 
		{
			get 
			{
				return passed;
			}

		}

		public List<Card> PlayedCards
		{
			get
			{
				return playedCards;
			}
		}

        public int NumberOfCards
        {
            get
            {
				if (!passed)
					return playedCards.Count;
				else
					return 0;
            }
        }

        public Value CardValue
        {
            get
            {
                return playedCards [0].Numero;
            }
        }

		public Move(int id, bool passed, List<Card> playedCards)
        {
            playerID = id;
			this.passed = passed;
			this.playedCards = playedCards;
        }

        public override string ToString()
        {
			if (!passed) 
			{
				string ag;
				switch (NumberOfCards) 
				{
				case 1:
					ag = "";
					break;
				case 2:
					ag = "coppia di ";
					break;
				case 3:
					ag = "tris di ";
					break;
				case 4:
					ag = "poker di ";
					break;
				default:
					throw new FormatException ("Questa mossa contiene più di quattro carte!");
				}

				return playerID.ToString () + ": " + ag + playedCards[0].Numero;
			} 
			else 
			{
				return playerID.ToString() + ": " + "Passed";
			}
        }
    }
}