using System.Collections.Generic;
using System.ServiceModel;
using WCF_GestionarPermisoService.Dominio;
using WCF_GestionarPermisoService.Errores;

namespace WCF_GestionarPermisoService
{
    [ServiceContract]
    public interface IUniversidadAlumnoService
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
