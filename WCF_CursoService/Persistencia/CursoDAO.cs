using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCF_CursoService.Dominio;

namespace WCF_CursoService.Persistencia
{
    public class CursoDAO : ConexionSQL
    {
        public List<Curso> BuscarPorNombre(string nombre)
        {
            List<Curso> cursosEncontrados = new List<Curso>();
            Curso cursoEncontrado = null;
            string sql = "dbo.ssp_Curso_BuscarPorNombre";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@Nombre", nombre));

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            cursoEncontrado = new Curso()
                            {
                                id = (int)resultado["id_curso"],
                                nombre = (string)resultado["nombre_curso"]
                            };
                            cursosEncontrados.Add(cursoEncontrado);
                        }
                    }
                }
            }
            return cursosEncontrados;
        }

        public List<Curso> ListarPorAlumno(int idAlumno)
        {
            List<Curso> cursosEncontrados = new List<Curso>();
            Curso cursoEncontrado = null;
            string sql = "dbo.ssp_Curso_ListarPorAlumno";
            using (SqlConnection conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.CommandType = System.Data.CommandType.StoredProcedure;
                    comando.Parameters.Add(new SqlParameter("@IdAlumno", idAlumno));

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            cursoEncontrado = new Curso()
                            {
                                id = (int)resultado["id_curso"],
                                nombre = (string)resultado["nombre_curso"],
                                seccion = (string)resultado["seccion_curso"],
                                aula = (string)resultado["aula_curso"],
                                horario = (string)resultado["horario_curso"],
                                docente = new Docente ()
                                {
                                    id = (int)resultado["id_docente"],
                                    nombres = (string)resultado["nombres_docente"],
                                    apellidos = (string)resultado["apellidos_docente"]
                                }                                
                            };
                            cursosEncontrados.Add(cursoEncontrado);
                        }
                    }
                }
            }
            return cursosEncontrados;
        }
    }
}