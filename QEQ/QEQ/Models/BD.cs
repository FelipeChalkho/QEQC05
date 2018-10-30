using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace QEQ.Models
{
    public class BD
    {
        private static string ConnectionString = "Server=10.128.8.16;Database=QEQC05;User Id=QEQC05;Password=QEQC05;";
        private static SqlConnection Conectar()
        {
            SqlConnection a = new SqlConnection (ConnectionString);
            a.Open();
            return a;
        }
        public static void Desconectar (SqlConnection conexion)
        {
            conexion.Close();
        }
        public static bool TraerUnUsuario(string Email, string Contraseña)
        {
            bool Perfil = false;
            SqlConnection Conexion = Conectar();
            SqlCommand consulta = Conexion.CreateCommand();
            consulta.CommandText = "xLogin";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            consulta.Parameters.AddWithValue("@Email", Email);
            consulta.Parameters.AddWithValue("@Contraseña", Contraseña);
            SqlDataReader dataReader = consulta.ExecuteReader();
            if (dataReader.Read())
            {
                
                Perfil = dataReader.HasRows;
            }
            return Perfil;
        }

        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> usuario = new List<Usuario>();

            SqlConnection conexion = Conectar();
            SqlCommand consulta = conexion.CreateCommand();
            consulta.CommandText = "ListarUsuarios";
            consulta.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataReader Lector = consulta.ExecuteReader();

            while (Lector.Read())
            {
                string Nombre = Lector["Nombre"].ToString();
                string Email = Lector["Email"].ToString();
                string Contraseña = Lector["Contraseña"].ToString();
                bool Administrador = Convert.ToBoolean(Lector["Administrador"]);

                Usuario u = new Usuario();
                u.Administrador = Administrador;
                u.Email = Email;
                u.Contraseña = Contraseña;
                u.Nombre = Nombre;
                usuario.Add(u);
            }
            Desconectar(conexion);
            return usuario;
        }
    }
}