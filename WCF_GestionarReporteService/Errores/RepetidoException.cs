
namespace WCF_GestionarReporteService.Errores
{
    using System.Runtime.Serialization;

    [DataContract]
    public class RepetidoException
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Descripcion { get; set; } 
    }
}