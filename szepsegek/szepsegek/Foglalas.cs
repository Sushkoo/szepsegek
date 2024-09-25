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

        public int FoglalasId { get => foglalasId; set => foglalasId = value; }
        public int Idopont { get => idopont; set => idopont = value; }
        public int VendegId { get => vendegId; set => vendegId = value; }
        public int DolgozoId { get => dolgozoId; set => dolgozoId = value; }
        public int SzolgaltatasId { get => szolgaltatasId; set => szolgaltatasId = value; }
    }
}
