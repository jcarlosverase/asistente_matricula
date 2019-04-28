using System.Runtime.Serialization;

namespace WCF_ValoracionService.Dominio
{
    [DataContract]
    public class Sede
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string nombre { get; set; }
    }
}