
namespace WCF_GestionarPermisoService.Dominio
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Universidad
    {
        [DataMember]
        public string RUC { get; set; }

        [DataMember]
        public string RazonSocial { get; set; }
         

    }
}