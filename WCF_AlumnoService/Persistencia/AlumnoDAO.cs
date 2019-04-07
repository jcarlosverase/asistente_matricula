using Alumno.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Alumno.Persistencia
{
    public class AlumnoDAO
    {
        private string cadenaConexion = "Server=(local)\\SQLEXPRESS;Initial Catalog=DBHaaccL;Integrated Security=SSPI;";

        public Estudiante Crear(Estudiante estudianteACrear)
        {
            Estudiante estudianteCreado = null;
            string sql = "INSERT INTO t_alumnos VALUES (@codigo, @usuario, @pass, @pin, @universidad)";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", estudianteACrear.codigo));
                    com.Parameters.Add(new SqlParameter("@usuario", estudianteACrear.usuario));
                    com.Parameters.Add(new SqlParameter("@pass", estudianteACrear.pass));
                    com.Parameters.Add(new SqlParameter("@pin", estudianteACrear.pin));
                    com.Parameters.Add(new SqlParameter("@universidad", estudianteACrear.universidad));
                    com.ExecuteNonQuery();
                }
            }

            estudianteCreado = ObtenerUsuario(estudianteACrear.usuario);
            return estudianteCreado;
        }

        public Estudiante ObtenerUsuario(string usuario)
        {
            Estudiante estudianteEncontrado = null;
            string sql = "SELECT * FROM t_alumnos WHERE tx_usuario = @usuario";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@usuario", usuario));

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            estudianteEncontrado = new Estudiante()
                            {
                                codigo = (string)resultado["tx_codAlumno"],
                                usuario = (string)resultado["tx_usuario"],
                                pass = (string)resultado["tx_pass"],
                                pin = (string)resultado["nu_pin"],
                                universidad = (string)resultado["tx_universidad"]
                            };
                        }
                    }
                }
            }

            return estudianteEncontrado;
        }

        public Estudiante ObtenerCodigo(string codigo)
        {
            Estudiante estudianteEncontrado = null;
            string sql = "SELECT * FROM t_alumnos WHERE tx_codAlumno = @codigo";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();

                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@codigo", codigo));

                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            estudianteEncontrado = new Estudiante()
                            {
                                codigo = (string)resultado["tx_codAlumno"],
                                usuario = (string)resultado["tx_usuario"],
                                pass = (string)resultado["tx_pass"],
                                pin = (string)resultado["nu_pin"],
                                universidad = (string)resultado["tx_universidad"]
                            };
                        }
                    }
                }
            }
            return estudianteEncontrado;
        }

            public Estudiante Modificar(Estudiante estudianteAModificar)
        {
            Estudiante estudianteModificado = null;
            string sql = "UPDATE t_alumnos SET " +
                "tx_usuario=@usuario, tx_pass=@pass, nu_pin=@pin, tx_universidad=@universidad " +
                "WHERE tx_codAlumno=@codigo";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@usuario", estudianteAModificar.usuario));
                    com.Parameters.Add(new SqlParameter("@pass", estudianteAModificar.pass));
                    com.Parameters.Add(new SqlParameter("@pin", estudianteAModificar.pin));
                    com.Parameters.Add(new SqlParameter("@universidad", estudianteAModificar.universidad));
                    com.Parameters.Add(new SqlParameter("@codigo", estudianteAModificar.codigo));
                    com.ExecuteNonQuery();
                }
            }
            estudianteModificado = ObtenerUsuario(estudianteAModificar.codigo);
            return estudianteModificado;
        }

        public List<Estudiante> Listar()
        {
            List<Estudiante> estudiantesEncontrados = new List<Estudiante>();
            Estudiante estudianteEncontrado = null;
            string sql = "SELECT * FROM t_alumnos";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            estudianteEncontrado = new Estudiante()
                            {
                                codigo = (string)resultado["tx_codAlumno"],
                                usuario = (string)resultado["tx_usuario"],
                                pass = (string)resultado["tx_pass"],
                                pin = (string)resultado["nu_pin"],
                                universidad = (string)resultado["tx_universidad"]
                            };
                            estudiantesEncontrados.Add(estudianteEncontrado);
                        }
                    }
                }
            }
            return estudiantesEncontrados;
        }
    }
}