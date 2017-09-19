using System;
using System.Collections.Generic;
using System.Linq;

namespace Haushaltsbuch
{
    public class Interactor
    {
        public void Haushaltsbuchung(string[] arguments)
        {   
            if (arguments.Length == 0)
            {
                Console.WriteLine("No Argument");
                return;
            }

            var kategorie = new ArgumentPruefer().ErsteArgPruefer(arguments.First().ToLower());
            if (kategorie == 0)
            {
                Console.WriteLine("Kein gültige Kategorie");
                return;
            }

            DataCreator datalist = new DataCreator();
            datalist.LinesIntoData(new TextFileProvider().ReadTextFile("data.txt"));

            var price = "";
            var art = "";
            var memo = "";

            DatumConverter getdatum = new DatumConverter();
            if (getdatum.DatumFormat(kategorie, arguments))
            {
                if (arguments.Length > 2) { price = arguments[2];}
                if (arguments.Length > 3) { art = arguments[3];}
                if (arguments.Length > 4) { memo = arguments[4];}
            }
            else
            {
                if (arguments.Length > 1) { price = arguments[1];}
                if (arguments.Length > 2) { art = arguments[2];}
                if (arguments.Length > 3) { memo = arguments[3];}
                getdatum.DateAktuell = DateTime.Today;
            }

            if ((kategorie == 3) && (art == ""))
            {
                Console.WriteLine("Keine Art angegeben für Auszahlung");
                return;
            }

            switch (kategorie)
            {
                case 1: //übersicht
                    Console.WriteLine(getdatum.DateAktuell.Month + " " + getdatum.DateAktuell.Year);
                    Console.WriteLine("------------------------");
                    var result1 = new Overview().ShowOverview(getdatum.DateAktuell,datalist.AllData);
                    Console.WriteLine(string.Join(Environment.NewLine, result1.Cast<string>().ToArray()));
                    break;
                case 2: //einzahlung
                    Console.WriteLine(Environment.NewLine+getdatum.DateAktuell.ToShortDateString());
                    var result2 = new Deposit().ShowDeposit(getdatum.DateAktuell, datalist.AllData, Convert.ToDecimal(price), memo);
                    Console.WriteLine(result2);
                    break;
                case 3: //auszahlung
                    Console.WriteLine(Environment.NewLine + getdatum.DateAktuell.ToShortDateString());
                    if (!new ExistingKat().Exists(datalist.AllData, art))
                    {
                        NewWhidrawKategorie(datalist.AllData, art);
                    }
                    if (new ExistingKat().Exists(datalist.AllData, art))
                    {
                        var result3 = new Withdraw().ShowWithdraw(getdatum.DateAktuell, datalist.AllData, art, Convert.ToDecimal(price), memo);
                        Console.WriteLine(string.Join(Environment.NewLine, result3.Cast<string>().ToArray()));
                    }                                    
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            var listToSave = new DataToList().CreateList(datalist.AllData);
            new TextFileSaver().SaveTextFile("data.txt",listToSave);
            Console.ReadLine();
        }

        private static void NewWhidrawKategorie(List<DataObject> alldata, string art)
        {
            Console.WriteLine("Soll die Kategorie " + art + " neu angelegt werden? (j/n):");
            if (Console.ReadKey().Key == ConsoleKey.J)
            {
                alldata.Add(new DataObject(art, new List<DateTime>(), new List<decimal>(), new List<string>()));
            }
        }
    }
}