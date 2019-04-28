using AsistenteMatricula.Libreria;
using AsistenteMatricula.Test.Dominio.DBSeguridad;
using IronSharp.Core;
using IronSharp.IronMQ;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using Newtonsoft.Json;
using AsistenteMatricula.Test.Dominio.BDValoracion;

namespace AsistenteMatricula.Test
{
    [TestClass]
    public class UnitTestMensajeria
    {
        /*La mensajería consiste en almacenar la valoración en un agente
         * cuando uno de los servicios del proyecto no funciona. Esto con
         * el fin de no perder la opinión del alumno que es muy relevante 
         * para el sistema*/
        #region Inicialización

        private IronMqRestClient iromMq = IronSharp.IronMQ.Client.New(new IronClientConfig
        {
            ProjectId = "5cb674fb32f2d40009aefa6d",
            Token = "si1pnyRS0oepaKsLATPy",
            Host = "mq-aws-eu-west-1-1.iron.io",
            Scheme = Uri.UriSchemeHttp,
            Port = 80,
        });
        private Valoracion Valoracion = new Valoracion()
        {
            IdValoracion = 1,
            IdEmpresa = 1,
            Calificacion = 5,
            Curso = "Física 2",
            Docente = "Julio Perez",
            Resenia = "Buen profesor, domina muy bien los temas"
        };
        private const string NombreMensajeValoración = "Valoración";

        #endregion

        [TestMethod]
        public void Mensajeria()
        {
            try
            {
                //================ MENSAJERÍA ============================/
                QueueClient queue = iromMq.Queue(NombreMensajeValoración);
                var PostId = queue.Post(JsonConvert.SerializeObject(Valoracion));
                
                //================ SMS API EXTERNA ============================/
                const string YourAccessKey = "DDvVxT5TTOplE5uQIYYjwa4HQ";
                MessageBird.Client client = MessageBird.Client.CreateDefault(YourAccessKey);
                const long Msisdn = +51968215220;
                MessageBird.Objects.Message message =
                client.SendMessage("HAACC", "Mensaje de urgencia, existe problema en los servicio. Los alumnos no puede registrar valoraciones!", new[] { Msisdn });
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }

        [TestMethod]
        public void MensajeriaConsumo()
        {
            try
            {
                //Por lado del proveedor, cuando el servicio sea restablecido. Se procede a leer las valoraciones del AGENTE
                var re = iromMq.Queue(NombreMensajeValoración);

                QueueMessage next;
                while (re.Read(out next))
                {
                    next.Inspect();
                    
                    var instValoracion = JsonConvert.DeserializeObject<Valoracion>(next.Body);
                    if (instValoracion.IdValoracion == 1)
                    {
                        //INSERTA A LA BASE DE DATOS
                        Assert.AreEqual("Buen profesor, domina muy bien los temas", instValoracion.Resenia);
                    }
                    next.Delete();
                }
                 
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
    }
}
