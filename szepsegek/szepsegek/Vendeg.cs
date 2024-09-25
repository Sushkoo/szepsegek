using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szepsegek
{
    public class Vendeg
    {
        int vendegId;
        string nev;
        int telefonszam;
        int foglalasId;
        int szolgaltatasId;

        public Vendeg(int vendegId, string nev, int telefonszam, int foglalasId, int szolgaltatasId)
        {
            this.vendegId = vendegId;
            this.nev = nev;
            this.telefonszam = telefonszam;
            this.foglalasId = foglalasId;
            this.szolgaltatasId = szolgaltatasId;
        }

        public int VendegId { get => vendegId; set => vendegId = value; }
        public string Nev { get => nev; set => nev = value; }
        public int Telefonszam { get => telefonszam; set => telefonszam = value; }
        public int FoglalasId { get => foglalasId; set => foglalasId = value; }
        public int SzolgaltatasId { get => szolgaltatasId; set => szolgaltatasId = value; }
    }
}
