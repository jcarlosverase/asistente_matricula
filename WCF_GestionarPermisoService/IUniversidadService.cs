using System.Collections.Generic;
using System.ServiceModel;
using WCF_GestionarPermisoService.Dominio;
using WCF_GestionarPermisoService.Errores;

namespace WCF_GestionarPermisoService
{
    [ServiceContract]
    public interface IUniversidadService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Universidad Crear(Universidad Parametro);

        [OperationContract]
        Universidad Obtener(string RUC);

        [OperationContract]
        Universidad Modificar(Universidad Parametro);

        [OperationContract]
        void Eliminar(string RUC);

        [OperationContract]
        List<Universidad> Listar();


    }
}
