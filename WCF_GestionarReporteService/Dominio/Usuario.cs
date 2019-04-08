
namespace WCF_GestionarReporteService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Usuario
    {
        [DataMember]
        public string IdUsuario { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string RUC { get; set; }

        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public string Contrasenia { get; set; }

    }
}