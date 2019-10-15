using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemaAlumnosITAM
{
  class Alumno
  {
    public Int16 claveUnica { get; set; }
    public String nombre { get; set; }
    public String sexo { get; set; }
    public String correo { get; set; }
    public Int16 semestre { get; set; }
    public int programa { get; set; }

    public Alumno(short claveUnica, string nombre,string sexo, string correo, short semestre, int programa)
    {
      this.claveUnica = claveUnica;
      this.nombre = nombre;
      this.sexo = sexo;
      this.correo = correo;
      this.semestre = semestre;
      this.programa = programa;
    }

    public Alumno(short claveUnica)
    {
      this.claveUnica = claveUnica;
    }

    public Alumno(short claveUnica, string correo) : this(claveUnica)
    {
      this.correo = correo;
    }

    public Alumno(string nombre)
    {
      this.nombre = nombre;
    }

    public Alumno()
    {

    }
    public int alta(Alumno a)
    {
      int res = 0;
      //conectarme a la base
      SqlConnection con;
      con = Conexion.conectar();
      //hacer el query 
      SqlCommand cmd = new SqlCommand("", con);
      String.Format("insert into alumno (claveUnica, nombre, sexo, correo, semestre, idPrograma) values({0}, '{1}', '{2}', '{3}', {4}, {5})",
        a.claveUnica, a.nombre, a.sexo, a.correo, a.semestre, a.programa);
      //ejecutar el cuery
      cmd.ExecuteNonQuery();
      con.Close();
      return res;
    }

    public int baja(Alumno a)
    {
      int res = 0;
      //conectarme a la base
      SqlConnection con;
      con = Conexion.conectar();
      //hacer el query 
      SqlCommand cmd = new SqlCommand(String.Format("delete from alumno where claveUnica = {0}", a.claveUnica), con);
      //ejecutar el cuery
      res = cmd.ExecuteNonQuery();
      con.Close();
      return res;
    }

    public int modifica(Alumno a)
    {
      int res = 0;
      //conectarme a la base
      SqlConnection con;
      con = Conexion.conectar();
      //hacer el query 
      SqlCommand cmd = new SqlCommand(String.Format("update alumno set correo = '{0}' where claveUnica = { 1 }", a.correo, a.claveUnica),con);
      //ejecutar el cuery
      res = cmd.ExecuteNonQuery();
      con.Close();
      return res;
    }

    public List<Alumno> busca(Alumno nom)
    {
      int res = 0;
      List<Alumno> lis = new List<Alumno>();
      SqlDataReader drd;
      SqlConnection con;
      SqlCommand cmd;
      Alumno a;
      //conectarme a la base
      con = Conexion.conectar();
      //hacer el query 
      cmd = new SqlCommand(String.Format("select * from alumno where nombre like '%{0}%'", nom.correo, nom.claveUnica), con);
      //ejecutar el cuery
      drd = cmd.ExecuteReader();
      while (drd.Read())
      {
        a = new Alumno();
        a.claveUnica = drd.GetInt16(0);
        a.nombre = drd.GetString(1);
        a.sexo = drd.GetString(2);
        a.correo = drd.GetString(3);
        a.semestre = drd.GetInt16(4);
        a.programa = drd.GetInt16(5);
        lis.Add(a);
      }
      con.Close();
      return lis;
    }

  }
}
