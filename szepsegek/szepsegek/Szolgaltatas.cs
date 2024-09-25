using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szepsegek
{
    public class Szolgaltatas
    {
        int szolgaltatasId;
        string tipusa;
        int dolgozoId;
        int ar;
        int vendegId;

        public Szolgaltatas(int szolgaltatasId, string tipusa, int dolgozoId, int ar, int vendegId)
        {
            this.szolgaltatasId = szolgaltatasId;
            this.tipusa = tipusa;
            this.dolgozoId = dolgozoId;
            this.ar = ar;
            this.vendegId = vendegId;
        }

        public int SzolgaltatasId { get => szolgaltatasId; set => szolgaltatasId = value; }
        public string Tipusa { get => tipusa; set => tipusa = value; }
        public int DolgozoId { get => dolgozoId; set => dolgozoId = value; }
        public int Ar { get => ar; set => ar = value; }
        public int VendegId { get => vendegId; set => vendegId = value; }
    }
}
