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
    /// Ventana donde se elige el pájaro que va a ser vendido
    /// </summary>
    public partial class AddVenta2 : Window
    {
        public AddVenta2()
        {
            
            InitializeComponent();

            //Al crearse se pone en un textarea todos los pájaros que hay en inventario
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "pajareria";
            if (dbCon.IsConnect())
            {

                string query = "SELECT * FROM PAJAROS WHERE VENDIDO=FALSE;";
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
        //Método que hace que no se pueda poner nada aparte de numeros en el textbox
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //Metodo que se lanza cuando se presiona el botón
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
            //  Añade la venta 
            if (dbCon.IsConnect())
            {
                //Si no ha introducido fecha se pone automaticamente la fecha actual
                if (date == "")
                {
                    date = System.DateTime.Today.ToShortDateString();
                }
                //Se añade la venta
                MySqlDataReader reader;

                string query = "INSERT INTO VENTAS VALUES ("+idventa+",'" + date + "'," + idcliente + "," + idpajaro + ");";

                var cmd = new MySqlCommand(query, dbCon.Connection);
                reader = cmd.ExecuteReader();

                MessageBox.Show("Venta añadida");
                reader.Close();
                
            }
            //Cambia el atribuo vendido del pajaro que ha sido vendido
            if (dbCon.IsConnect())
            {
                MySqlDataReader reader2;

                string query = "UPDATE PAJAROS SET VENDIDO=TRUE WHERE IDPAJAROS = " + idpajaro + ";";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                reader2 = cmd.ExecuteReader();

                reader2.Close();
            }

            
            this.Close();
        }
    }
}
