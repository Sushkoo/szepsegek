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

        public int SzolgaltatasId { get => szolgaltatasId; }
        public string Tipusa { get => tipusa; }
        public int DolgozoId { get => dolgozoId; }
        public int Ar { get => ar; }
        public int VendegId { get => vendegId; }
    }
}
