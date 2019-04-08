using AsistenteMatricula.Portal.ReportesService;
using AsistenteMatricula.Portal.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AsistenteMatricula.Portal.Controllers
{
    public class ReporteController : Controller
    {
        [HttpGet]
        [SecurityRequired] 
        public ActionResult RankingDocentes()
        {
            return View(new List<Valoracion>());
        }

        [HttpGet]
        [SecurityRequired]
        public ActionResult RankingDocentesFilterValueDataList(DateTime FechaInicio, DateTime FechaFina)
        {
            var Result = new ReportesService.ReportesServiceClient().RankingDocentes(FechaInicio, FechaFina).ToList(); 

            return PartialView("RankingDocentesPartial", Result);
        }

        [HttpGet]
        [SecurityRequired]
        public ActionResult Enviar(string Correo)
        {
            try
            {

                new ReportesService.ReportesServiceClient().Enviar(Correo, "Ranking de docentes", "Buenas tardes, le enviamos un nuevo reporte sobre los docentes", null, "");

                return Json("Enviado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                return Json("Problema en el servidor", JsonRequestBehavior.AllowGet);
            }
        }
    }
}
