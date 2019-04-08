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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UniversidadService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UniversidadService.svc o UniversidadService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UniversidadService : IUniversidadService
    {
        private UniversidadDAO DAO = new UniversidadDAO();
        public Universidad Crear(Universidad Parametro)
        {
            if (DAO.Obtener(Parametro.RUC) != null) // Ya existe
            {
                throw new FaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El RUC ya existe"
                        },
                        new FaultReason("Error al intentar creación")
                    );
            }
            return DAO.Crear(Parametro);
        }

        public void Eliminar(string RUC)
        {
            DAO.Eliminar(RUC);
        }

        public List<Universidad> Listar()
        {
            return DAO.Listar();
        }

        public Universidad Modificar(Universidad Parametro)
        {
            return DAO.Modificar(Parametro);
        }

        public Universidad Obtener(string RUC)
        {
            return DAO.Obtener(RUC);
        }
    }
}
