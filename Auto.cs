using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onvezeto_Major_Levente
{
    class Auto
    {
        public string gyartoModell { get; set; }
        public string SAESzint { get; set; }
        public int aktualisSebesseg { get; set; }
        public string[] szenzorokListaja { get; set; }
        public double[] GPSKoordinatak { get; set; }
        public int vezetoiBeavatkozas { get; set; }
        public string aktualisVezetesiMod { get; set; }
        public int id { get; set; }

        public Auto(string s, int x)
        {
            var d = s.Split("; ");
            this.gyartoModell = d[0];
            this.SAESzint = d[1];
            this.aktualisSebesseg = int.Parse(d[2]);
            this.szenzorokListaja = d[3].Split(",");
            string[] parts = d[4].Split("|");
            double[] gps = new double[2];
            foreach (var item in parts)
            {
                gps[0] = double.Parse(parts[0]);
                gps[1] = double.Parse(parts[1]);
            }
            this.GPSKoordinatak = gps;
            this.vezetoiBeavatkozas = int.Parse(d[5]);
            this.aktualisVezetesiMod = d[6];
            this.id = x;
        }

        //12.Feladat
        public string nagybetu()
        {
            return gyartoModell.ToUpper();
        }

        public override string ToString()
        {
            string szenzorok = "";
            for (int i = 0; i < szenzorokListaja.Length; i++)
            {
                szenzorok += szenzorokListaja[i] + ",";
            }

            string gps = "";
            for (int y = 0; y < GPSKoordinatak.Length; y++)
            {
                gps += GPSKoordinatak[y] + ",";
            }

            return $"Gyártó és modell: {gyartoModell}, SAE szint: {SAESzint}, Aktuális sebesség: {aktualisSebesseg}, Szenzorok listája: {szenzorok}, GPS koordináták: {gps}, Vezetői beavatkozás: {vezetoiBeavatkozas}, Aktuális vezetési mód: {aktualisVezetesiMod};";
        }
    }
}
