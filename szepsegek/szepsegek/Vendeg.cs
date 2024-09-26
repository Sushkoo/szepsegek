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
        string telefonszam;
        int foglalasId;
        int szolgaltatasId;

        public Vendeg(int vendegId, string nev, string telefonszam/*,int foglalasId, int szolgaltatasId*/)
        {
            this.vendegId = vendegId;
            this.nev = nev;
            this.telefonszam = telefonszam;
            //this.foglalasId = foglalasId;
            //this.szolgaltatasId = szolgaltatasId;
        }

        public int VendegId { get => vendegId; }
        public string Nev { get => nev;}
        public string Telefonszam { get => telefonszam; }
       //public int FoglalasId { get => foglalasId; }
        //public int SzolgaltatasId { get => szolgaltatasId; }
    }
}
