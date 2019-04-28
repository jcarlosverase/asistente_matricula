/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 22/11/2017
**********************************************************/
namespace AsistenteMatricula.Administrator.View.UniversidadUsuario
{
    using System.Windows.Controls;
    using ViewModel.UniversidadUsuario;

    public partial class VMP_UniversidadUsuario : UserControl
    {
        public VMP_UniversidadUsuario()
        {
            InitializeComponent();
            DataContext = new VMMP_UniversidadUsuario();
        }
    }
}