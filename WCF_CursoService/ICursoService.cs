using System.ServiceModel;
using WCF_CursoService.Response;

namespace WCF_CursoService
{
    [ServiceContract]
    public interface ICursoService
    {
        [OperationContract]
        RespuestaCurso BuscarCursosPorNombre(string nombre);

        [OperationContract]
        RespuestaCurso ConsultarCursosPorAlumno(int idAlumno);
    }
}
