using AsistenteMatriculaLibreria;
using System.Collections.Generic;
using System.Data.SqlClient;
using WCF_GestionarPermisoService.Dominio;

namespace WCF_GestionarPermisoService.Persistencia
{
    public class UniversidadUsuarioDAO
    {

        public UniversidadUsuario Crear(UniversidadUsuario Entidad)
        {
            UniversidadUsuario Creado = null;
            string sql = "INSERT INTO dbo.UniversidadUsuario VALUES (@Correo, @RUC, @Nombre, @Apellido, @Contrasenia, 1);";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                { 
                    comando.Parameters.Add(new SqlParameter("@Correo", Entidad.Correo));
                    comando.Parameters.Add(new SqlParameter("@RUC", Entidad.RUC));
                    comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                    comando.Parameters.Add(new SqlParameter("@Apellido", Entidad.Apellido));
                    comando.Parameters.Add(new SqlParameter("@Contrasenia", EncryptRSA.Encriptar(Entidad.Contrasenia, Local.ClavePublica) )); 
                }
            }
            Creado = Obtener(Entidad.Correo);
            return Creado;
        }
        public UniversidadUsuario Obtener(string Correo)
        {
            UniversidadUsuario Encontrado = null;
            string sql = "SELECT * FROM dbo.UniversidadUsuario WHERE Correo = @Correo";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Correo", Correo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            Encontrado = new UniversidadUsuario()
                            {
                                Correo = (string)resultado["Correo"],
                                RUC = (string)resultado["RUC"],
                                Apellido = (string)resultado["Apellido"],
                                Nombre = (string)resultado["Nombre"],
                            };
                        }
                    }
                }
            }
            return Encontrado;
        }
         
        public UniversidadUsuario Modificar(UniversidadUsuario Entidad)
        {
            UniversidadUsuario Modificado = null;
            string sql = "UPDATE dbo.UniversidadUsuario SET Nombre=@Nombre, Apellido = @Apellido WHERE Correo=@Correo";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Nombre", Entidad.Nombre));
                    comando.Parameters.Add(new SqlParameter("@Apellido", Entidad.Apellido));
                    comando.ExecuteNonQuery();
                }
            }
            Modificado = Obtener(Entidad.Correo);
            return Modificado;
        }

        public void Eliminar(string Correo)
        {
            string sql = "UPDATE dbo.UniversidadUsuario SET FlgActivo=@FlgActivo WHERE Correo=@Correo";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Correo", Correo));
                    comando.Parameters.Add(new SqlParameter("@FlgActivo", 0));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<UniversidadUsuario> Listar()
        {
            List<UniversidadUsuario> Encontrados = new List<UniversidadUsuario>(); 
            string sql = "SELECT * FROM dbo.UniversidadUsuario";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        { 
                            Encontrados.Add(new UniversidadUsuario()
                            {
                                Correo = (string)resultado["Correo"],
                                RUC = (string)resultado["RUC"],
                                Apellido = (string)resultado["Apellido"],
                                Nombre = (string)resultado["Nombre"] 
                            });
                        }
                    }
                }
            }
            return Encontrados;
        }
    }
}