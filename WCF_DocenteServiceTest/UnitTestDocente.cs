using System;
using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WCF_DocenteServiceTest
{
    [TestClass]
    public class UnitTestDocente
    {
        [TestMethod]
        public void TestCrearDocente()
        {
            DocentesWS.DocenteServiceClient proxy = new DocentesWS.DocenteServiceClient();
            DocentesWS.Docente docenteCreado = proxy.CrearDocente(new DocentesWS.Docente()
            {
                Nombres = "Esteban",
                Apellidos = "Paredes",
                Dni = "40333333",
                Estado = "Nuevo"
            });
            Assert.AreEqual("Esteban", docenteCreado.Nombres);
            Assert.AreEqual("Paredes", docenteCreado.Apellidos);
            Assert.AreEqual("40333333", docenteCreado.Dni);
            Assert.AreEqual("Nuevo", docenteCreado.Estado);
        }
        [TestMethod]
        public void TestCrearDocenteRepetido()
        {
            DocentesWS.DocenteServiceClient proxy = new DocentesWS.DocenteServiceClient();
            try
            {
                DocentesWS.Docente docenteCreado = proxy.CrearDocente(new DocentesWS.Docente()
                {
                    Nombres = "Esteban",
                    Apellidos = "Paredes",
                    Dni = "40333333",
                    Estado = "Nuevo"
                });
            }
            catch (FaultException<DocentesWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual("101", error.Detail.Codigo);
                Assert.AreEqual("El docente ya existe", error.Detail.Descripcion);
            }
        }
    }
}
