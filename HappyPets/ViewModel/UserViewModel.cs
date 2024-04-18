using HappyPets.Views.LoginFolder;
using HappyPets.Views.MainMenu;
using System;
using System.Collections.Generic;
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

        #endregion

        #region CONSTRUCTOR
        public UserViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        #endregion

        #region METHODS
        public async Task CerrarSesion()
        {
            await Navigation.PushAsync(new Login());
        }
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
