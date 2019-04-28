
namespace AsistenteMatricula.Test.Dominio.BDValoracion
{
    using System.Runtime.Serialization;
    
    public class Valoracion
    {
        public int IdValoracion { get; set; }
        public int IdEmpresa { get; set; }
        public int Calificacion { get; set; }
        public string Resenia { get; set; }
        public string Curso { get; set; }        
        public string Docente { get; set; }
         

    }
}