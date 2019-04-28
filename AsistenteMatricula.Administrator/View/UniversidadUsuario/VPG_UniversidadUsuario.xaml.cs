/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 22/11/2017
**********************************************************/
namespace AsistenteMatricula.Administrator.View.UniversidadUsuario
{
    using System.Windows.Controls;
    using ViewModel.UniversidadUsuario;

    public partial class VPG_UniversidadUsuario : Page
    {
        public VPG_UniversidadUsuario()
        {
            InitializeComponent();
            DataContext = new VMPG_UniversidadUsuario();
        }
    }
}
