using Firebase.Auth;
using HappyPets.Datos;
using HappyPets.Models;
using HappyPets.Views.LoginFolder;
using HappyPets.Views.MainMenu;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class UserViewModel : BaseViewModel
    {
        #region VARIABLES
        public string _name;
        public string _email;
        public string _password;
        public int _phoneNumber;
        UsersModel _Selectusers;
        UsersModel _LoggedInUser;


        ObservableCollection<UsersModel> _Listusers;
        #endregion

        #region CONSTRUCTOR
        public UserViewModel(INavigation navigation/*, string userId*/)
        {
            Navigation = navigation;
            MostrarUsers();
            //MostrarUserLogueado(userId);
        }
        #endregion

        #region OBJECTS
        public ObservableCollection<UsersModel> Listusers
        {
            get { return _Listusers; }
            set
            {
                SetValue(ref _Listusers, value);
                OnpropertyChanged();
            }
        }
        public UsersModel SelectUsers
        {
            get { return _Selectusers; }
            set
            {
                if (_Selectusers != value)
                {
                    _Selectusers = value;
                }
            }
        }
        //public UsersModel LoggedInUser
        //{
        //    get { return _LoggedInUser; }
        //    set
        //    {
        //        SetValue(ref _LoggedInUser, value);
        //        OnPropertyChanged();
        //    }
        //}


        #endregion

        #region METHODS
        public async Task CerrarSesion()
        {
            await Navigation.PushAsync(new Login());
        }

        public async Task MostrarUsers()
        {
            var funcion = new DatosUsers();
            var usuario = await funcion.MostrarUsers();
            Listusers = usuario;
        }
        //public async Task MostrarUserLogueado(string userId)
        //{
        //    var funcion = new DatosUsers();
        //    var usuario = await funcion.MostrarUserLogueado(userId);
        //    LoggedInUser = usuario;
        //}

        public async Task EditarUsuario()
        {
            await Navigation.PushAsync(new EditUser());
        }
     
        #endregion

        #region COMMANDS
        public ICommand CerrarSesionCommand => new Command(async () => await CerrarSesion());

        public ICommand editarUserCommand => new Command(async () => await EditarUsuario());
        #endregion
    }
}
