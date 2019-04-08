using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_NotificacionService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IEnviarCorreo" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IEnviarCorreo
    {
        [OperationContract]
        void Enviar(string Correo, string Asunto, string Mensaje, byte[] Archivo, string NombreArchivo);
    }
}
