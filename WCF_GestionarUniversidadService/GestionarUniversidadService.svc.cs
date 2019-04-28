using System;

namespace WCF_GestionarUniversidadService
{
    public class GestionarUniversidadService : IGestionarUniversidadService
    {
        public CursoService.RespuestaCurso BuscarCursosPorNombre(string nombre)
        {
            CursoService.CursoServiceClient proxyCurso = new CursoService.CursoServiceClient();
            CursoService.RespuestaCurso respuesta = proxyCurso.BuscarCursosPorNombre(nombre);

            return respuesta;
        }

        public CursoService.RespuestaCurso ConsultarCursosPorAlumno(int idAlumno)
        {
            CursoService.CursoServiceClient proxyCurso = new CursoService.CursoServiceClient();
            CursoService.RespuestaCurso respuesta = proxyCurso.ConsultarCursosPorAlumno(idAlumno);

            return respuesta;
        }
    }
}
