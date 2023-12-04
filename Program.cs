using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Onvezeto_Major_Levente
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();
            using StreamReader sr = new StreamReader(@"..\..\..\src\autok.txt", Encoding.UTF8);
            _ = sr.ReadLine();
            int x = 1;
            while (!sr.EndOfStream)
            {
                autok.Add(new Auto(sr.ReadLine(), x));
                x++;
            }

            //Kiírás
            foreach (var auto in autok)
            {
                Console.WriteLine(auto);
                Console.WriteLine();
            }

            //7.Feladat
            List<Auto> felautomata = f7(autok);
            int felauto = felautomata.Count;
            Console.Write("7.Feladat: ");
            if (felauto > 0) Console.WriteLine(felauto);
            else Console.WriteLine("Nincsen ilyen autó!");
            Console.WriteLine();

            //8.Feladat
            List<Auto> feladat8 = f8(autok);
            Console.WriteLine("8.Feladat:");
            foreach (var auto in feladat8) Console.WriteLine(auto);
            Console.WriteLine("Autók száma:");
            Console.WriteLine(feladat8.Count);
            Console.WriteLine("Legnagyobb érték:");
            Console.WriteLine(feladat8.Max(m => m.vezetoiBeavatkozas));
            Console.WriteLine();

            //9.Feladat
            Console.WriteLine("9.Feladat:");
            Console.WriteLine(f9(autok));
            Console.WriteLine();

            //10.Feladat
            Console.WriteLine("10.Feladat:");
            List<string> gyartok = f10(autok);
            if (gyartok.Count > 0)
            {
                foreach (var gyarto in gyartok) Console.WriteLine(gyarto);
            }
            else Console.WriteLine("Nincs ilyen gyártó!");
            Console.WriteLine();

            //11.Feladat
            Console.WriteLine("11.Feladat:");
            Console.WriteLine(f11(autok));

            //13.Feladat
            f13(autok);
        }

        static List<Auto> f7(List<Auto> autok)
        {
            return autok.Where(x => x.SAESzint == "félautomatikus" && x.aktualisVezetesiMod == "manuális").ToList();
        }
        static List<Auto> f8(List<Auto> autok)
        {
            int max = autok.Max(m => m.vezetoiBeavatkozas);
            return autok.Where(x => x.vezetoiBeavatkozas == max).ToList();
        }
        static double f9(List<Auto> autok)
        {
            double[] temp = new double[autok.Count];
            for (int i = 0; i < autok.Count; i++)
            {
                temp[i] = autok[i].GPSKoordinatak[0];
            }
            return temp.Min();
        }
        static List<string> f10(List<Auto> autok)
        {
            List<string> automata = autok.Where(x => x.aktualisVezetesiMod == "automatikus").Select(x => x.gyartoModell).ToList();

            for (int i = 0; i < automata.Count; i++)
            {
                string[] temp = automata[i].Split(" ");
                automata[i] = temp[0];
            }
            automata = automata.Distinct().ToList();
            automata.Sort();
            return automata;
        }
        static string f11(List<Auto> autok)
        {
            string result = "";
            int szenzor = 0;
            foreach (var auto in autok)
            {
                szenzor = auto.szenzorokListaja.Count();
                if (szenzor >= 3 && auto.aktualisSebesseg >= 85 && auto.aktualisSebesseg <= 95)
                {
                    result += auto.id + ", ";
                }
            }
            return result;
        }
        static void f13(List<Auto> autok)
        {
            using StreamWriter sr = new StreamWriter(@"..\..\..\src\kiiras.txt", false);
            foreach (var auto in autok)
            {
                sr.WriteLine(auto.nagybetu() + ", " + auto.SAESzint);
            }
        }
    }
}
