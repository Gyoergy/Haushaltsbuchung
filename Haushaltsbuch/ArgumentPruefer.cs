
namespace Haushaltsbuch
{
    public class ArgumentPruefer
    {
        public byte ErsteArgPruefer(string kategorie)
        {
            switch (kategorie)
            {
                    case "übersicht":
                        return 1;
                    case "einzahlung":
                        return 2;
                    case "auszahlung":
                        return 3;
                    default:
                        return 0;
            }
        }
    }
}
