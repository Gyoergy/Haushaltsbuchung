using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Haushaltsbuch
{
    public class DatumConverter
    {

        public DateTime DateAktuell;
        public bool DatumFormat(byte kategorie, string[] arguments)
        {
            switch (kategorie)
            {
                case 1:
                    if (arguments.Length > 2)
                    {
                        var lastDay = DateTime.DaysInMonth(Convert.ToInt32(arguments[2]), Convert.ToInt32(arguments[1]));
                        var dateString =  lastDay + "/" + arguments[1] + "/" + arguments[2];
                        return TryToConvert(dateString);
                    }
                    return false;
                case 2:
                    if ((arguments.Length > 2) && (arguments[1].Length == 10))
                    {
                        var dateString = arguments[1].Replace('.','/');
                        return TryToConvert(dateString);
                    }
                    return false;
                case 3:
                    if ((arguments.Length > 2) && (arguments[1].Length == 10))
                    {
                        var dateString = arguments[1].Replace('.', '/');
                        return TryToConvert(dateString);
                    }
                    return false;
                default:
                    return false;
            }
        }

        public bool TryToConvert(string dateString)
        {
            try
            {
                DateAktuell = DateTime.Parse(dateString);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Falsches Datumsformat");
                throw;
            }
        }
    }
}
