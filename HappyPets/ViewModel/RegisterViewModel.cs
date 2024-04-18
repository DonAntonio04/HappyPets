using HappyPets.Datos;
using HappyPets.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        #region VARIABLES
        private string _name;
        public string _phonenumber;
        private string _email;
        private string _password;
        private string _passwordConfirm;
        #endregion

        #region CONSTRUCTOR
        public RegisterViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS

        public string Name
        {
            get { return _name; }
            set { SetValue(ref _name, value); }
        }

        public string PhoneNumber
        {
            get { return _phonenumber; }
            set { SetValue(ref _phonenumber, value); }
        }

        public string Email
        {
            get { return _email; }
            set { SetValue(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetValue(ref _password, value); }
        }
        public string PasswordConfirm
        {
            get { return _passwordConfirm; }
            set { SetValue(ref _passwordConfirm, value); }
        }
        #endregion

        #region METHODS

        //public async Task RegisterUserAsync()
        //{
        //    try
        //    {
        //        UsersModel usersToAdd = new UsersModel();
        //        usersToAdd.Email = _email;
        //        usersToAdd.Password = _password;
        //        usersToAdd.Name = _name;
        //        usersToAdd.PhoneNumber = _phonenumber;

        //        AuhtDataModel authData = new AuhtDataModel();
        //        authData.Email = _email;
        //        authData.Password = _password;
        //        authData.ReturnSecureToken = true;

        //        // Serializar los datos de autenticación
        //        var jsonAuthData = JsonConvert.SerializeObject(authData);

        //        // Crear una instancia de HttpClient
        //        using (var httpClient = new HttpClient())
        //        {
        //            // Especificar la URL del punto final de registro de Firebase
        //            var signUpUrl = "https://identitytoolkit.googleapis.com/v1/accounts:signUp?key=AIzaSyDSNgDmkvGv6a18hAk0CymT-_EgMORW50A";

        //            // Crear el contenido de la solicitud HTTP
        //            var content = new StringContent(jsonAuthData, System.Text.Encoding.UTF8, "application/json");

        //            // Realizar la solicitud HTTP POST al punto final de registro de Firebase
        //            HttpResponseMessage response = await httpClient.PostAsync(signUpUrl, content);

        //            // Verificar si la respuesta es exitosa
        //            if (response.IsSuccessStatusCode)
        //            {
        //                // Leer y procesar la respuesta JSON
        //                var jsonResponse = await response.Content.ReadAsStringAsync();
        //                var responseData = JsonConvert.DeserializeObject<dynamic>(jsonResponse);

        //                // Obtener el token y el ID del usuario de la respuesta
        //                var token = responseData.idToken;
        //                var uid = responseData.localId;

        //                // Serializar los datos del usuario
        //                var jsonUserData = JsonConvert.SerializeObject(usersToAdd);

        //                // Especificar la URL del punto final de Firebase Realtime Database
        //                var databaseUrl = $"https://happydogdb-55b97-default-rtdb.firebaseio.com/Users/{uid}.json?auth={token}";

        //                // Realizar la solicitud HTTP POST para agregar los datos del usuario a Firebase Realtime Database
        //                var databaseResponse = await httpClient.PostAsync(databaseUrl, new StringContent(jsonUserData, System.Text.Encoding.UTF8, "application/json"));

        //                // Verificar si la operación en la base de datos fue exitosa
        //                if (databaseResponse.IsSuccessStatusCode)
        //                {
        //                    // Redirigir a la página de inicio de sesión
        //                    // (Aquí debes implementar la navegación según la estructura de tu aplicación)
        //                    // this.router.navigate(['dashboard/login']);

        //                    await DisplayAlert("Registro Exitoso!", $"El usuario con email: {Email} fue registrado exitosamente", "OK");
        //                    await Navigation.PopAsync();
        //                }
        //                else
        //                {
        //                    await DisplayAlert("Error", "Error al registrarse", "Intentar nuevamente");
        //                }
        //            }
        //            else
        //            {
        //                await DisplayAlert("Error", "Error al registrarse", "Intentar nuevamente");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", $"Error al registrarse, {ex.Message}", "Intentar nuevamente");
        //    }
        //}

        public async Task Register()
        {

            var parametros = new UsersModel();
           var function = new DatosUsers();

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(Email))
            {
                await DisplayAlert("Error", "Error al registrarse", "Intentar nuevamente");
            }
            else if (Password != PasswordConfirm)
            {
                await DisplayAlert("Error", "La contraseña no coindice", "Intentar Nuevamnete");
            }
            else
            {
                parametros.Name = Name;
                parametros.PhoneNumber = PhoneNumber;
                parametros.Email = Email;
                parametros.Password = Password;
                await function.InsertUser(parametros);

                await DisplayAlert("Registro Exitoso!", $"El usuario con email: {Email} fue registrado exitosamente", "OK");
                await Navigation.PopAsync();
            }



        }
        #endregion

        #region COMMANDS
        public ICommand RegisterCommand => new Command(async () => await Register());
        #endregion
    }
}
