using WCF_GestionarAsistenteService;

namespace WCF_GestionarAsistenteService
{
    public class GestionarAsistenteService : IGestionarAsistenteService
    {
        public ValoracionService.RespuestaValoracion RegistrarValoracion(int idAlumno, int idDocente, int idCurso, int estrellas, string titulo, string resenia)
        {
            ValoracionService.ValoracionServiceClient proxyValoracion = new ValoracionService.ValoracionServiceClient();
            ValoracionService.RespuestaValoracion respuesta = proxyValoracion.Registrar(idAlumno, idDocente, idCurso, estrellas, titulo, resenia);

            return respuesta;
        }

        public ValoracionService.RespuestaValoracion RankingValoracionDocentes(string nombreCurso)
        {
            ValoracionService.ValoracionServiceClient proxyValoracion = new ValoracionService.ValoracionServiceClient();
            ValoracionService.RespuestaValoracion respuesta = proxyValoracion.RankingDocentes(nombreCurso);

            return respuesta;
        }
    }
}
