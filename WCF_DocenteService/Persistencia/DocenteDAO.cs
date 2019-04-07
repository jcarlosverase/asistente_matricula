using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_DocenteService.Dominio;

namespace WCF_DocenteService.Persistencia
{
    public class DocenteDAO
    {
        private string cadenaConexion = "Data Source=(local); Initial Catalog=BD_AsistenteMatricula; Integrated Security=SSPI;";

        public Docente Crear(Docente docenteACrear)
        {
            Docente docenteCreado = null;
            int idDocente = 0;
            string sql = "INSERT INTO dbo.TB_Docente VALUES (@nombres, @apellidos, @dni, @estado); SELECT SCOPE_IDENTITY()";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nombres", docenteACrear.Nombres));
                    comando.Parameters.Add(new SqlParameter("@apellidos", docenteACrear.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@dni", docenteACrear.Dni));
                    comando.Parameters.Add(new SqlParameter("@estado", docenteACrear.Estado));
                    idDocente = (int)(decimal)comando.ExecuteScalar();
                }
            }
            docenteCreado = Obtener(idDocente);
            return docenteCreado;
        }
        public Docente Obtener(int idDocente)
        {
            Docente docenteEncontrado = null;
            string sql = "SELECT * FROM dbo.TB_Docente WHERE NU_IdDocente=@idDocente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idDocente", idDocente));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            docenteEncontrado = new Docente()
                            {
                                IdDocente = (int)resultado["NU_IdDocente"],
                                Nombres = (string)resultado["TX_Nombres"],
                                Apellidos = (string)resultado["TX_Apellidos"],
                                Dni = (string)resultado["TX_Dni"],
                                Estado = (string)resultado["TX_Estado"]
                            };
                        }
                    }
                }
            }
            return docenteEncontrado;
        }
        public Docente ObtenerPorDni(string dni)
        {
            Docente docenteEncontrado = null;
            string sql = "SELECT * FROM dbo.TB_Docente WHERE TX_Dni=@dni";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            docenteEncontrado = new Docente()
                            {
                                IdDocente = (int)resultado["NU_IdDocente"],
                                Nombres = (string)resultado["TX_Nombres"],
                                Apellidos = (string)resultado["TX_Apellidos"],
                                Dni = (string)resultado["TX_Dni"],
                                Estado = (string)resultado["TX_Estado"]
                            };
                        }
                    }
                }
            }
            return docenteEncontrado;
        }
        public Docente Modificar(Docente docenteAModificar)
        {
            Docente docenteModificado = null;
            string sql = "UPDATE dbo.TB_Docente SET TX_Nombres=@nombres, TX_Apellidos=@apellidos, TX_Dni=@dni, TX_Estado=@estado WHERE NU_IdDocente=@idDocente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idDocente", docenteAModificar.IdDocente));
                    comando.Parameters.Add(new SqlParameter("@nombres", docenteAModificar.Nombres));
                    comando.Parameters.Add(new SqlParameter("@apellidos", docenteAModificar.Apellidos));
                    comando.Parameters.Add(new SqlParameter("@dni", docenteAModificar.Dni));
                    comando.Parameters.Add(new SqlParameter("@estado", docenteAModificar.Estado));
                    comando.ExecuteNonQuery();
                }
            }
            docenteModificado = Obtener(docenteAModificar.IdDocente);
            return docenteModificado;
        }
        public void Eliminar(int idDocente)
        {
            string sql = "DELETE FROM dbo.TB_Docente WHERE NU_IdDocente=@idDocente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@idDocente", idDocente));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Docente> Listar()
        {
            List<Docente> docentesEncontrados = new List<Docente>();
            Docente docenteEncontrado = null;
            string sql = "SELECT * FROM dbo.TB_Docente";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            docenteEncontrado = new Docente()
                            {
                                IdDocente = (int)resultado["NU_IdDocente"],
                                Nombres = (string)resultado["TX_Nombres"],
                                Apellidos = (string)resultado["TX_Apellidos"],
                                Dni = (string)resultado["TX_Dni"],
                                Estado = (string)resultado["TX_Estado"]
                            };
                            docentesEncontrados.Add(docenteEncontrado);
                        }
                    }
                }
            }
            return docentesEncontrados;
        }
    }
}