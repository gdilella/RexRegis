using System;
using System.Collections.Generic;

namespace RexRegisConsole
{
    public class BotPlayer : Player
    {
        //Table table = Program.game.Table;

        public override void PlayTurn()
        {
            if(Program.game.Table.IsTableClean)
            {
                List<Card> cards = new List<Card>();
                cards.Add(Hand[0]);
                Move(cards);
            }
            else
            {
                bool moved = false;
                int i = 0;

                while (!moved && i < Hand.Count)
                {
                    if(Hand[i].Numero > Program.game.Table.LastMove.CardValue)
                    {
                        List<Card> cards = new List<Card>();
                        cards.Add(Hand[i]);
                        Move(cards);
                        moved = true;
                    }

                    i++;
                }

                if (!moved)
                    Pass();
            }
        }
    }
}