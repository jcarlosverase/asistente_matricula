using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarReporteService.Dominio;

namespace WCF_GestionarReporteService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IUniversidadUsuarioService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IUniversidadUsuarioService
    {
        [OperationContract]
        UniversidadUsuario Autenticacion(string RUC, string Correo, string Contrasenia);
    }
}
