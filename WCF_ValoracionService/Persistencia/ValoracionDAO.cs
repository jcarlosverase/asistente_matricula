using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_ValoracionService.Dominio;

namespace WCF_ValoracionService.Persistencia
{
    public class ValoracionDAO : ConexionSQL
    {
        public string Registrar(int idAlumno, int idDocente, int idCurso, int estrellas, string titulo, string resenia)
        {
            string respuesta = "";
            string sql = "dbo.ssp_Valoracion_Registrar";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdAlumno", idAlumno));
                    comando.Parameters.Add(new SqlParameter("@IdDocente", idDocente));
                    comando.Parameters.Add(new SqlParameter("@IdCurso", idCurso));
                    comando.Parameters.Add(new SqlParameter("@Estrellas", estrellas));
                    comando.Parameters.Add(new SqlParameter("@Titulo", titulo));
                    comando.Parameters.Add(new SqlParameter("@Resenia", resenia));

                    comando.ExecuteNonQuery();
                    respuesta = "OK";
                }
            }
            return respuesta;
        }

        public List<Valoracion> RankingDocentes(string nombreCurso)
        {
            List<Valoracion> valoracionEncontrados = new List<Valoracion>();
            Valoracion valoracionEncontrado = null;
            string sql = "dbo.ssp_Valoracion_RankingDocentes";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@NombreCurso", nombreCurso));

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            var estrellas_promedio = (decimal)resultado["estrellas_promedio"];

                            valoracionEncontrado = new Valoracion()
                            {
                                docente = new Docente()
                                {
                                    id = (int)resultado["id_docente"],
                                    nombres = (string)resultado["nombres_docente"],
                                    apellidos = (string)resultado["apellidos_docente"]
                                },
                                sede = new Sede()
                                {
                                    nombre = (string)resultado["nombre_sede"]
                                },
                                curso = new Curso()
                                {
                                    id = (int)resultado["id_curso"],
                                    nombre = (string)resultado["nombre_curso"],
                                },
                                cantidad = (int)resultado["cantidad_valoraciones"],
                                estrellas_promedio = (decimal)resultado["estrellas_promedio"]
                            };
                            valoracionEncontrados.Add(valoracionEncontrado);
                        }
                    }
                }
            }
            return valoracionEncontrados;
        }
    }
}