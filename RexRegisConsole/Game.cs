using System;
using System.Collections.Generic;

namespace RexRegisConsole
{
    public class Game
    {
        List<IPlayer> players;
        List<Card> deck;
        int matchNumber;
        int active;

		Table table;

        IPlayer ActivePlayer
        {
            get
            {
                return players[active];
            }
        }

		public Table Table
		{
			get
			{
				return table;
			}
		}

        public Game()
        {
            players = new List<IPlayer>();
            deck = new List<Card>();
            table = new Table();
            matchNumber = 0;

            //crea il deck
            BuildDeck();

            //Crea i giocatori
            for(int i = 0; i < 4; i++)
            {
                BotPlayer p = new BotPlayer();
                p.ID = i;
                p.Rank = Rank.Cittadino;
                p.Hand = GetHand(i);

                players.Add(p);
            }

            OrderPlayersHands();
        }
        

        public void PlayMatch()
        {
            Console.WriteLine(table.ToString());
            matchNumber++;
            //setta il giocatore attivo (se non è il primo giro viene resettato)
            active = new Random().Next(0, 4);

            if (matchNumber != 1)
                SetPreGame();

            table.CleanTable();
            table.MoveHistory.Clear();

            int activePlayers = 4;

            while(activePlayers > 1)
            {
                //Può giocare (ha almeno una carta?)
                if (ActivePlayer.InGame)
                {
                    //se tutti hanno passato e lui è stato l'ultimo a muovere
                    if (table.IsTableClean == false && ActivePlayer.ID == table.LastMove.PlayerID)
                    {
                        Console.WriteLine("TAVOLO PULITO");
                        table.CleanTable();
                    }

                    ActivePlayer.PlayTurn();

                    //se ha finito le carte in questo turno
                    if (!ActivePlayer.InGame)
                    {
                        activePlayers--;

                        switch (activePlayers)
                        {
                            case 3:
                                ActivePlayer.Rank = Rank.Re;
                                break;
                            case 2:
                                ActivePlayer.Rank = Rank.Mercante;
                                break;
                            case 1:
                                ActivePlayer.Rank = Rank.Cittadino;
                                players.Find(x => x.InGame).Rank = Rank.Pezzente;
                                break;
                        }
                    }
                }
                //ha finito di giocare e nessuno ha risposto al suo ultimo giro
                else if (ActivePlayer.ID == table.LastMove.PlayerID)
                {
                    table.CleanTable();
                    Console.WriteLine("TAVOLO PULITO");
                }

                //Console.WriteLine("Turno Finito");

                NextPlayer();
            }

            Console.WriteLine("Re: Giocatore" + players.Find(x => x.Rank == Rank.Re).ID.ToString());
            Console.WriteLine("Mercante: Giocatore" + players.Find(x => x.Rank == Rank.Mercante).ID.ToString());
            Console.WriteLine("Cittadino: Giocatore" + players.Find(x => x.Rank == Rank.Cittadino).ID.ToString());
            Console.WriteLine("Pezzente: Giocatore" + players.Find(x => x.Rank == Rank.Pezzente).ID.ToString());
        }

        
        //TODO: Insegnare lo scambio Re/Pezzente e la meccanica del Mercante
        private void SetPreGame()
        {
            table.MoveHistory.Clear();
            ShuffleDeck();
            for(int i = 0; i < 4; i++)
            {
                players[i].Hand = GetHand(i);
            }

            active = players.Find(x => x.Rank == Rank.Re).ID;

        }
        private void NextPlayer()
        {
            active++;
            if (active == players.Count)
                active = 0;
        }
        private int NextPlayer(int x)
        {
            x += 1;

            if (x == players.Count)
                x = 0;

            return x;
        }
        private void BuildDeck()
        {
            //AGGINGE LE CARTE
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Card c = new Card();

                    c.Numero = (Value)j;
                    c.Seme = (Seme)i;

                    deck.Add(c);
                }
            }

            Console.WriteLine("NUMERO DI CARTE: " + deck.Count);
            ShuffleDeck();

        }
        private void ShuffleDeck()
        {
            Random r = new Random();

            for(int i = 0; i < 150; i++)
            {
                int a = r.Next(0, 40);
                int b = r.Next(0, 40);

                Card c = deck[a];
                deck[a] = deck[b];
                deck[b] = c;
            }

            Console.WriteLine("CARTE MESCOLATE");
        }
        public void ShowDeck()
        {
            string s = "";

            foreach(Card c in deck)
            {
                s += c.ToString() + "\n";
            }

            Console.WriteLine(s);
        }
        public List<Card> GetHand(int i)
        {
            return deck.GetRange(i * 10, 10);
        }
        private void OrderPlayersHands()
        {
            foreach (Player p in players)
            {
                p.OrderHand();
            }
        }
    }
}