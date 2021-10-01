using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adatbazis.modulzaro.gyakorlas
{
    enum kT
    {
        TN,
        VA,
        IPS,
        PLS,
        Egyéb
    };
    class Televizio : ElektronikaiCikk
    {
        kT kijelzoTechnologia;

        //string kijelzoTechnologia;
         
        double kepatlo;

        public Televizio(string gyarto,string tipus,int fogyasztas,double ar, int kiadasev, kT kijelzoTechnologia, double kepatlo):base(gyarto,tipus,fogyasztas,ar,kiadasev)
        {
            this.kijelzoTechnologia = kijelzoTechnologia;
            this.Kepatlo = kepatlo;
        }

        public kT KijelzoTechnologia { get => kijelzoTechnologia; set => kijelzoTechnologia = value; }
        public double Kepatlo { get => kepatlo; set => kepatlo = value; }

        public override string ToString()
        {
            return kijelzoTechnologia.ToString();
        }
    }
}
