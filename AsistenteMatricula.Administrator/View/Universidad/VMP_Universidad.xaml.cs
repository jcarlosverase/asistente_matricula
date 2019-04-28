/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 22/11/2017
**********************************************************/
namespace AsistenteMatricula.Administrator.View.Universidad
{
    using System.Windows.Controls;
    using ViewModel.Universidad;

    public partial class VMP_Universidad : UserControl
    {
        public VMP_Universidad()
        {
            InitializeComponent();
            DataContext = new VMMP_Universidad();
        }
    }
}