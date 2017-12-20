using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pajarracos
{
    /// <summary>
    /// Lógica de interacción para AddVenta2.xaml
    /// </summary>
    public partial class AddVenta2 : Window
    {
        public AddVenta2()
        {
            
            InitializeComponent();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "pajareria";
            if (dbCon.IsConnect())
            {

                string query = "SELECT * FROM PAJAROS;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    texto.Text += "Id del pájaro : " + rdr[0].ToString() + '\n' +
                        "Vendido : " + rdr[1].ToString() + '\n' +
                        "Especie : " + rdr[2].ToString() + '\n' +
                        "Fecha de entrada : " + rdr[3].ToString() + '\n' +
                        "Fecha de nacimiento : " + rdr[4].ToString() + '\n' +
                        "Pvp : " + rdr[5].ToString() + '\n'+'\n';

                }
                rdr.Close();

            }
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string date = date1.Text;
            int idpajaro = Convert.ToInt32(txt1.Text);
            int idcliente = 0;
            int idventa = 0;

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "pajareria";

            if (dbCon.IsConnect())
            {
                string query = "SELECT COUNT(*) FROM CLIENTES;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                idcliente = Convert.ToInt32(cmd.ExecuteScalar());
            }

            if (dbCon.IsConnect())
            {
                string query = "SELECT COUNT(*) FROM Ventas;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                idventa = Convert.ToInt32(cmd.ExecuteScalar());
            }
            idventa = idventa + 1;

            if (dbCon.IsConnect())
            {
                if (date == "")
                {
                    date = System.DateTime.Today.ToShortDateString();
                }
                else
                {


                    MySqlDataReader reader;

                    string query = "INSERT INTO VENTAS VALUES ("+idventa+",'" + date + "'," + idcliente + "," + idpajaro + ");";

                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    reader = cmd.ExecuteReader();

                    MessageBox.Show("Venta añadida");
                    reader.Close();
                }
            }

            if (dbCon.IsConnect())
            {
                MySqlDataReader reader2;

                string query = "UPDATE PAJAROS SET VENDIDO=TRUE WHERE IDPAJAROS = " + idpajaro + ";";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                reader2 = cmd.ExecuteReader();

                reader2.Close();
            }

            dbCon.Close();
            this.Close();
        }
    }
}
