using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pajarracos
{
  
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
           
        }
        

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            SoundPlayer My_JukeBox = new SoundPlayer(@"Sonidos/Bird-singing-song.wav");
            try
            {
                My_JukeBox.Play();
            }
            catch (FileNotFoundException ex)
            {
       
                Console.WriteLine(ex);
            }


            int opcion = combo1.SelectedIndex;



            switch (opcion)
            {
                case 0:
                    Window1 window = new Window1();

                    window.ShowDialog();
                    break;
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;

            }
        }
    }
}
