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
  /// Lógica de interacción para Modifica.xaml
  /// </summary>
  public partial class Modifica : Window
  {
    public Modifica()
    {
      InitializeComponent();
    }

    private void tbRegresar_Click(object sender, RoutedEventArgs e)
    {
      Alta w = new Alta();
      w.Show();
      this.Close();
    }

    private void tbModificar_Click(object sender, RoutedEventArgs e)
    {
      int res;
      Alumno a;
      a = new Alumno(Int16.Parse(txtClaveUnica.Text));
      res = a.baja(a);
      if (res > 0)
        MessageBox.Show("se dio de baja");
      else
        MessageBox.Show("no se dio de baja");
    }
  }
}
