using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace balkezesek
{
    class Program
    {
        static List<Jatekos> jatekosok = new List<Jatekos>();
        static List<Jatekos> szurt = new List<Jatekos>();
        static int evszam;

        static void Beolvas()
        {
            StreamReader file = new StreamReader("balkezesek.csv");

            file.ReadLine();
            while (!file.EndOfStream)
            {
                jatekosok.Add(new Jatekos(file.ReadLine()));
            }

            file.Close();
        }

        static void Feladat3()
        {
            Console.WriteLine("3. feladat: {0}", jatekosok.Count);
        }

        static void Feladat4()
        {
            Console.WriteLine("4. feladat:");
            //var jatekos = from j in jatekosok where j.Utolso.Contains("1999-10") select j;
            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (jatekosok[i].Utolso.Contains("1999-10"))
                {
                    szurt.Add(jatekosok[i]);
                }
            }

            for (int i = 0; i < szurt.Count; i++)
            {
                Console.WriteLine("\t{0}, {1:N1}", szurt[i].Nev, szurt[i].Magassag * 2.54);
            }

        }

        static void Feladat5()
        {
            Console.Write("Kérek egy 1990 és 1999 közötti évszámot!: ");
            evszam = Convert.ToInt32(Console.ReadLine());
            while (evszam < 1990 || evszam > 1999)
            {
                Console.Write("Hibás adat! Kérek egy 1990 és 1999 közötti évszámot!: ");
                evszam = Convert.ToInt32(Console.ReadLine());
            }
        }

        static void Feladat6()
        {
            Console.Write("6. feladat: ");
            double suly = 0;
            int db = 0;

            for (int i = 0; i < jatekosok.Count; i++)
            {
                if (evszam >= Datum(jatekosok[i].Elso) && evszam <= Datum(jatekosok[i].Utolso))
                {
                    suly += jatekosok[i].Suly;
                    db++;
                }
            }
            Console.Write("{0:N2} font \n",suly/db);
        }

        static int Datum(string datum)
        {
            string[] adat = datum.Split('-');
            return int.Parse(adat[0]);
        }

        static void FeladatBonusz()
        {
            var abc = from j in jatekosok
                      orderby j.Nev
                      group j by j.Nev[0] into abcTemp
                      select abcTemp;

            foreach (var abcGroup in abc)
            {
                Console.WriteLine(abcGroup.Key);
                foreach (var item in abcGroup)
                {
                    Console.WriteLine($"\t{item.Nev}");
                }
            }
        }

        static void Main(string[] args)
        {
            Beolvas();
            Feladat3();
            Feladat4();
            Feladat5();
            Feladat6();
            FeladatBonusz();



            Console.ReadKey();
        }
    }
}
