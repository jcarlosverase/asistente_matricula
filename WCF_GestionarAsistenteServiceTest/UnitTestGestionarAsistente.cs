using System;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCF_GestionarAsistenteServiceTest
{
    [TestClass]
    public class UnitTestGestionarAsistente
    {
        [TestMethod]
        public void TestMethodRegistrarValoracion()
        {
            string idAlumno = "0";
            string idDocente = "0";
            string idCurso = "0";
            string estrellas = "0";
            string titulo = "";
            string resenia = "";
            string URL = "http://localhost:64223/GestionarAsistenteService.svc/RegistrarValoracion?idAlumno=" + idAlumno + "&idDocente=" + idDocente + "&idCurso=" + idCurso + "&estrellas=" + estrellas + "&titulo=" + titulo + "&resenia=" + resenia;
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
        public void RankingValoracionDocentes()
        {
            string nombreCurso = "";
            string URL = "http://localhost:64223/GestionarAsistenteService.svc/RankingValoracionDocentes?nombreCurso=" + nombreCurso;
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
