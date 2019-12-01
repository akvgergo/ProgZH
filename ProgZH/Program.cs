using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZH
{
    //A csoport
    class Program
    {
        static void Main(string[] args)
        {

            //"(try)" alatt valszeg a tanár tryparse-t ért, ha nem hát istenem
            int db;
            //addig nyomjuk míg nem sikeres a beolvasás
            //WriteLine-os magyarázkodást hanyaglom mert idő
            Console.WriteLine("Kérem adja meg az értéket");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out db) && db >= 10) break;
                Console.WriteLine("próbálja újra");
            }

            Zsemle[] zsemleTomb = new Zsemle[db];
            Random rnd = new Random();

            //feltöltés
            for (int i = 0; i < db; i++)
            {
                //itt csak arra kell ügyelni hogy dmin ne legyen nagyobb mint a dmax a zsömlékben
                var d1 = rnd.Next(10, 21);
                var d2 = rnd.Next(10, 21);

                if (d1 > d2)
                {
                    zsemleTomb[i] = new Zsemle(d2, d1);
                }
                else
                {
                    zsemleTomb[i] = new Zsemle(d1, d2);
                }

            }

            //ez csak akkor működik a ha CompareTo() metódus definiálva van. Ha nem működik, ott a hiba a Zsemle osztályban
            Array.Sort(zsemleTomb);

            //tagok kiírása
            foreach (var zsemle in zsemleTomb)
            {
                Console.Write(zsemle.ToString());
                Console.Write("\t"); //tabbal elválasztjuk
                Console.WriteLine("deformitás: {0}", zsemle.Deformitás());
            }

            //LINQ halmazművelet, deformitás alapján csökkenő sorba rakjuk a zsömléket, ezután a sor legelső eleme a legdeformáltabb
            var legdeformalt = zsemleTomb.OrderByDescending(zs => zs.Deformitás()).First();
            Console.WriteLine("Legdeformáltabb: {0}", legdeformalt.ToString());

            Console.ReadKey();
        }
    }
}
