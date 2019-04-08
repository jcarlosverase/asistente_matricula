using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarPermisoService.Dominio;
using WCF_GestionarPermisoService.Errores;
using WCF_GestionarPermisoService.Persistencia;

namespace WCF_GestionarPermisoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UniversidadUsuarioService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UniversidadUsuarioService.svc o UniversidadUsuarioService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UniversidadUsuarioService : IUniversidadUsuarioService
    {
        private UniversidadUsuarioDAO DAO = new UniversidadUsuarioDAO();
        public UniversidadUsuario Crear(UniversidadUsuario Parametro)
        {
            if (DAO.Obtener(Parametro.Correo) != null) // Ya existe
            {
                throw new FaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El Correo ya existe"
                        },
                        new FaultReason("Error al intentar creación")
                    );
            }
            return DAO.Crear(Parametro);
        }

        public void Eliminar(string Correo)
        {
            DAO.Eliminar(Correo);
        }

        public List<UniversidadUsuario> Listar()
        {
            return DAO.Listar();
        }

        public UniversidadUsuario Modificar(UniversidadUsuario Parametro)
        {
            return DAO.Modificar(Parametro);
        }

        public UniversidadUsuario Obtener(string Correo)
        {
            return DAO.Obtener(Correo);
        }
    }
}
