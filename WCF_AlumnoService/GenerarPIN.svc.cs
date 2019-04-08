using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCF_AlumnoService
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "GenerarPIN" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione GenerarPIN.svc o GenerarPIN.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class GenerarPIN : IGenerarPIN
    {
        string IGenerarPIN.CrearPIN()
        {
            Random r = new Random();
            int pin = r.Next(1000, 9999);
            return pin.ToString();
        }
    }
}
