using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adatbazis.modulzaro.gyakorlas
{
    class Adatbazis
    {
        const string server = "localhost";
        const string user = "root";
        const uint port = 3306;
        const string password = "";
        const string database = "elektronika";
        const MySqlSslMode sslMode = MySqlSslMode.None;
        MySqlConnection connection = null;
        public Adatbazis()
        {
            InitDB();
        }

        public  MySqlConnection InitDB()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = server;
            builder.UserID = user;
            builder.Port = port;
            builder.Password = password;
            builder.Database = database;
            builder.SslMode = sslMode;
            builder.CharacterSet = "UTF8";
            


            string connectionString = builder.ToString();


            try
            {
                this.connection = new MySqlConnection(connectionString);
                
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("Hiba az adatbázis csatlakozás közben: " + ex.Message);

            }
            return default;

        }
        public MySqlDataReader lekerdezes(string sql)
        {
            MySqlDataReader vissza = null;
            try
            {
                MySqlCommand parancs = this.connection.CreateCommand();
                parancs.CommandText = sql;
                using (vissza = parancs.ExecuteReader())
                {
                    return vissza;
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            return vissza;
        }
    }
}
