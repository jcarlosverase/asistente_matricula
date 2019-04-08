using System.Data.SqlClient;
using WCF_GestionarReporteService.Dominio;

namespace WCF_GestionarReporteService.Persistencia
{
    public class UsuarioDAO
    { 

        public Usuario Autenticar(Usuario Usuario)
        {
            Usuario UsuarioEncontrado = null;
            string sql = "SELECT * FROM dbo.TB_UniversidadUsuario WHERE Correo = @Correo and RUC = @RUC and Contrasenia = @Contrasenia";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Usuario", Usuario.Correo));
                    comando.Parameters.Add(new SqlParameter("@RUC", Usuario.RUC));
                    comando.Parameters.Add(new SqlParameter("@Contrasenia", Usuario.Contrasenia));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            UsuarioEncontrado = new Usuario()
                            {
                                IdUsuario = (string)resultado["IdUsuario"],
                                RUC = (string)resultado["RUC"],
                                Correo = (string)resultado["Correo"],
                                Nombre = (string)resultado["Nombre"], 
                            };
                        }
                    }
                }
            }
            return UsuarioEncontrado;
        } 
    }
}