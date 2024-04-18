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
    public class LoginViewModel : BaseViewModel
    {
        #region VARIABLES
        private string _email;
        private string _password;
        #endregion

        #region CONSTRUCTOR
        public LoginViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        #endregion

        #region METHODS
        public async Task GoToMainMenu()
        {
            if (Email == string.Empty || Password == string.Empty)
            {
                await DisplayAlert("Hace falta algo", "Alguno de los campos esta vácio, verifica tú información!", "Ok");
            }

            {
                await Navigation.PushAsync(new Main());
            }

        }
        public async Task GoToRegister()
        {
            await Navigation.PushAsync(new Register());
        }

        #endregion

        #region COMMANDS


        public ICommand GoToMainMenuCommand => new Command(async () => await GoToMainMenu());
        public ICommand GoToRegisterCommand => new Command(async () => await GoToRegister());
        #endregion 
    }
}
