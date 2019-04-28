/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 08/04/2016
**********************************************************/
namespace AsistenteMatricula.Administrator.ViewModel.UniversidadUsuario
{
    using Entity;
    using Library;
    using Libreria;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Net;
    using System.Windows.Input;

    public class VMMP_UniversidadUsuario : NavigationPage
    {
        public VMMP_UniversidadUsuario()
        {
            IsIndeterminate = false;
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

        private EUniversidadUsuario _EUniversidadUsuario;
        public EUniversidadUsuario EUniversidadUsuario
        {
            get
            {
                return _EUniversidadUsuario;
            }
            set
            {
                _EUniversidadUsuario = value;
                OnPropertyChanged("EUniversidadUsuario");
            }
        }

        public ICommand Save
        {
            get
            {
                return Command.GetICommand(new Action<object>(async(T) =>
                {
                    try
                    {

                        IsIndeterminate = true;
                        if (ValidaDatos())
                        {
                            IsIndeterminate = false;
                            return;
                        }
                        if (EUniversidadUsuario.Opcion == "I")
                        {
                            await new RestClient<EUniversidadUsuario>().POST(EUniversidadUsuario, Local.WCF_GestionarPermisoService + "UniversidadUsuario");
                        }
                        else
                        {
                            await new RestClient<EUniversidadUsuario>().PUT(EUniversidadUsuario, Local.WCF_GestionarPermisoService + "UniversidadUsuario");
                        }
                        DialogHost.CloseDialogCommand.Execute(null, null);

                    }
                    catch (WebException ex)
                    {
                        var RestClientException = ex.Serializer();
                        IsIndeterminate = false;
                        DialogHostMessage = RestClientException.Descripcion;
                    }
                }));
            }
        }

        public ICommand Cancel
        {
            get
            {
                return Command.GetICommand(new Action<object>((T) =>
                {
                    DialogHost.CloseDialogCommand.Execute(null, null);

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

        private bool ValidaDatos()
        {
            bool value = false;
            if (EUniversidadUsuario.Nombre == null || EUniversidadUsuario.Nombre.Trim().Length == 0)
            {
                DialogHostMessage = "Ingrese nombre";
                value = true;
            }
            if (EUniversidadUsuario.Apellido == null || EUniversidadUsuario.Apellido.Trim().Length == 0)
            {
                DialogHostMessage = "Ingrese Apellido";
                value = true;
            }
            if (EUniversidadUsuario.Correo == null || EUniversidadUsuario.Correo.Trim().Length == 0)
            {
                DialogHostMessage = "Ingrese Correo";
                value = true;
            }
            if (EUniversidadUsuario.Contrasenia == null || EUniversidadUsuario.Contrasenia.Trim().Length == 0)
            {
                DialogHostMessage = "Ingrese Contraseña";
                value = true;
            }
            return value;
        }
         
    }
}
