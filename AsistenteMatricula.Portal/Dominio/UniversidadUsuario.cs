
namespace AsistenteMatricula.Portal.Dominio
{
    using System.Runtime.Serialization;
    
    public class UniversidadUsuario
    {
        public string Correo { get; set; }
        
        public string RUC { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        
        public string Contrasenia { get; set; }

    }
}