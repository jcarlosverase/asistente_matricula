using System.Collections.Generic;
using System.Runtime.Serialization;
using WCF_ValoracionService.Dominio;

namespace WCF_ValoracionService.Response
{
    public class RespuestaValoracion : Respuesta
    {
        [DataMember]
        public List<Valoracion> Valoraciones { get; set; }
    }
}