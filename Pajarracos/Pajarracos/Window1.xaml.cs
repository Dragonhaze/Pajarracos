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
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

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

            if (dbCon.IsConnect())
            {
                 string query = "SELECT COUNT(*) FROM PAJAROS;";
                 var cmd = new MySqlCommand(query, dbCon.Connection);
                 numpajaros = Convert.ToInt32(cmd.ExecuteScalar());
                 MessageBox.Show("Número de pájaros es "+numpajaros);
            }

            int id = numpajaros + 1;

            if (dbCon.IsConnect())
            {
                if (especie == "" || fechaentrada == "" || fechanac == "" || pvp == "")
                {
                    MessageBox.Show("Introduzca los datos");
                }
                else
                {
                    cont = 1;
                    string query = "INSERT INTO PAJAROS VALUES ("+id+",FALSE,'" + especie + "','" + fechaentrada + "','" + fechanac + "'," + pvp + ");";
                    var cmd = new MySqlCommand(query, dbCon.Connection);
                    
                    MessageBox.Show("Pájaro añadido");
                    
                }
                
                if(cont == 1)
                {
                    dbCon.Close();
                    this.Close();
                }

               
            }

        }
    }
    
}
