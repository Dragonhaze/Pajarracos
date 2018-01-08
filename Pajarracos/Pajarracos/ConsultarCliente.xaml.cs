using MySql.Data.MySqlClient;
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

namespace Pajarracos
{
    /// <summary>
    /// Lógica de interacción para ConsultarCliente.xaml
    /// Como bien dice el nombre de la clase esta es la ventana que sirve para consultar clientes
    /// </summary>
    public partial class ConsultarCliente : Window
    {   /// <summary>
        /// Método para consultar clientes
        /// </summary>
        public ConsultarCliente()
        {

            
            // Se inicializa la conexión de base de datos
            InitializeComponent();
            var dbCon = DBConnection.Instance();
            dbCon.DatabaseName = "pajareria";

            if (dbCon.IsConnect())
            {
                //Esta es la query
                string query = "SELECT * FROM Clientes;";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                //Con el reader imprime 
                while (rdr.Read())
                {
                    texto.Text += "Id del cliente : " + rdr[0].ToString() + '\n' +
                        "Nombre : " + rdr[1].ToString() + '\n' +
                        "Apellidos : " + rdr[2].ToString() + '\n' +
                        "Telefono : " + rdr[3].ToString() + '\n' +
                        "NIF : " + rdr[4].ToString() + '\n'+'\n';

                }
                rdr.Close();
                
            }
            
        }
    }
}
