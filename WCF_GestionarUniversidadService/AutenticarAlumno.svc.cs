using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WCF_GestionarUniversidadService.AlumnoSVC;

namespace WCF_GestionarUniversidadService
{
    public class AutenticarAlumno : IAutenticarAlumno
    {
        public bool Validar(string usuario, string pass)
        {
            AlumnoSVC.AlumnoClient proxy = new AlumnoSVC.AlumnoClient();
            if (proxy.ValidarEstudiante(usuario) == null)
            {
                throw new FaultException<ResultObject>(new ResultObject()
                {
                    Codigo = 103,
                    Mensaje = "Usuario no existe",
                    Data = ""
                }, new FaultReason("Error al intentar logueo"));
            }
            else
            {
                if (proxy.ValidarEstudiante(usuario).usuario == usuario && proxy.ValidarEstudiante(usuario).pass == pass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
