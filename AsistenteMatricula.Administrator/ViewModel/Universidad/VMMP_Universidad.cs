/*********************************************************
'* CREADO POR	 : COMPUTER SYSTEMS SOLUTION
'*				   ABEL QUISPE ORELLANA
'* FCH. CREACIÓN : 08/04/2016
**********************************************************/
namespace AsistenteMatricula.Administrator.ViewModel.Universidad
{
    using Entity;
    using Library;
    using Libreria;
    using MaterialDesignThemes.Wpf;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web.Script.Serialization;
    using System.Windows.Controls;
    using System.Windows.Input;

    public class VMMP_Universidad : NavigationPage
    {
        public VMMP_Universidad()
        { 
                LoadData(); 
        }

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
        
        public ICommand Save
        {
            get
            {
                return Command.GetICommand(new Action<object>(async (T) =>
                {
                    try
                    {
                        IsIndeterminate = true;
                        if (ValidaDatos())
                        {
                            IsIndeterminate = false;
                            return;
                        }

                        if (EUniversidad.Opcion == "I")
                        {
                            await new RestClient<EUniversidad>().POST(EUniversidad, Local.WCF_GestionarPermisoService + "Universidad");
                        }
                        else
                        {
                            await new RestClient<EUniversidad>().PUT(EUniversidad, Local.WCF_GestionarPermisoService + "Universidad");
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
            if (EUniversidad.RazonSocial == null || EUniversidad.RazonSocial.Trim().Length == 0)
            {
                DialogHostMessage = "Ingrese razón social";
                return true;
            }
            if (EUniversidad.RUC == null || EUniversidad.RUC.Trim().Length == 0)
            { 
                DialogHostMessage = "Ingrese RUC";
                return true;
            }
            if (  EUniversidad.RUC.Trim().Length != 11)
            {
                DialogHostMessage = "RUC debe contener 11 dígitos";
                return true;
            }
            return false;
        }

        private  void LoadData()
        {
            try
            {
                IsIndeterminate = true;
                
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
