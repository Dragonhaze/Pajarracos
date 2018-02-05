
using System.Windows;


namespace Pajarracos
{
    /// <summary>
    /// Ventana principal del programa
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
        }

        /// <summary>
        /// Metodo que se lanza cuando se presiona el botón y abre la ventana selecionada en el combobox
        /// </summary>

        private void btn1_Click(object sender, RoutedEventArgs e)
        {



            int opcion = combo1.SelectedIndex;



            switch (opcion)
            {
                case 0:
                    AddPajaro window = new AddPajaro();

                    window.ShowDialog();
                    break;
                case 1:
                    AddVenta window2 = new AddVenta();

                    window2.ShowDialog();
                    break;
                case 2:
                    BuscarEspecie window3 = new BuscarEspecie();

                    window3.ShowDialog();
                    break;
                case 3:
                    ConsultarCliente window4 = new ConsultarCliente();

                    window4.ShowDialog();
                    break;
                case 4:
                    Form1 form1 = new Form1();

                    form1.ShowDialog();
                    break;


            }
        }
    }
}
