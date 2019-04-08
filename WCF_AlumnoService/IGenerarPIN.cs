using Alumno.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_AlumnoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGenerarPIN" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGenerarPIN
    {
        [FaultContract(typeof(ResultObject))]
        [OperationContract]
        string CrearPIN();
    }
}
