using System.Runtime.Serialization;

namespace WCF_CursoService.Dominio
{
    [DataContract]
    public class Curso
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string nombre { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string seccion { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string aula { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string horario { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public Docente docente { get; set; }

    }
}