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
        MySqlConnection connection = null;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string Egyezoek = "SELECT `Gyarto`,`Tipus`,`Fogyasztas`,`Ar`,`KiadasEv` FROM ((SELECT `Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.projektor) UNION ALL (SELECT`Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.televizo)) AS T2 WHERE Fogyasztas IN(SELECT Fogyasztas FROM((SELECT `Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.projektor) UNION ALL(SELECT`Gyarto`, `Tipus` , `Fogyasztas` , `Ar` ,`KiadasEv` FROM elektronika.televizo)) AS T1 GROUP BY `Fogyasztas` HAVING COUNT(*) > 1)";
            Adatkapcsolat();
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = Egyezoek;
            using (MySqlDataReader dr = command.ExecuteReader())
            {

                while (dr.Read())
                {
                    ElektronikaiCikk cikk = new ElektronikaiCikk(dr.GetString("Gyarto"), dr.GetString("Tipus"), dr.GetInt32("Fogyasztas"), dr.GetDouble("Ar"), dr.GetInt32("KiadasEv"));
                    listBox_Egyzoek.Items.Add(cikk);
                }
            }

          
        }
        private void Adatkapcsolat()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Port = 3306;
            builder.Password = "";
            builder.Database = "elektronika";           
            builder.CharacterSet = "UTF8";
            builder.SslMode = MySqlSslMode.None;


            string connectionString = builder.ToString();


            try
            {
                this.connection = new MySqlConnection(connectionString);

            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Hiba az adatbázis csatlakozás közben: " + ex.Message);

            }
             
        }

    }
}
