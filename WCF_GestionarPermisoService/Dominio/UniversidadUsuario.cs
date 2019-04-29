
namespace WCF_GestionarPermisoService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class UniversidadUsuario
    {
        [DataMember]
        public string Correo { get; set; }

        [DataMember]
        public string RUC { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Apellido { get; set; }

        [DataMember]
        public string Contrasenia { get; set; }

    }
}