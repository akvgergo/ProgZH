using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZH2
{
    //B csoport
    class Program
    {
        static void Main(string[] args)
        {
            //mint az A csopi, csak a minimum érték más.
            int db;
            Console.WriteLine("Kérem adja meg a zsömlék számát. Az érték legalább 15 legyen!");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out db) && db > 14) break;
                Console.WriteLine("Nem megfelelő az érték! Kérem próbálja újra.");
            }
            Console.WriteLine();

            //Zsemletartót létrehozzuk, függvényeit leteszteljük, gól
            ZsemleTarto zsemleTarto = new ZsemleTarto(db);

            Console.WriteLine("Legkerekebb zsemle:");
            zsemleTarto.Legkerekebb();
            Console.WriteLine();

            Console.WriteLine("A zsemlék alapterülete összesen:");
            Console.WriteLine(zsemleTarto.OsszTAlap());
            Console.WriteLine();

            Console.WriteLine("A zsemlék adatai:");
            Console.WriteLine(zsemleTarto.ToString());

            Console.ReadKey();
        }
    }
}
