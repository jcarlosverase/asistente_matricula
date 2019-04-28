using System.ServiceModel;
using System.ServiceModel.Web;

namespace WCF_GestionarUniversidadService
{
    [ServiceContract]
    public interface IGestionarUniversidadService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CursoService.RespuestaCurso BuscarCursosPorNombre(string nombre);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        CursoService.RespuestaCurso ConsultarCursosPorAlumno(int idAlumno);
    }
}
