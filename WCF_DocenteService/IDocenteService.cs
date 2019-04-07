using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_DocenteService.Dominio;
using WCF_DocenteService.Errores;

namespace WCF_DocenteService
{
    [ServiceContract]
    public interface IDocenteService
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Docente CrearDocente(Docente docenteACrear);

        [OperationContract]
        Docente ObtenerDocente(int idDocente);

        [OperationContract]
        Docente ModificarDocente(Docente docenteAModificar);

        [OperationContract]
        void EliminarDocente(int idDocente);

        [OperationContract]
        List<Docente> ListarDocentes();
    }
}
