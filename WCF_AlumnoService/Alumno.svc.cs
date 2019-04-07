using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Alumno.Dominio;
using Alumno.Error;
using Alumno.Persistencia;

namespace Alumno
{
    public class Alumno : IAlumno
    {
        private AlumnoDAO alumnoDAO = new AlumnoDAO();

        public Estudiante CrearEstudiante(Estudiante estudianteACrear)
        {
            if (alumnoDAO.ObtenerUsuario(estudianteACrear.codigo) != null)
            {
                throw new FaultException<ResultObject>(new ResultObject()
                {
                    Codigo = 101,
                    Mensaje = "El alumno ya existe",
                    Data = ""
                }, new FaultReason("Error al intentar creación"));
            }
            return alumnoDAO.Crear(estudianteACrear);
        }

        public List<Estudiante> ListarEstudiantes()
        {
            return alumnoDAO.Listar();
        }

        public Estudiante ModificarEstudiante(Estudiante estudianteAModificar)
        {
            return alumnoDAO.Modificar(estudianteAModificar);
        }

        public Estudiante ValidarEstudiante(string usuario)
        {
            return alumnoDAO.ObtenerUsuario(usuario);
        }

        public Estudiante ObtenerEstudiante(string codigo)
        {
            return alumnoDAO.ObtenerCodigo(codigo);
        }
    }
}
