using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarReporteService.Dominio;

namespace WCF_GestionarReporteService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IReportesService" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IReportesService
    {
        [OperationContract]
        List<Valoracion> RankingDocentes(DateTime FechaInicio, DateTime FechaFina);
        [OperationContract]
        void Enviar(string Correo, string Asunto, string Mensaje, byte[] Archivo = null, string NombreArchivo = "");

        [OperationContract]
        UniversidadUsuario Autenticacion(string RUC, string Correo, string Contrasenia);
    }
}
