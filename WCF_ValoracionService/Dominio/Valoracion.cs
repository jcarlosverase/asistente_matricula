using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCF_ValoracionService.Dominio
{
    [DataContract]
    public class Valoracion
    {
        [DataMember(EmitDefaultValue = false)]  
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int alumno { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string fecha_creacion { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Docente docente { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Sede sede { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Curso curso { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int estrellas { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string titulo { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string resenia { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int cantidad { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public decimal estrellas_promedio { get; set; }
    }
}