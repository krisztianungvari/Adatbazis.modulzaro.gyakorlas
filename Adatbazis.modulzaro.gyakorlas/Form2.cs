using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Adatbazis.modulzaro.gyakorlas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string Egyezoek = "SELECT `Gyarto`,`Tipus`,`Fogyasztas`,`Ar`,`KiadasEv` FROM ((SELECT `Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.projektor) UNION ALL (SELECT`Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.televizo)) AS T2 WHERE Fogyasztas IN(SELECT Fogyasztas FROM((SELECT `Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.projektor) UNION ALL(SELECT`Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.televizo)) AS T1 GROUP BY `Fogyasztas` HAVING COUNT(*) > 1)";
            Adatbazis db = new Adatbazis();
            MySqlDataReader azonosak = db.lekerdezes(Egyezoek);

            while (azonosak.Read())
            {
                ElektronikaiCikk cikk = new ElektronikaiCikk(azonosak.GetString( "Gyarto"),azonosak.GetString("Tipus"),azonosak.GetInt32("Fogyasztas"),azonosak.GetDouble("Ar"),azonosak.GetInt32("KiadasEv"));
                listBox_Egyzoek.Items.Add(cikk);
            }
        }
    }
}
