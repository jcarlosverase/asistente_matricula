using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarReporteService.Dominio;
using WCF_GestionarReporteService.Persistencia;

namespace WCF_GestionarReporteService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReportesService" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReportesService.svc o ReportesService.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReportesService : IReportesService
    {
        ValoracionDAO DAO = new ValoracionDAO(); 
        public List<Valoracion> RankingDocentes(DateTime FechaInicio, DateTime FechaFina)
        {
            return DAO.RankingDocentes(FechaInicio, FechaFina);
        }
    }
}
