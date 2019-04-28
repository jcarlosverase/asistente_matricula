using AsistenteMatricula.Libreria;
using AsistenteMatricula.Test.Dominio.DBSeguridad; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace AsistenteMatricula.Test
{
    [TestClass]
    public class UnitTestMensajeria
    {
        /*La mensajería consiste en almacenar la valoración en un agente
         * cuando uno de los servicios del proyecto no funciona. Esto con
         * el fin de no perder la opinión del alumno que es muy relevante 
         * para el sistema*/
        private Universidad UniversidadCrear = new Universidad()
        {
            RUC = "12345678912",
            RazonSocial = "UPC"
        };

        [TestMethod]
        public void CrearUniversidad()
        {

            var result = (new RestClient<Universidad>().POST(UniversidadCrear, Local.WCF_GestionarPermisoService + "Universidad")).GetAwaiter().GetResult();

            Assert.AreEqual("12345678912", result.RUC);
            Assert.AreEqual("UPC", result.RazonSocial);
        }

        [TestMethod]
        public void CrearUniversidadDuplicado()
        {
            try
            {
                var result = (new RestClient<Universidad>().POST(UniversidadCrear, Local.WCF_GestionarPermisoService + "Universidad")).GetAwaiter().GetResult();

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
