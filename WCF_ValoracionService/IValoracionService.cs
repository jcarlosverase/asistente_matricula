using System.ServiceModel;
using WCF_ValoracionService.Response;

namespace WCF_ValoracionService
{
    [ServiceContract]
    public interface IValoracionService
    {
        [OperationContract]
        RespuestaValoracion Registrar(int idAlumno, int idDocente, int idCurso, int estrellas, string titulo, string resenia);

        [OperationContract]
        RespuestaValoracion RankingDocentes(string nombreCurso);
    }
}
