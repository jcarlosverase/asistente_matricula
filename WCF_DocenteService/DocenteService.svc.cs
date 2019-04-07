using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_DocenteService.Dominio;
using WCF_DocenteService.Errores;
using WCF_DocenteService.Persistencia;

namespace WCF_DocenteService
{
    public class DocenteService : IDocenteService
    {
        private DocenteDAO docenteDAO = new DocenteDAO();

        public Docente CrearDocente(Docente docenteACrear)
        {
            if (docenteDAO.ObtenerPorDni(docenteACrear.Dni) != null) // Ya existe
            {
                throw new FaultException<RepetidoException>
                    (
                        new RepetidoException()
                        {
                            Codigo = "101",
                            Descripcion = "El docente ya existe"
                        }, 
                        new FaultReason("Error al intentar creación")
                    );
            }
            return docenteDAO.Crear(docenteACrear);
        }

        public Docente ObtenerDocente(int idDocente)
        {
            return docenteDAO.Obtener(idDocente);
        }

        public Docente ModificarDocente(Docente docenteAModificar)
        {
            return docenteDAO.Modificar(docenteAModificar);
        }

        public void EliminarDocente(int idDocente)
        {
            docenteDAO.Eliminar(idDocente);
        }

        public List<Docente> ListarDocentes()
        {
            return docenteDAO.Listar();
        }
    }
}
