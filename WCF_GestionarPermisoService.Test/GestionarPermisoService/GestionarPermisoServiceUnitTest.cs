using AsistenteMatricula.Libreria;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace WCF_GestionarPermisoService.Test.GestionarPermisoService
{
    [TestClass]
    public class GestionarPermisoServiceUnitTest
    {
        private EUniversidad UniversidadCrear = new EUniversidad()
        {
            RUC = "12345678912",
            RazonSocial = "UPC"
        };

        [TestMethod]
        public void CrearUniversidad()
        {

            var result = (new RestClient<EUniversidad>().POST(UniversidadCrear, Local.WCF_GestionarPermisoService + "Universidad")).GetAwaiter().GetResult();

            Assert.AreEqual("12345678912", result.RUC);
            Assert.AreEqual("UPC", result.RazonSocial);
        }

        [TestMethod]
        public void CrearUniversidadDuplicado()
        {
            try
            {
                var result = (new RestClient<EUniversidad>().POST(UniversidadCrear, Local.WCF_GestionarPermisoService + "Universidad")).GetAwaiter().GetResult();

                Assert.AreEqual("12345678912", result.RUC);
                Assert.AreEqual("UPC", result.RazonSocial);
            }
            catch (WebException ex)
            {
                var RestClientException = ex.Serializer();
                Assert.AreEqual("101", RestClientException.Codigo);
                Assert.AreEqual("El RUC ya existe", RestClientException.Descripcion);
            }
        }
    }
}
