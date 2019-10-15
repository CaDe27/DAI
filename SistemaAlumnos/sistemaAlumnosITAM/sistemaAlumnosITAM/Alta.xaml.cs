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

namespace sistemaAlumnosITAM
{
  /// <summary>
  /// Lógica de interacción para Alta.xaml
  /// </summary>
  public partial class Alta : Window
  {
    public Alta()
    {
      InitializeComponent();
    }

    private void BtAgregar_Click(object sender, RoutedEventArgs e)
    {
      int res;
      Alumno a;
      a = new Alumno(Int16.Parse(txtClaveUnica.Text), txtNombre.Text,
                      txtSexo.Text, txtCorreo.Text, Int16.Parse(txtSemestre.Text),
                      cbProgramas.SelectedIndex);
      res = a.alta(a);
      if (res > 0)
        MessageBox.Show("se dio de alta");
      else
        MessageBox.Show("no se dio de alta");
    }

    private void BtEliminar_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      Baja w = new Baja();
      w.Show();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      Busca w = new Busca();
      w.Show();
    }

    private void BtModificar_Click(object sender, RoutedEventArgs e)
    {
      this.Hide();
      Modifica w = new Modifica();
      w.Show();

    }

    private void BtSalir_Click(object sender, RoutedEventArgs e)
    {
      this.Close();
    }

    private void CbProgramas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      Conexion.llenarComboAlta(cbProgramas);
    }
  }
}
