/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 22/11/2017
**********************************************************/
namespace AsistenteMatricula.Administrator.ViewModel.Universidad
{
    using Entity;
    using Library;
    using Library.Interface;
    using Libreria;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Input;
    using View.Universidad;
    using View.UniversidadUsuario;

    public class VMPG_Universidad : NavigationPage , INavigationPage
    {
        public object Parameter
        {
            set
            {
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
        
        public ICommand INew
        {
            get
            {
                return Command.GetICommand(new Action<object>(async(T) =>
                {
                    var inst = new VMP_Universidad();
                    (inst.DataContext as VMMP_Universidad).EUniversidad = new EUniversidad() { Opcion = "I"};
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
                    SelectedItem = CollectionData.FirstOrDefault(x => x == (EUniversidad)T);
                    SelectedItem.Opcion = "U";
                    var inst = new VMP_Universidad();
                    (inst.DataContext as VMMP_Universidad).EUniversidad = SelectedItem;
                    var result = await DialogHost.Show(inst, "RootDialog");
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
                }));
            }
        }

        public ICommand IUsuario
        {
            get
            {
                return Command.GetICommand(new Action<object>( (T) =>
                {
                    SelectedItem = CollectionData.FirstOrDefault(x => x == (EUniversidad)T);
                    if (SelectedItem == null) return;
                    Ir(new VPG_UniversidadUsuario(), SelectedItem, null, "MyFrameUniversidad");
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

        private ObservableCollection<EUniversidad> _CollectionData;
        public ObservableCollection<EUniversidad> CollectionData
        {
            get
            {
                if (_CollectionData == null)
                    _CollectionData = new ObservableCollection<EUniversidad>();
                return _CollectionData;
            }
            set
            {
                _CollectionData = value;
                OnPropertyChanged("CollectionData");
            }
        }

        private EUniversidad _SelectedItem;
        public EUniversidad SelectedItem
        {
            get
            {
                return _SelectedItem;
            }
            set
            {
                _SelectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        private async void LoadData()
        {
            try
            {
                IsIndeterminate = true;
                CollectionData = await new RestClient<ObservableCollection<EUniversidad>>().GET(Local.WCF_GestionarPermisoService + "Universidad");
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
