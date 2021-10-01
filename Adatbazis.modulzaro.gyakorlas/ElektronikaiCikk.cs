using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatbazis.modulzaro.gyakorlas
{
    class ElektronikaiCikk 
    {
        string gyarto;
        string tipus;
        int fogyasztas;
        double ar;
        int kiadasev;

        public ElektronikaiCikk(string gyarto, string tipus, int fogyasztas, double ar, int kiadasev)
        {
            this.Gyarto = gyarto;
            this.Tipus = tipus;
            this.Fogyasztas = fogyasztas;
            this.Ar = ar;
            this.Kiadasev = kiadasev;
        }

        public string Gyarto { get => gyarto; set => gyarto = value; }
        public string Tipus { get => tipus; set => tipus = value; }
        public int Fogyasztas { get => fogyasztas; set => fogyasztas = value; }
        public double Ar { get => ar; set => ar = value; }
        public int Kiadasev { get => kiadasev; set => kiadasev = value; }

        public override string ToString()
        {
            return gyarto;

        }

        public int Bruttoar()
        {
            return (int)(ar * 1.27);
        }

       /* public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            // utána olvasni! MEGKÉRDEZNI!
            throw new NotImplementedException();
           
        }
       */
    }
}
