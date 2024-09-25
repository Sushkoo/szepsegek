using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szepsegek
{
    public class Dolgozo
    {
        int dolgozoId;
        int fizetes;
        int telefonszam;

        public Dolgozo(int dolgozoId, int fizetes, int telefonszam)
        {
            this.dolgozoId = dolgozoId;
            this.fizetes = fizetes;
            this.telefonszam = telefonszam;
        }

        public int DolgozoId { get => dolgozoId; set => dolgozoId = value; }
        public int Fizetes { get => fizetes; set => fizetes = value; }
        public int Telefonszam { get => telefonszam; set => telefonszam = value; }
    }
}
