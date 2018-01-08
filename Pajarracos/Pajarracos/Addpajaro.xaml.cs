using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Pajarracos
{
    /// <summary>
    /// Lógica de interacción para AddPajaro.xaml
    /// Ventana para añadir un pajaro
    /// </summary>
    public partial class AddPajaro : Window
    {
        public AddPajaro()
        {
            InitializeComponent();
        }
        //Metodo que se lanza cuando se presiona el botón
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string especie = txt1.Text;
            string fechaentrada = txt2.Text;
            string fechanac = txt3.Text;
            string pvp = txt4.Text;
            int numpajaros = 0;
            int cont = 0;

            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "pajareria";
            //Pilla el numero total de pájaros de la bd
            if (dbCon.IsConnect())
            {
                 string query = "SELECT COUNT(*) FROM PAJAROS;";
                 var cmd = new MySqlCommand(query, dbCon.Connection);
                 numpajaros = Convert.ToInt32(cmd.ExecuteScalar());
            }

            int id = numpajaros + 1;
            //Se crea un pajaro y se añade a la bd
            if (dbCon.IsConnect())
            {
                if (especie == "" || fechaentrada == "" || fechanac == "" || pvp == "")
                {
                    MessageBox.Show("Introduzca los datos");
                }
                else
                {
                    cont = 1;

                    MySqlDataReader reader;

                    string query = "INSERT INTO PAJAROS VALUES ("+id+",FALSE,'" + especie + "','" + fechaentrada + "','" + fechanac + "'," + pvp + ");";

                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    reader = cmd.ExecuteReader();
                    
                    MessageBox.Show("Pájaro añadido");
                    
                }
                // Si se ha añadido correctamente se cierra la ventana
                if(cont == 1)
                {
                    
                    this.Close();
                }

               
            }

        }
    }
    
}
