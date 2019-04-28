using System.Runtime.Serialization;

namespace WCF_ValoracionService.Response
{
    [DataContract]
    public class Respuesta
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Mensaje { get; set; }
    }
}