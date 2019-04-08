using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarPermisoService.Dominio;
using WCF_GestionarPermisoService.Errores;

namespace WCF_GestionarPermisoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUniversidadService" en el código y en el archivo de configuración a la vez.
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
