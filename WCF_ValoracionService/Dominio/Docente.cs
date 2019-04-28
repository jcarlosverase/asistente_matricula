using System.Runtime.Serialization;

namespace WCF_ValoracionService.Dominio
{
    [DataContract]
    public class Docente
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string nombres { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string apellidos { get; set; }
    }
}