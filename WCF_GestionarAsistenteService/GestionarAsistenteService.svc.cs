using System;
using WCF_GestionarAsistenteService;

namespace WCF_GestionarAsistenteService
{
    public class GestionarAsistenteService : IGestionarAsistenteService
    {
        public ValoracionService.RespuestaValoracion RegistrarValoracion(int idAlumno, int idDocente, int idCurso, int estrellas, string titulo, string resenia)
        {
            ValoracionService.RespuestaValoracion respuesta;
            try
            {
                ValoracionService.ValoracionServiceClient proxyValoracion = new ValoracionService.ValoracionServiceClient();
                respuesta = proxyValoracion.Registrar(idAlumno, idDocente, idCurso, estrellas, titulo, resenia);
            }
            catch (Exception ex)
            {
                respuesta = new ValoracionService.RespuestaValoracion();
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        public ValoracionService.RespuestaValoracion RankingValoracionDocentes(string nombreCurso)
        {
            ValoracionService.RespuestaValoracion respuesta;
            try
            {
                ValoracionService.ValoracionServiceClient proxyValoracion = new ValoracionService.ValoracionServiceClient();
                respuesta = proxyValoracion.RankingDocentes(nombreCurso);
            }
            catch (Exception ex)
            {
                respuesta = new ValoracionService.RespuestaValoracion();
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }
    }
}
