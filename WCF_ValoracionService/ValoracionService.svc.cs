using System;
using WCF_ValoracionService.Persistencia;
using WCF_ValoracionService.Response;

namespace WCF_ValoracionService
{
    public class ValoracionService : IValoracionService
    {
        private ValoracionDAO valoracionDAO = new ValoracionDAO();

        public RespuestaValoracion Registrar(int idAlumno, int idDocente, int idCurso, int estrellas, string titulo, string resenia)
        {
            RespuestaValoracion respuesta = new RespuestaValoracion();

            try
            {
                respuesta.Codigo = 200;
                respuesta.Mensaje = valoracionDAO.Registrar(idAlumno, idDocente, idCurso, estrellas, titulo, resenia);
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        public RespuestaValoracion RankingDocentes(string nombreCurso)
        {
            RespuestaValoracion respuesta = new RespuestaValoracion();

            try
            {
                respuesta.Codigo = 200;
                respuesta.Mensaje = "OK";
                respuesta.Valoraciones = valoracionDAO.RankingDocentes(nombreCurso);
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
                respuesta.Valoraciones = null;
            }

            return respuesta;
        }


    }
}
