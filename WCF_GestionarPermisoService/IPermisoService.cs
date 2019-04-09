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
    public interface IPermisoService
    {
        #region Universidad

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Universidad UniversidadCrear(Universidad Parametro);

        [OperationContract]
        Universidad UniversidadObtener(string RUC);

        [OperationContract]
        Universidad UniversidadModificar(Universidad Parametro);

        [OperationContract]
        void UniversidadEliminar(string RUC);

        [OperationContract]
        List<Universidad> UniversidadListar();
        #endregion

        #region Universidad Usuario

        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        UniversidadUsuario UniversidadUsuarioCrear(UniversidadUsuario Parametro);

        [OperationContract]
        UniversidadUsuario UniversidadUsuarioObtener(string Correo);

        [OperationContract]
        UniversidadUsuario UniversidadUsuarioModificar(UniversidadUsuario Parametro);

        [OperationContract]
        void UniversidadUsuarioEliminar(string Correo);

        [OperationContract]
        List<UniversidadUsuario> UniversidadUsuarioListar();
        #endregion
    }
}
