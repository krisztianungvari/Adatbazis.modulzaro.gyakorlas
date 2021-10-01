using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatbazis.modulzaro.gyakorlas
{
    class Projektor : ElektronikaiCikk
    {
        double kontraszt;
        double felbontas;

        public Projektor(string gyarto, string tipus, int fogyasztas, double ar, int kiadasev, double kontraszt, double felbontas):base(gyarto, tipus, fogyasztas, ar, kiadasev)
        {
            this.kontraszt = kontraszt;
            this.felbontas = felbontas;
        }

        public double Kontraszt { get => kontraszt; set => kontraszt = value; }
        public double Felbontas { get => felbontas; set => felbontas = value; }

        public override string ToString()
        {
            return kontraszt.ToString();
        }
    }
}
