using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using AsistenteMatricula.Test.Errores;

namespace AsistenteMatricula.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            try
            {

                var instLocal = new GPUniversidadService.UniversidadUsuarioServiceClient().Crear(new
                    GPUniversidadService.UniversidadUsuario()
                {
                    Correo = "orellana@upc.edu.pe",
                    RUC = "12345678912",
                    Nombre = "Alfredo",
                    Apellido = "Orellana",
                    Contrasenia ="123"
                });
                Assert.AreEqual("12345678912", instLocal.RUC);
                Assert.AreEqual("Alfredo", instLocal.Nombre);

            }
            catch (FaultException<RepetidoException> error)
            {
                throw new Exception(error.Detail.Descripcion);
            }
        }
    }
}
