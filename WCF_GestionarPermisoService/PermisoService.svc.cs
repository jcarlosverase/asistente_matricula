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
    public class PermisoService : IPermisoService
    {
        #region Universidad

        public Universidad UniversidadCrear(Universidad Parametro)
        {
            var DAO = new UniversidadDAO();
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

        public void UniversidadEliminar(string RUC)
        {
            var DAO = new UniversidadDAO();
            DAO.Eliminar(RUC);
        }

        public List<Universidad> UniversidadListar()
        {
            var DAO = new UniversidadDAO();
            return DAO.Listar();
        }

        public Universidad UniversidadModificar(Universidad Parametro)
        {
            var DAO = new UniversidadDAO();
            return DAO.Modificar(Parametro);
        }

        public Universidad UniversidadObtener(string RUC)
        {
            var DAO = new UniversidadDAO();
            return DAO.Obtener(RUC);
        }
        #endregion

        #region Universidad Usuario
         
        public UniversidadUsuario UniversidadUsuarioCrear(UniversidadUsuario Parametro)
        {
            var DAO = new UniversidadUsuarioDAO();
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

        public void UniversidadUsuarioEliminar(string Correo)
        {
            var DAO = new UniversidadUsuarioDAO();
            DAO.Eliminar(Correo);
        }

        public List<UniversidadUsuario> UniversidadUsuarioListar()
        {
            var DAO = new UniversidadUsuarioDAO();
            return DAO.Listar();
        }

        public UniversidadUsuario UniversidadUsuarioModificar(UniversidadUsuario Parametro)
        {
            var DAO = new UniversidadUsuarioDAO();
            return DAO.Modificar(Parametro);
        }

        public UniversidadUsuario UniversidadUsuarioObtener(string Correo)
        {
            var DAO = new UniversidadUsuarioDAO();
            return DAO.Obtener(Correo);
        }
        #endregion
    }
}
