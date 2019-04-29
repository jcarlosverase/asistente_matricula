using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_GestionarAsistenteService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IGestionarAsistenteService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IGestionarAsistenteService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ValoracionService.RespuestaValoracion RegistrarValoracion(int idAlumno, int idDocente, int idCurso, int estrellas, string titulo, string resenia);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        ValoracionService.RespuestaValoracion RankingValoracionDocentes(string nombreCurso);
    }
}
