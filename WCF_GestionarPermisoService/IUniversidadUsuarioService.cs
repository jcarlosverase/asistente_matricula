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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUniversidadUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUniversidadUsuarioService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        UniversidadUsuario Crear(UniversidadUsuario Parametro);

        [OperationContract]
        UniversidadUsuario Obtener(string Correo);

        [OperationContract]
        UniversidadUsuario Modificar(UniversidadUsuario Parametro);

        [OperationContract]
        void Eliminar(string Correo);

        [OperationContract]
        List<UniversidadUsuario> Listar();
    }
}
