﻿
namespace WCF_GestionarPermisoService.Errores
{
    using System.Runtime.Serialization;
    
    public class RepetidoException
    {
        public string Codigo { get; set; }
        
        public string Descripcion { get; set; } 
    }
}