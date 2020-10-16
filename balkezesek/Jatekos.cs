using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace balkezesek
{
    class Jatekos
    {
        public string Nev { get; private set; }
        public string Elso { get; private set; }
        public string Utolso { get; private set; }
        public int Suly { get; private set; }
        public double Magassag { get; private set; }

        public Jatekos(string szoveg)
        {
            string[] adat = szoveg.Split(';');
            Nev = adat[0];
            Elso = adat[1];
            Utolso = adat[2];
            Suly = int.Parse(adat[3]);
            Magassag = Convert.ToDouble(adat[4]);
        }
    }
            

}
