using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarReporteService.Dominio;
using WCF_GestionarReporteService.Errores;
using WCF_GestionarReporteService.Persistencia;

namespace WCF_GestionarReporteService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UniversidadUsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UniversidadUsuarioService.svc o UniversidadUsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UniversidadUsuarioService : IUniversidadUsuarioService
    {
        UniversidadUsuarioDAO DAO = new UniversidadUsuarioDAO();
        public UniversidadUsuario Autenticacion(string RUC, string Correo, string Contrasenia)
        {
            return DAO.Autenticacion(RUC, Correo, Contrasenia);

            //if (usuario == null) 
            //{
            //    throw new FaultException<RepetidoException>
            //        (
            //            new RepetidoException()
            //            {
            //                Codigo = "101",
            //                Descripcion = "Usuario no existe"
            //            },
            //            new FaultReason("Error al intentar la autenticación")
            //        );
            //}
            //return usuario;
        }
         
    }
}
