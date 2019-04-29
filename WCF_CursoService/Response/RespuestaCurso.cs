using System.Collections.Generic;
using System.Runtime.Serialization;
using WCF_CursoService.Dominio;

namespace WCF_CursoService.Response
{
    [DataContract]
    public class RespuestaCurso : Respuesta
    {
        [DataMember]
        public List<Curso> Cursos { get; set; }
    }
}