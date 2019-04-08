using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_NotificacionService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "EnviarCorreo" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione EnviarCorreo.svc o EnviarCorreo.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class EnviarCorreo : IEnviarCorreo
    { 
        public void Enviar(string Correo, string Asunto, string Mensaje, byte[] Archivo = null, string NombreArchivo = "")
        { 
            var instMail = new Mail("smtp.gmail.com", "aqonotifications@gmail.com", "AqoN2017%");
            instMail.ValorDelReceptor(Correo, Asunto, Mensaje);
            if (Archivo != null && NombreArchivo.Length > 0)
                instMail.AgregarArchivoByte(Archivo, NombreArchivo);
            instMail.EnviarEmail();
        }
    }
}
