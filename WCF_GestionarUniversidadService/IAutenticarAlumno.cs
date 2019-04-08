using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_GestionarUniversidadService
{
    [ServiceContract]
    public interface IAutenticarAlumno
    {
        [FaultContract(typeof(AlumnoSVC.ResultObject))]
        [OperationContract]
        bool Validar(string usuario, string pass);
    }
}
