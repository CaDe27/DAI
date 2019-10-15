﻿using sistemaAlumnosITAM;
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

namespace SistemaAlumnos
{
  /// <summary>
  /// Interaction logic for Window2.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      String resp = Conexion.comprobarPwd(txUsuario.Text, txPassword.Text);
      if (resp.Equals("contraseña correcta"))
      {
        Alta wAlta = new Alta();
        wAlta.Show();
        this.Close();
      }
      else
      {
        MessageBox.Show(resp);
      }

    }
  }
}
