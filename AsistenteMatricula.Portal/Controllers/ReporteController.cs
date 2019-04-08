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

    }
}
