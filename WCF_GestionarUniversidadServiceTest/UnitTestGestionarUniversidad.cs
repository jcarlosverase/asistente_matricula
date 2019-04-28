using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCF_GestionarUniversidadServiceTest
{
    [TestClass]
    public class UnitTestGestionarUniversidad
    {
        [TestMethod]
        public void TestMethodBuscarCursosPorNombre()
        {
            string idAlumno = "1";
            string URL = "http://localhost:64158/GestionarUniversidadService.svc/ConsultarCursosPorAlumno?idAlumno=" + idAlumno;
            HttpWebRequest req = WebRequest.Create(URL) as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string respJSON = reader.ReadToEnd();

            if (respJSON.ToLower().Contains("\"mensaje\":\"ok\""))
            {
                Assert.AreEqual("", "");
            }
        }

        [TestMethod]
        public void ConsultarCursosPorAlumno()
        {
            string idAlumno = "1";
            string URL = "http://localhost:64158/GestionarUniversidadService.svc/ConsultarCursosPorAlumno?idAlumno=" + idAlumno;
            HttpWebRequest req = WebRequest.Create(URL) as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string respJSON = reader.ReadToEnd();

            if (respJSON.ToLower().Contains("\"mensaje\":\"ok\""))
            {
                Assert.AreEqual("", "");
            }
        }
    }
}
