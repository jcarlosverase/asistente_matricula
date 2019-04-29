using System;

namespace WCF_GestionarUniversidadService
{
    public class GestionarUniversidadService : IGestionarUniversidadService
    {
        public CursoService.RespuestaCurso BuscarCursosPorNombre(string nombre)
        {
            CursoService.RespuestaCurso respuesta;
            try
            {
                CursoService.CursoServiceClient proxyCurso = new CursoService.CursoServiceClient();
                respuesta = proxyCurso.BuscarCursosPorNombre(nombre);
            }
            catch (Exception ex)
            {
                respuesta = new CursoService.RespuestaCurso();
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;
        }

        public CursoService.RespuestaCurso ConsultarCursosPorAlumno(int idAlumno)
        {
            CursoService.RespuestaCurso respuesta;
            try
            {
                CursoService.CursoServiceClient proxyCurso = new CursoService.CursoServiceClient();
                respuesta = proxyCurso.ConsultarCursosPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                respuesta = new CursoService.RespuestaCurso();
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
            }

            return respuesta;

        }
    }
}
