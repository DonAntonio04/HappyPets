using Firebase.Auth;
using Firebase.Database;
using HappyPets.Models;
using HappyPets.Views.LoginFolder;
using HappyPets.Views.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
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
        //public async Task GoToMainMenu()
        //{
        //    if (Email == string.Empty || Password == string.Empty)
        //    {
        //        await DisplayAlert("Hace falta algo", "Alguno de los campos esta vácio, verifica tú información!", "Ok");
        //    }

        //    else
        //    {
        //        await Navigation.PushAsync(new Main());
        //    }

        //}



        public async Task VerificationAndGoToMain()
        {
            FirebaseClient firebaseClient = new FirebaseClient("https://happydogsdb-default-rtdb.firebaseio.com/");

            var user = (await firebaseClient
              .Child("Users")
              .OnceAsync<UsersModel>()).FirstOrDefault(a => a.Object.Email == Email);

            if (user != null)
            {
               //await DisplayAlert("Exito","Correo Encontrado","Ok");

                if (user.Object.Password == Password)
                {
                  await DisplayAlert("Exito","Contraseña autenticada exitosamente", "ok");
                  await Navigation.PushAsync(new Main());
                }
                else
                {
                   await DisplayAlert("Error","Contraseña incorrecta","Ok");
                }
            }
            else
            {
               await DisplayAlert("Error","Usuario no encontrado","Ok");
            }

            if (Email == string.Empty || Password == string.Empty)
            {
                await DisplayAlert("Hace falta algo", "Alguno de los campos esta vácio, verifica tú información!", "Ok");
            }

          
            
               
            

        }


        public async Task GoToRegister()
        {
            await Navigation.PushAsync(new Register());
        }

        #endregion

        #region COMMANDS


        public ICommand VerificationAndGoToMainMenuCommand => new Command(async () => await VerificationAndGoToMain());
        public ICommand GoToRegisterCommand => new Command(async () => await GoToRegister());
        #endregion 
    }
}
