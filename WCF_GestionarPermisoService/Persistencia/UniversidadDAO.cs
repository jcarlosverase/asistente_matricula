using System.Collections.Generic;
using System.Data.SqlClient;
using WCF_GestionarPermisoService.Dominio;

namespace WCF_GestionarPermisoService.Persistencia
{
    public class UniversidadDAO
    {

        public Universidad Crear(Universidad Entidad)
        {
            Universidad Creado = null;
            string sql = "INSERT INTO dbo.Universidad VALUES (@RUC, @RazonSocial, 1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@RUC", Entidad.RUC));
                    comando.Parameters.Add(new SqlParameter("@RazonSocial", Entidad.RazonSocial)); 
                }
            }
            Creado = Obtener(Entidad.RUC);
            return Creado;
        }
        public Universidad Obtener(string RUC)
        {
            Universidad Encontrado = null;
            string sql = "SELECT * FROM dbo.Universidad WHERE RUC = @RUC";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@RUC", RUC));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            Encontrado = new Universidad()
                            {
                                RUC = (string)resultado["RUC"],
                                RazonSocial = (string)resultado["RazonSocial"], 
                            };
                        }
                    }
                }
            }
            return Encontrado;
        }
         
        public Universidad Modificar(Universidad Entidad)
        {
            Universidad Modificado = null;
            string sql = "UPDATE dbo.Universidad SET RazonSocial=@RazonSocial WHERE RUC=@RUC";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@RazonSocial", Entidad.RazonSocial)); 
                    comando.ExecuteNonQuery();
                }
            }
            Modificado = Obtener(Entidad.RUC);
            return Modificado;
        }

        public void Eliminar(string RUC)
        {
            string sql = "UPDATE dbo.Universidad SET FlgActivo=@FlgActivo WHERE RUC=@RUC";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@RUC", RUC));
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Universidad> Listar()
        {
            List<Universidad> Encontrados = new List<Universidad>(); 
            string sql = "SELECT * FROM dbo.Universidad";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new Universidad()
                            {
                                RUC = (string)resultado["RUC"],
                                RazonSocial = (string)resultado["RazonSocial"] 
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}