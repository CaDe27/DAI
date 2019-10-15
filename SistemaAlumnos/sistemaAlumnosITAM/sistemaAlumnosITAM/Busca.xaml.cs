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
  /// Lógica de interacción para Busca.xaml
  /// </summary>
  public partial class Busca : Window
  {
    public Busca()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      Alumno a = new Alumno(txtNombre1.Text);
      List<Alumno> l = new List<Alumno>();
      l = a.busca(a);
      dgDatos.ItemsSource = l;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
      Alta w = new Alta();
      w.Show();
      this.Close();
    }
  }
}
