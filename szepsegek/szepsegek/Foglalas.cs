using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szepsegek
{
    public class Foglalas
    {
        int foglalasId;
        int idopont;
        int vendegId;
        int dolgozoId;
        int szolgaltatasId;

        public Foglalas(int foglalasId, int idopont, int vendegId, int dolgozoId, int szolgaltatasId)
        {
            this.foglalasId = foglalasId;
            this.idopont = idopont;
            this.vendegId = vendegId;
            this.dolgozoId = dolgozoId;
            this.szolgaltatasId = szolgaltatasId;
        }

        public int FoglalasId { get => foglalasId; }
        public int Idopont { get => idopont;}
        public int VendegId { get => vendegId; }
        public int DolgozoId { get => dolgozoId; }
        public int SzolgaltatasId { get => szolgaltatasId; }
    }
}
