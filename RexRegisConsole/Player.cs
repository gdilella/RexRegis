using System;
using System.Collections.Generic;

namespace RexRegisConsole
{
    public interface IPlayer
    {
        int ID { get; set; }
        List<Card> Hand { get; set; }
        Rank Rank { get; set;}
        void PlayTurn();
        bool InGame { get; }
    }

    public abstract class Player : IPlayer
    {
        int iD;
        List<Card> hand;
        Rank rank;

        public int ID
        {
            get
            {
                return iD;
            }

            set
            {
                iD = value;
            }
        }
        public List<Card> Hand
        {
            get
            {
                return hand;
            }

            set
            {
                hand = value;
            }
        }
        public Rank Rank
        {
            get
            {
                return rank;
            }

            set
            {
                rank = value;
            }
        }
        public bool InGame
        {
            get
            {
                return hand.Count != 0;
            }
        }

        public abstract void PlayTurn();

        //OTTIMIZZARE: BUBBLESORT PUZZA
		//magari implementare il Selection Sort perchè stiamo ordinando una mano di carte?
		//(hue hue hue)
        public void OrderHand()
        {
            bool scambio = true;
            while(scambio)
            {
                scambio = false;
                for(int i = 0; i < hand.Count - 1; i++)
                {
                    if(hand[i].Numero > hand[i+1].Numero)
                    {
                        Card c = hand[i+1];
                        hand[i+1] = hand[i];
                        hand[i] = c;

                        scambio = true;
                    }
                }
            }
        }

		//per le mosse utilizzare questo piuttosto che farlo a mano
		protected void Move(List<Card> playedCards)
		{
			Move move = new Move(iD,false,playedCards);
			Program.game.Table.AddMove(move);
			Console.WriteLine(move.ToString());
			hand.RemoveAll(x => playedCards.Contains(x));
		}

        //usare questo per passare il turno
        protected void Pass()
        {
            Move move = new Move(iD, true, null);
            Program.game.Table.AddMove(move);
            Console.WriteLine(move.ToString());
        }
    }

    public enum Rank
    {
        Re,
        Mercante,
        Cittadino,
        Pezzente
    }
}