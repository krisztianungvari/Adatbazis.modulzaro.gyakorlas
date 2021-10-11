using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adatbazis.modulzaro.gyakorlas
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox_Televizio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox_Televizio.SelectedIndex < 0)
            {
                return;
            }
            else if (true)
            {

                ElektronikaiCikk kiv = (ElektronikaiCikk)listBox_Televizio.SelectedItem;
                textBox_Gyarto.Text = kiv.Gyarto;
                textBox_Tipus.Text = kiv.Tipus;
                numericUpDown_Fogyasztas.Value = kiv.Fogyasztas;      //.ToString("# WATT");
                numericUpDown_Kiadas.Value = kiv.Kiadasev;
                //  comboBox_Kijelzo.SelectedIndex = kiv.Kijelzo;
              //  numericUpDown_Kepatlo.Value = kiv.Kepatlo;
              //miért ne mveszi át ezkeet az adatokat?
            }
        }

        private void button_Torles_Click(object sender, EventArgs e)
        {
            if (listBox_Televizio.SelectedIndex < 0)
            {
                return;
            }
            DialogResult valasz = MessageBox.Show($"Valóban törölni akarja a kijelölt elemet?", "Biztosan törli?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (valasz == DialogResult.Yes)
            {
                listBox_Televizio.Items.RemoveAt(listBox_Televizio.SelectedIndex);
                // Ha törlöm a programból az adatokat, akkor az adatbázisban is törlődni fog?
            }
             
        }

        private void button_Mentes_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("elektronikai cikkek.csv"))
            {
                foreach (var item in listBox_Televizio.Items)
                {
                   // sw.WriteLine(((ElektronikaiCikk)item).toCSV()); 
                }
            }

        }

        private void button_Televizio_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Gyarto.Text))
            {
                MessageBox.Show("Nincs kitöltve!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_Tipus.Text))
            {
                MessageBox.Show("Nincs kitöltve!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Fogyasztas.Value < 5)
            {
                MessageBox.Show("Túl alacsony fogyasztás!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Ar.Value < 10000)
            {
                MessageBox.Show("Nincs helyesen kitöltve!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Kiadas.Value > 2021)
            {
                MessageBox.Show("hibás évszám!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox_Kijelzo.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kiválasztva semmi!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Kepatlo.Value < 5)
            {
                MessageBox.Show("Helytelen adat!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          // Televizio uj = new Televizio(textBox_Gyarto.Text, textBox_Tipus.Text, (int)numericUpDown_Fogyasztas.Value, (double)numericUpDown_Ar.Value, (int)numericUpDown_Kiadas.Value, comboBox_Kijelzo.SelectedItem.ToString(), (double)numericUpDown_Kepatlo.Value);
            return;

        }

        private void button_Projektor_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_Gyarto.Text))
            {
                MessageBox.Show("Nincs kitöltve!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBox_Tipus.Text))
            {
                MessageBox.Show("Nincs kitöltve!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Fogyasztas.Value < 5)
            {
                MessageBox.Show("Túl alacsony fogyasztás!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Ar.Value < 10000)
            {
                MessageBox.Show("Nincs helyesen kitöltve!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Kiadas.Value > 2021)
            {
                MessageBox.Show("hibás évszám!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDown_Kontraszt.Value < 1000)
            {
                MessageBox.Show("Helytelen adat!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Helytelen adat!", "HIBA!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Projektor uj = new Projektor(textBox_Gyarto.Text, textBox_Tipus.Text, (int)numericUpDown_Fogyasztas.Value, (double)numericUpDown_Ar.Value, (int)numericUpDown_Kiadas.Value, (double)numericUpDown_Kontraszt.Value, comboBox1.SelectedIndex);


        }

        private void button_Modositas_Click(object sender, EventArgs e)
        {
          

        }

        private void button_Osszehasonlitas_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();


        }

        private void button_updateTelevizio_Click(object sender, EventArgs e)
        {
            string Gyarto = textBox_Gyarto.Text;
            string Tipus = textBox_Tipus.Text;
            int Fogyasztas = (int)numericUpDown_Fogyasztas.Value;
            int Ar =(int)numericUpDown_Ar.Value;
            int KiadasEv = (int)numericUpDown_Kiadas.Value;
            string KijelzoTechnologia = comboBox_Kijelzo.Text;
            int KepAtlo = (int)numericUpDown_Kepatlo.Value;
            //INSERT INTO `televizo` (`Gyarto`, `Tipus`, `Fogyasztas`, `Ar`, `KiadasEv`, `KijelzoTechnologia`, `KepAtlo`) VALUES ('Sasmung', 'S3400', '1000', '120000', '2020', 'IPS', '72');
            string Sql = "INSERT INTO `televizo` (`Gyarto`, `Tipus`, `Fogyasztas`, `Ar`, `KiadasEv`, `KijelzoTechnologia`, `KepAtlo`) VALUES (`@Gyarto`, `@Tipus`, `@Fogyasztas`, `@Ar`, `@KiadasEv`, `@KijelzoTechnologia`,`@KepAtlo`)";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = Sql;
            command.Prepare();
            command.Parameters.AddWithValue("@Gyarto", Gyarto);
            command.Parameters.AddWithValue("@Tipus", Tipus);
            command.Parameters.AddWithValue("@Fogyasztas", Fogyasztas);
            command.Parameters.AddWithValue("@Ar", Ar);
            command.Parameters.AddWithValue("@KiadasEv", KiadasEv);
            command.Parameters.AddWithValue("@KijelzoTechnologia", KijelzoTechnologia);
            command.Parameters.AddWithValue("@Kepatlo", KepAtlo);
            command.ExecuteNonQuery();
            textBox_Gyarto.Text = "";
            textBox_Tipus.Text = "";
            numericUpDown_Fogyasztas.Value = numericUpDown_Fogyasztas.Minimum;
            numericUpDown_Ar.Value = numericUpDown_Ar.Minimum;
            numericUpDown_Kiadas.Value = numericUpDown_Kiadas.Minimum;
            comboBox_Kijelzo.Text = "";
            numericUpDown_Kepatlo.Value = numericUpDown_Kepatlo.Minimum;
            
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

        private void Form1_Load(object sender, EventArgs e)
        {
            Adatkapcsolat();

        }

        private void button_Televizio_Click_1(object sender, EventArgs e)
        {
            string Gyarto = textBox_Gyarto.Text;
            string Tipus = textBox_Tipus.Text;
            int Fogyasztas = (int)numericUpDown_Fogyasztas.Value;
            int Ar = (int)numericUpDown_Ar.Value;
            int KiadasEv = (int)numericUpDown_Kiadas.Value;
            string KijelzoTechnologia = comboBox_Kijelzo.Text;
            int KepAtlo = (int)numericUpDown_Kepatlo.Value;
            //INSERT INTO `televizo` (`Gyarto`, `Tipus`, `Fogyasztas`, `Ar`, `KiadasEv`, `KijelzoTechnologia`, `KepAtlo`) VALUES ('Sasmung', 'S3400', '1000', '120000', '2020', 'IPS', '72');
            string Sql = "INSERT INTO `televizo` (`Gyarto`, `Tipus`, `Fogyasztas`, `Ar`, `KiadasEv`, `KijelzoTechnologia`, `KepAtlo`) VALUES (`@Gyarto`, `@Tipus`, `@Fogyasztas`, `@Ar`, `@KiadasEv`, `@KijelzoTechnologia`,`@KepAtlo`)";
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = Sql;
            command.Prepare();
            command.Parameters.AddWithValue("@Gyarto", Gyarto);
            command.Parameters.AddWithValue("@Tipus", Tipus);
            command.Parameters.AddWithValue("@Fogyasztas", Fogyasztas);
            command.Parameters.AddWithValue("@Ar", Ar);
            command.Parameters.AddWithValue("@KiadasEv", KiadasEv);
            command.Parameters.AddWithValue("@KijelzoTechnologia", KijelzoTechnologia);
            command.Parameters.AddWithValue("@Kepatlo", KepAtlo);
            command.ExecuteNonQuery();
            textBox_Gyarto.Text = "";
            textBox_Tipus.Text = "";
            numericUpDown_Fogyasztas.Value = numericUpDown_Fogyasztas.Minimum;
            numericUpDown_Ar.Value = numericUpDown_Ar.Minimum;
            numericUpDown_Kiadas.Value = numericUpDown_Kiadas.Minimum;
            comboBox_Kijelzo.Text = "";
            numericUpDown_Kepatlo.Value = numericUpDown_Kepatlo.Minimum;
            Televizio uj = new Televizio(Gyarto, Tipus, Fogyasztas, Ar, KiadasEv, Enum.Parse(typeof(kT), KijelzoTechnologia),(double) KepAtlo);
        }
    }
}
