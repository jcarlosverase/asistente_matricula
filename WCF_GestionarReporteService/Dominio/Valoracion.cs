
namespace WCF_GestionarReporteService.Dominio
{
    using System;
    using System.Runtime.Serialization;

    [DataContract]
    public class Valoracion
    {
        [DataMember]
        public string IdValoracion { get; set; }

        [DataMember]
        public int Calificacion { get; set; }
        [DataMember]
        public string Curso { get; set; }
        [DataMember]
        public string Docente { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

    }
}