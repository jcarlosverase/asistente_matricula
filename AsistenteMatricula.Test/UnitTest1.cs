using AsistenteMatricula.Test.PermisoService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.ServiceModel;

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

                var instLocal = new PermisoService.PermisoServiceClient();
                var usuario = instLocal.UniversidadUsuarioCrear(new
                PermisoService.UniversidadUsuario()
                {
                    Correo = "orellana3@upc.edu.pe",
                    RUC = "12345678912",
                    Nombre = "Alfredo",
                    Apellido = "Orellana",
                    Contrasenia = "123"
                });
                Assert.AreEqual("12345678912", usuario.RUC);
                Assert.AreEqual("Alfredo", usuario.Nombre);

            }
            catch (FaultException<RepetidoException> error)
            {
                Assert.AreEqual("El Correo ya existe", error.Detail.Descripcion); 
            }
        }
    }
}
