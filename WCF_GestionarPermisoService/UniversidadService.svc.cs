
namespace WCF_GestionarPermisoService
{
    using System;
    using System.Collections.Generic;
    using Dominio;
    using Persistencia;
    using System.ServiceModel;
    using Errores;

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
