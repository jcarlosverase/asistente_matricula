using AsistenteMatricula.Portal.GestionarReporteService;
using AsistenteMatricula.Portal.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Caching;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AsistenteMatricula.Portal.Controllers
{
    public class ReporteController : Controller
    {
        private static MemoryCache _cache = MemoryCache.Default;
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
            _cache.Set("RankingDocentesPartial", null, new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(+1) });
            var Result = new GestionarReporteService.ReportesServiceClient().RankingDocentes(FechaInicio, FechaFina).ToList();

            _cache.Set("RankingDocentesPartial", Result, new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now.AddDays(+1) });
            return PartialView("RankingDocentesPartial", Result);
        }

        [HttpGet]
        [SecurityRequired]
        public ActionResult Enviar(string Correo)
        {
            try
            {
                if(_cache.Get("RankingDocentesPartial") == null)
                    return Json("TablaNull", JsonRequestBehavior.AllowGet); 

                var instList = _cache.Get("RankingDocentesPartial") as List<Valoracion>;
                new GestionarReporteService.ReportesServiceClient().Enviar(Correo, "Ranking de docentes", 
                    "Buenas tardes, le enviamos un nuevo reporte sobre los docentes", WriteCSV(instList), "RankinDocentes-" + DateTime.Now.ToString("ddMMyyyy") + ".csv");

                return Json("Enviado", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var x = ex.Message;
                throw;
            }
        }
        public byte[] WriteCSV<T>(IEnumerable<T> items)
        {
            Type itemType = typeof(T);
            var props = itemType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                .OrderBy(p => p.Name);

            var inst = new MemoryStream();
            var writer = new StreamWriter(inst);
            var Cabecera = string.Join(", ", props.Select(p => p.Name));
            writer.WriteLine(Cabecera);

            foreach (var item in items)
            {
                var fila = string.Join(", ", props.Select(p => p.GetValue(item, null)));
                writer.WriteLine(fila);
            }
            writer.Flush();
            inst.Seek(0, SeekOrigin.Begin);

            return inst.ToArray();
        }
    }
}
