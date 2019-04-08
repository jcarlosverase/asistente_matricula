using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Alumno.Dominio
{
    [DataContract]
    public class Estudiante
    {
        [DataMember]
        public string codigo { get; set; }

        [DataMember]
        public string usuario { get; set; }

        [DataMember]
        public string pass { get; set; }

        [DataMember]
        public string pin { get; set; }

        [DataMember]
        public string universidad { get; set; }
    }
}