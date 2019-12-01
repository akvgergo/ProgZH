using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZH
{
    //CompareTo() az az Icomparable-nek a metódusa, azt implementálni kell
    class Zsemle : IComparable
    {

        //auto-implementált tulajdonságok, ezeket a tanár elfogadja de a névre ügyelni kell mert ami félkövér a dolgozatba
        //az minuszpont ha programba más a neve. Lekérdező tulajdonságot kér a feladat úgyhogy a "set" az privát
        public int dmin { get; private set; }

        public int dmax { get; private set; }

        public double TAlap { get; private set; }

        //jó konvenció "_"-lel kezdeni változónevet, ha az eredeti már foglalt, itt a tulajdonságok miatt
        public Zsemle(int _dmin, int _dmax)
        {
            dmin = _dmin;
            dmax = _dmax;

            //double-re átváltjuk az egyik int-et, különben egész számos osztás lesz és tizedestörtet elveszítjük
            var r = ((double)dmax + dmin) / 4;
            TAlap = r * r * Math.PI;
        }

        public int CompareTo(object obj)
        {
            //as-operátor átalakítja az objektumot az adott típusra, ha az átalakítás sikertelen akkor null-t ad vissza
            var zsemle = obj as Zsemle;
            //ha null akkor hiba történt és kivételt dobunk
            if (zsemle == null) throw new ArgumentException("obj");
            //ha nem akkor TAlap alapján összehasonlítunk
            return TAlap.CompareTo(zsemle.TAlap);
        }

        public override string ToString()
        {
            //itt + jelekkel is összeadogathatnánk, ez szerintem kényelmesebb, de teljes mértékben preferencia kérdése
            //Math.Round az fontos mert a feladatban a minta 2 tizedesjegyet kér
            return string.Format("d({0};{1}) T({2})", dmin, dmax, Math.Round(TAlap, 2));
        }

        public double Deformitás()
        {
            return (double)(dmax - dmin) / ((dmax + dmin) / 2);
        }
    }
}
