using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace footgolf
{
    class Program
    {
        static List<versenyzo> versenyzok;
        static void Main(string[] args)
        {
            feltolt();
            f3();
            f4();
            f6();
            f7();
            f8();
            Console.ReadKey();
        }

        private static void f8()
        {
            foreach (var t in versenyzok.GroupBy(v => v.egyesulet).Select(group => new {karegoria = group.Key, szam = group.Count()}))
            {
                if (t.karegoria != "n.a." && t.szam>2)
                {
                    Console.WriteLine(t.karegoria + " " + t.szam);
                }
            }
        }

        private static void f7()
        {
            var sw = new StreamWriter(@"osszpontFF.txt",true);
            foreach (var v in versenyzok)
            {
                if (v.kategoria == "Felnott ferfi") sw.WriteLine(v.nev + ";" + v.oszpontszam());
            }
            sw.Close();
        }

        private static void f6()
        {
            Console.WriteLine("6. feladat: A bajnok női versenyző");
            versenyzo v = versenyzok.Where(f => f.kategoria == "Noi").OrderBy(f => f.oszpontszam()).Last();
            Console.WriteLine("\tNév: "+v.nev+"\n\tEgyesület: "+v.egyesulet+"\n\tÖsszpont: "+v.oszpontszam());
        }

        private static void f4()
        {
            double db = versenyzok.Count;
            double eredmeny = versenyzok.Count(f => f.kategoria == "Noi") / db;
            Console.WriteLine("4. feladat: A női versenyzők aránya: "+Math.Round((double)(eredmeny*100), 2));
        }

        private static void f3()
        {
            Console.WriteLine("3. feladat: Versenyzők száma: "+versenyzok.Count);
        }

        private static void feltolt()
        {
            versenyzok = new List<versenyzo>();
            var sr = new StreamReader(@"..\..\Resources\fob2016.txt", Encoding.UTF8);
            while (!sr.EndOfStream) versenyzok.Add(new versenyzo(sr.ReadLine()));
            sr.Close();   
        }
    }
}
