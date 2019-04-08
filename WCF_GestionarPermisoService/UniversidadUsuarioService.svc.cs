
namespace WCF_GestionarPermisoService
{
    using System;
    using System.Collections.Generic;
    using Dominio;
    using Persistencia;
    using System.ServiceModel;
    using Errores;

    public class UniversidadUsuarioService : IUniversidadAlumnoService
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
