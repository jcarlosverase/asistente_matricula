using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Alumno.Error
{
    [DataContract]
    public class ResultObject
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Mensaje { get; set; }

        [DataMember]
        public object Data { get; set; }
    }
}