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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Convertidor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox objTextBox = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try{
                double grados;
                // si escribio en la caja de txtCentigrados
                if(objTextBox == txtCentigrados)
                {
                    MessageBox.Show("escribiste en txtCentigrados");
                    grados = Convert.ToDouble(txtCentigrados.Text) * 9.00 / 5.00 + 32.00;
                    txtFahrenheit.Text = String.Format("{0:F2}", grados);
                }
                else if(objTextBox == txtFahrenheit)
                {
                    MessageBox.Show("escribiste en txtFahrenheit");
                    grados = (Convert.ToDouble(txtFahrenheit.Text) - 32.00) / 9.00 * 5.00;
                    txtCentigrados.Text = String.Format("{0:F2}", grados);
                }
            }
            catch (FormatException){
                txtCentigrados.Text = "0.0";
                txtFahrenheit.Text = "32";
            }
        }

        
        private void TxtCentigrados_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox;
        }

        

        private void TxtFahrenheit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            objTextBox = sender as TextBox;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtCentigrados.Focus();
        }
    }
}
