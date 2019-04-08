using AsistenteMatricula.Libreria;
using System.Collections.Generic;
using System.Data.SqlClient;
using WCF_GestionarReporteService.Dominio;

namespace WCF_GestionarReporteService.Persistencia
{
    public class UniversidadUsuarioDAO
    {
         
        public UniversidadUsuario Autenticacion(string RUC, string Correo, string Contrasenia)
        {
            UniversidadUsuario Encontrado = null;
            string sql = "SELECT * FROM dbo.UniversidadUsuario WHERE RUC = @RUC and Correo = @Correo";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Seguridad))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@RUC", RUC ?? ""));
                    comando.Parameters.Add(new SqlParameter("@Correo", Correo ?? "")); 
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            if (EncryptRSA.Desencriptar((string)resultado["Contrasenia"], Local.ClavePrivada) == Contrasenia)
                            {
                                Encontrado = new UniversidadUsuario()
                                {
                                    Correo = (string)resultado["Correo"],
                                    RUC = (string)resultado["RUC"],
                                    Apellido = (string)resultado["Apellido"],
                                    Nombre = (string)resultado["Nombre"],
                                    Contrasenia = (string)resultado["Contrasenia"],
                                };
                            }
                        }
                    }
                }
            }
            return Encontrado;
        }
          
    }
}