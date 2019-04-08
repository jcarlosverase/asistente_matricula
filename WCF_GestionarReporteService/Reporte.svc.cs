
namespace WCF_GestionarReporteService
{
    using Dominio;
    using Persistencia;

    public class Reporte : IReporte
    {
        private UsuarioDAO UsuarioDAODAO = new UsuarioDAO();

        public Usuario Autenticar(Usuario Usuario)
        {
            return UsuarioDAODAO.Autenticar(Usuario);
        }
    }
}
