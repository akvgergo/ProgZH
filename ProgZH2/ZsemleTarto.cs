using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZH2
{
    class ZsemleTarto : ISzamol
    {
        //lista az kb ugyanaz mint egy tömb, csak van Add metódusa ami kényelmes, és Length helyett Count az elemek száma.
        List<Zsemle> zsemleList;

        public ZsemleTarto(int zsemleDB)
        {
            //lista létrehozása + feltöltés, megint ügyelünk hogy dmin ne legyen nagyobb mint a dmax
            zsemleList = new List<Zsemle>(zsemleDB);
            Random rnd = new Random();

            for (int i = 0; i < zsemleDB; i++)
            {
                var d1 = rnd.Next(5, 16);
                var d2 = rnd.Next(5, 16);
                Zsemle zsemle;

                if (d1 > d2)
                {
                    zsemle = new Zsemle(d2, d1);
                }
                else
                {
                    zsemle = new Zsemle(d1, d2);
                }

                zsemleList.Add(zsemle);
            }

        }

        //mint az A feladatban a Zsemle.ToString(), csak most az összeset kell egybe, tehát mint ott csak összeadjuk
        //for, foreach, tökmindegy
        public override string ToString()
        {
            string szoveg = "";
            foreach (var zsemle in zsemleList)
            {
                szoveg += string.Format("d({0};{1}) T({2})\n", zsemle.dmin, zsemle.dmax, Math.Round(zsemle.TAlap, 2));
            }
            return szoveg;
        }

        public void Legkerekebb()
        {
            //Saját ZH-ban pont így csináltam, és max pont de a tanárnő közölte hogy "nem szép" a megoldás
            //ha te tudod mire gondolt, kérek segítséget
            
            //A legkerekebb zsemlét keressük, tehát a legkisebb deformitás a nyerő
            //A MaxValue azért kell, hogy a ciklusban a legelső zsemle mindenkébb ki legyen választva
            int index = 0;
            double Index_deform = double.MaxValue;

            //itt kiszámítjuk a deformitást majd összehasonlítjuk az eddigi legkisebb értékkel
            //ha kisebb, megjegyezzük az indexet és a deformitást
            for (int i = 0; i < zsemleList.Count; i++)
            {
                var zs = zsemleList[i];
                double deform = ((double)zs.dmax - zs.dmin) / (((double)zs.dmin + zs.dmax) / 2);

                if (deform < Index_deform)
                {
                    index = i;
                    Index_deform = deform;
                }
            }

            //megjegyzett index alatt van a legkevésbé deformált zsemle
            Console.WriteLine("A(z) \"{0}\" indexű, {1} alapterületű zsemle a legkerekebb a listában!", index, Math.Round(zsemleList[index].TAlap, 2));
            Console.WriteLine("(Deformitás: {0})", Index_deform);
        }

        public double OsszTAlap()
        {
            //LINQ-s Sum a legjobb ha a feladat összeget kér
            return zsemleList.Sum(zs => zs.TAlap);
        }
    }
}