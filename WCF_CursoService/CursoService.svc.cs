using System;
using WCF_CursoService.Persistencia;
using WCF_CursoService.Response;

namespace WCF_CursoService
{
    public class CursoService : ICursoService
    {
        private CursoDAO cursoDAO = new CursoDAO();

        public RespuestaCurso BuscarCursosPorNombre(string nombre)
        {
            RespuestaCurso respuesta = new RespuestaCurso();

            try
            {
                respuesta.Codigo = 200;
                respuesta.Mensaje = "OK";
                respuesta.Cursos = cursoDAO.BuscarPorNombre(nombre);
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
                respuesta.Cursos = null;
            }

            return respuesta;
        }

        public RespuestaCurso ConsultarCursosPorAlumno(int idAlumno)
        {
            RespuestaCurso respuesta = new RespuestaCurso();

            try
            {
                respuesta.Codigo = 200;
                respuesta.Mensaje = "OK";
                respuesta.Cursos = cursoDAO.ListarPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                respuesta.Codigo = -1;
                respuesta.Mensaje = ex.Message;
                respuesta.Cursos = null;
            }

            return respuesta;
        }
    }
}
