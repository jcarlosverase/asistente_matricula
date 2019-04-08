using AsistenteMatricula.Libreria;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using WCF_GestionarReporteService.Dominio;

namespace WCF_GestionarReporteService.Persistencia
{
    public class ValoracionDAO
    {
        public List<Valoracion> RankingDocentes(DateTime FechaInicio, DateTime FechaFina)
        {
            List<Valoracion> Encontrados = new List<Valoracion>();
            try
            {

            string sql = "SELECT * FROM dbo.Valoracion WHERE CONVERT(VARCHAR(10), [Fecha], 112) = @Fecha";
            using (SqlConnection conexion = new SqlConnection(Local.ConnectionString_Valoracion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Fecha", FechaInicio.ToString("yyyyMMdd")));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            Encontrados.Add(new Valoracion()
                            {
                                Calificacion = (int)resultado["Calificacion"],
                                Curso = (string)resultado["Curso"],
                                Docente = (string)resultado["Docente"],
                                IdValoracion = (string)resultado["IdValoracion"],
                                Fecha = (DateTime)resultado["Fecha"]
                            });
                        }
                    }
                }
                }
            }
            catch (Exception ex)
            {
                var msh = ex.Message;
                throw;
            }
            return Encontrados;
        }

    }
}