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

            List<Auto> felautomata = f7(autok);
            int felauto = felautomata.Count;
            if (felauto > 0)
            {
                Console.Write("7.Feladat: ");
                Console.WriteLine(felauto);
            }
            else
            {
                Console.WriteLine("Nincsen ilyen autó!");
            }

            List<Auto> f8 = feladat8(autok);
            Console.WriteLine("8.Feladat:");
            foreach (var auto in f8)
            {
                Console.WriteLine(auto);
            }
            Console.WriteLine(f8.Count);
            Console.WriteLine(f8.Max(m => m.vezetoiBeavatkozas));

            Console.WriteLine("9.Feladat:");

            List<string> gyartok = feladat10(autok);
            Console.WriteLine("10.Feladat:");
            if (gyartok.Count > 0)
            {
                gyartok.Sort();
                gyartok.Distinct();
                foreach (var item in gyartok)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen gyártó!");
            }

            Console.WriteLine("11.Feladat:");
            Console.WriteLine(feladat11(autok));

            feladat13(autok);
        }

        static List<Auto> f7(List<Auto> autok)
        {
            List<Auto> fel = new List<Auto>();
            foreach (var auto in autok)
            {
                if (auto.SAESzint == "félautomatikus" && auto.aktualisVezetesiMod == "manuális")
                {
                    fel.Add(auto);
                }
            }
            return fel;
        }
        static List<Auto> feladat8(List<Auto> autok)
        {
            List<Auto> onallo = new List<Auto>();
            int max = autok.Max(m => m.vezetoiBeavatkozas);
            foreach (var auto in autok)
            {
                if (auto.vezetoiBeavatkozas == max)
                {
                    onallo.Add(auto);
                }
            }
            return onallo;
        }
        static List<string> feladat10(List<Auto> autok)
        {
            List<Auto> automata = new List<Auto>();
            foreach (var auto in autok)
            {
                if (auto.aktualisVezetesiMod == "automatikus")
                {
                    automata.Add(auto);
                }
            }
            List<string> gyarto = new List<string>();
            foreach (var auto in automata)
            {
                string[] temp = auto.gyartoModell.Split(" ");
                gyarto.Add(temp[0]);
            }
            return gyarto;
        }
        static string feladat11(List<Auto> autok)
        {
            string result = "";
            int szenzor = 0;
            foreach (var auto in autok)
            {
                szenzor = auto.szenzorokListaja.Count();
                if (szenzor >= 3 && auto.aktualisSebesseg >= 85 &&auto.aktualisSebesseg <= 95)
                {
                    result += auto.id + ", ";
                }
            }
            return result;
        }
        static void feladat13(List<Auto> autok)
        {
            using StreamWriter sr = new StreamWriter(@"..\..\..\src\kiiras.txt", false);
            foreach (var auto in autok)
            {
                sr.WriteLine(auto.nagybetu() + ", " + auto.SAESzint);
            }
        }
    }
}
