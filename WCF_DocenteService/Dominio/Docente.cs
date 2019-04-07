using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_DocenteService.Dominio
{
    [DataContract]
    public class Docente
    {
        [DataMember]
        public int IdDocente { get; set; }
        [DataMember]
        public string Nombres { get; set; }
        [DataMember]
        public string Apellidos { get; set; }
        [DataMember]
        public string Dni { get; set; }
        [DataMember(IsRequired = false)]
        public string Estado { get; set; }
    }
}