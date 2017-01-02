namespace RexRegisConsole
{
    public class Card
    {
        Value numero;
        Seme seme;

        public Value Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }
        public Seme Seme
        {
            get
            {
                return seme;
            }

            set
            {
                seme = value;
            }
        }

        public override string ToString()
        {
            return numero.ToString() + " di " + seme.ToString();
        }
    }

    public enum Seme
    {
        Coppe,
        Spade,
        Denari,
        Bastoni
    }

    public enum Value
    {
        Tre,
        Quattro,
        Cinque,
        Sei,
        Sette,
        Otto,
        Nove,
        Re,
        Asso,
        Due
    }
}