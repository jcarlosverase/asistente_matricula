
namespace AsistenteMatricula.Administrator.Entity
{
    using System.Runtime.Serialization;
     
    public class EUniversidadUsuario
    {
        public string Opcion { get; set; }
        public EUniversidad Universidad { get; set; }
        public int IdUniversidadUsuario { get; set; }
        public string Correo { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }

    }
}