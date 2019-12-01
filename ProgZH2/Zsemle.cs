using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgZH2
{
    //ennek jó része copy-paste az A csoportból
    class Zsemle
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

    }
}
