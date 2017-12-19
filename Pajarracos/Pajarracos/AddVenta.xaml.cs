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
    /// Lógica de interacción para AddVenta.xaml
    /// </summary>
    public partial class AddVenta : Window
    {
        public AddVenta()
        {
            InitializeComponent();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int numclientes = 0;
            string nombre = txt1.Text;
            string apellidos = txt2.Text;
            string telefono = txt3.Text;
            string nif = txt4.Text;
            int cont = 0;
            

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "pajareria";

            if (dbCon.IsConnect())
            {
                string query = "SELECT COUNT(*) FROM CLIENTES;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                numclientes = Convert.ToInt32(cmd.ExecuteScalar());
            }

            int id = numclientes + 1;

            if (dbCon.IsConnect())
            {
                if (nombre == "" || apellidos == "" || telefono == "" || nif == "")
                {
                    MessageBox.Show("Introduzca los datos");
                }
                else
                {
                    cont = 1;

                    MySqlDataReader reader;

                    string query = "INSERT INTO CLIENTES VALUES (" + id + ",'" + nombre + "','" + apellidos + "','" + telefono + "','" + nif + "');";

                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    reader = cmd.ExecuteReader();

                    MessageBox.Show("Cliente añadido");
                    reader.Close();
                }

                if (cont == 1)
                {
                    

                    AddVenta2 window2 = new AddVenta2();

                    window2.ShowDialog();
                    this.Close();
                }


            }
        }
    }
}
