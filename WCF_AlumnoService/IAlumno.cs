using Alumno.Dominio;
using Alumno.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Alumno
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAlumno" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAlumno
    {
        [FaultContract(typeof(ResultObject))]
        [OperationContract]
        Estudiante CrearEstudiante(Estudiante estudianteACrear);

        [OperationContract]
        Estudiante ValidarEstudiante(string usuario);

        [OperationContract]
        Estudiante ObtenerEstudiante(string codigo);

        [OperationContract]
        Estudiante ModificarEstudiante(Estudiante estudianteAModificar);

        [OperationContract]
        List<Estudiante> ListarEstudiantes();
    }
}
