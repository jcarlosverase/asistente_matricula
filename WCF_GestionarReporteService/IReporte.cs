using System.ServiceModel;
using WCF_GestionarReporteService.Dominio;

namespace WCF_GestionarReporteService
{
    [ServiceContract]
    public interface IReporte
    {
        //[FaultContract(typeof(ResultObject))]
        [OperationContract]
        Usuario Autenticar(Usuario Usuario);
    }
}
