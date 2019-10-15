using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace sistemaAlumnosITAM
{
  class Conexion
  {
    public static SqlConnection conectar()
    {
      SqlConnection cnn = null;
      try
      {
        cnn = new SqlConnection("Data Source=CC101-07\\SA;Initial Catalog=baseSistemaAlumno;User ID=sa;Password=adminadmin");
        cnn.Open();
        MessageBox.Show("se conectó");
      }
      catch (Exception e)
      {
        MessageBox.Show("no se pudo conectar y el error es: " + e);
      }
      return cnn;
    }

    public static String comprobarPwd(String usuario, String contra)
    {
      String resp = "";
      SqlConnection con;
      SqlCommand cmd;
      SqlDataReader drd;
      try
      {
        con = Conexion.conectar();
        cmd = new SqlCommand(String.Format("select contra from usuarios where nombreUsuario = '{0}'", usuario), con);
        drd = cmd.ExecuteReader();
        if (drd.Read())
        {
          if (drd.GetString(0).Equals(contra))
            resp = "contraseña correcta";
          else
            resp = "contraseña incorrecta";
        }
        else
          resp = "usuario incorrecto";
        con.Close();
        drd.Close();
      }
      catch (Exception e)
      {
        resp = "error " + e;
      }

      return resp;
    }

    public static void llenarComboAlta(ComboBox cb)
    {
      String resp = "";
      SqlConnection con;
      SqlCommand cmd;
      SqlDataReader drd;
      try
      {
        con = Conexion.conectar();
        cmd = new SqlCommand("select nombre from programa", con);
        drd = cmd.ExecuteReader();
        while (drd.Read())
        {
          cb.Items.Add(drd["nombre"].ToString());
        }
        cb.SelectedIndex = 0;
        con.Close();
        drd.Close();
      }
      catch (Exception e)
      {
        MessageBox.Show("no se pudo llenar el combo " + e);
      }
    }
  }
}
