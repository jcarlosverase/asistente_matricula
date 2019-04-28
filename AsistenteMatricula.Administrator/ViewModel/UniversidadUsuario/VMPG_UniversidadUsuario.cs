/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 22/11/2017
**********************************************************/
namespace AsistenteMatricula.Administrator.ViewModel.UniversidadUsuario
{
    using Entity;
    using Library;
    using Library.Interface;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using System.Linq;
    using View.UniversidadUsuario;
    using MaterialDesignThemes.Wpf;
    using Libreria;

    public class VMPG_UniversidadUsuario : NavigationPage , INavigationPage
    {
        public object Parameter
        {
            set
            {
                EUniversidad = (EUniversidad)value; 
                LoadData();
            }
        }
        
        #region Message DialogHost

        private bool _IsOpenDialogHost;
        public bool IsOpenDialogHost
        {
            get
            {
                return _IsOpenDialogHost;
            }
            set
            {
                _IsOpenDialogHost = value;
                OnPropertyChanged("IsOpenDialogHost");
            }
        }

        private string _DialogHostMessage;
        public string DialogHostMessage
        {
            get
            {
                return _DialogHostMessage;
            }
            set
            {
                _DialogHostMessage = value;
                if (_DialogHostMessage.Trim().Length > 0)
                    IsOpenDialogHost = true;
                else
                    IsOpenDialogHost = false;
                OnPropertyChanged("DialogHostMessage");
            }
        }

        public ICommand ICloseDialogHost
        {
            get
            {
                return Command.GetICommand(new Action<object>((T) =>
                {
                    DialogHostMessage = string.Empty;
                }));
            }
        }

        public ICommand IOpenDialogHost
        {
            get
            {
                return Command.GetICommand(new Action<object>((T) =>
                {
                    DialogHostMessage = (string)T;
                }));
            }
        }

        #endregion

        private EUniversidad _EUniversidad;
        public EUniversidad EUniversidad
        {
            get
            {
                return _EUniversidad;
            }
            set
            {
                _EUniversidad = value;
                OnPropertyChanged("EUniversidad");
            }
        }

        public ICommand INew
        {
            get
            {
                return Command.GetICommand(new Action<object>(async(T) =>
                {
                    var inst = new VMP_UniversidadUsuario();
                    (inst.DataContext as VMMP_UniversidadUsuario).EUniversidadUsuario = new EUniversidadUsuario() { Opcion = "I", Universidad  = EUniversidad };
                    var result = await DialogHost.Show(inst, "RootDialog");
                    LoadData();
                }));
            }
        }

        public ICommand ICancelar
        {
            get
            {
                return Command.GetICommand(new Action<object>((T) =>
                {
                    Volver();
                }));
            }
        }

        public ICommand IEdit
        {
            get
            {
                return Command.GetICommand(new Action<object>(async(T) =>
                { 
                    var SelectedItem = CollectionData.FirstOrDefault(x => x == (EUniversidadUsuario)T);
                    SelectedItem.Opcion = "U";
                    var inst = new VMP_UniversidadUsuario();
                    (inst.DataContext as VMMP_UniversidadUsuario).EUniversidadUsuario = SelectedItem;
                    var result = await DialogHost.Show(inst, "RootDialog");
                    LoadData();
                }));
            }
        }

        public ICommand IActualizar
        {
            get
            {
                return Command.GetICommand(new Action<object>((T) =>
                {
                    LoadData();
                }));
            }
        }
        public ICommand IDelete
        {
            get
            {
                return Command.GetICommand(new Action<object>((T) =>
                {
                    //var SelectedItem = CollectionData.FirstOrDefault(x => x == (EUniversidadUsuario)T);
                    //SelectedItem.Opcion = "D";
                    //var inst = new VMP_UniversidadUsuario();
                    //(inst.DataContext as VMMP_UniversidadUsuario).EUniversidadUsuario = SelectedItem;
                    //var result = await DialogHost.Show(inst, "RootDialog");
                    //LoadData();

                }));
            }
        }
        
        private bool _IsIndeterminate;
        public bool IsIndeterminate
        {
            get
            {
                return _IsIndeterminate;
            }
            set
            {
                _IsIndeterminate = value;
                IsEnableProcess = !value;
                OnPropertyChanged("IsIndeterminate");
            }
        }

        private bool _IsEnableProcess;
        public bool IsEnableProcess
        {
            get
            {
                return _IsEnableProcess;
            }
            set
            {
                _IsEnableProcess = value;
                OnPropertyChanged("IsEnableProcess");
            }
        }

        private bool _IsCheckedUniversidadUsuarioEliminados;
        public bool IsCheckedUniversidadUsuarioEliminados
        {
            get
            {
                return _IsCheckedUniversidadUsuarioEliminados;
            }
            set
            {
                _IsCheckedUniversidadUsuarioEliminados = value;
                LoadData(!value); 
                OnPropertyChanged("IsCheckedUniversidadUsuarioEliminados");
            }
        }

        private ObservableCollection<EUniversidadUsuario> _CollectionData;
        public ObservableCollection<EUniversidadUsuario> CollectionData
        {
            get
            {
                if (_CollectionData == null)
                    _CollectionData = new ObservableCollection<EUniversidadUsuario>();
                return _CollectionData;
            }
            set
            {
                _CollectionData = value;
                OnPropertyChanged("CollectionData");
            }
        }

        private async void LoadData(bool FlgEliminado = true)
        {
            try
            {
                IsIndeterminate = true;
                CollectionData = await new RestClient<ObservableCollection<EUniversidadUsuario>>().GET(Local.WCF_GestionarPermisoService + "UniversidadUsuarios/" + EUniversidad.IdUniversidad);
                IsIndeterminate = false;
            }
            catch (Exception ex)
            {
                IsIndeterminate = false;
                DialogHostMessage = ex.Message;
            }
        }
    }
}
