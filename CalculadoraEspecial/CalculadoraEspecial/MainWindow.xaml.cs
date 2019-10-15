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

namespace CalculadoraEspecial
{
  /// <summary>
  /// Lógica de interacción para MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void BttCalcula_Click(object sender, RoutedEventArgs e)
    {
      if (rdbBinario.IsChecked == true)
        repreBinaria();
      else if (rdbPrimo.IsChecked == true)
        esPrimo();
      else if (rdbComb.IsChecked == true)
        comb();
    }

    private void repreBinaria()
    {
      int n;
      try
      {
        n = int.Parse(txtNum1.Text);
      }
      catch (Exception)
      {
        n = 1;
      }
      Stack<String> bin = new Stack<String>();
      while (n > 0)
      {
        bin.Push((n % 2)+"");
        n /= 2;
      }
      String resp = null;
      while (bin.Any())
        resp+=bin.Pop();
      txtResp.Text = resp;
    }

    private void esPrimo()
    {
      int n;
      try {
        n = int.Parse(txtNum1.Text);
      } catch (Exception)
      {
        n = 1;
      }
      int raiz = (int)Math.Sqrt(n);
      int i = 2;
      if (n % i != 0)
      {
        i = 3;
        while (n % i != 0 && i <= raiz)
          i += 2;
      }

      if (i > raiz && n > 1)
        txtResp.Text = "si es primo";
      else
        txtResp.Text = "no es primo";
    }

    private void comb()
    {
      int n, k;
      try
      {
        n = int.Parse(txtNum1.Text);
        k = int.Parse(txtNum2.Text);
      }
      catch (Exception)
      {
        n = 1;
        k = 1;
      }
      long a = 1;
      if (k > n - k)
        k = n - k;
      for(int i =0; i < k; ++i)
      {
        a *= (n - i);
        a /= (i + 1);
      }
      if (a < 0)
        txtResp.Text = "el numero es demasiado grande";
      else
        txtResp.Text = a + "";
    }

   
  }
}
