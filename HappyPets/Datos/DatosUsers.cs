using Firebase.Database;
using Firebase.Database.Query;
using HappyPets.Conexion;
using HappyPets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace HappyPets.Datos
{
    public class DatosUsers
    {
        public async Task InsertUser(UsersModel parametros)
        {
            await Cconexion.firebase
                .Child("Users")
                .PostAsync(new UsersModel()
                {
                    IdUser = Guid.NewGuid(),
                    Email = parametros.Email,
                    Name = parametros.Name,
                    Password = parametros.Password,
                    PhoneNumber = parametros.PhoneNumber,
                }
                );


        }
        // Asegúrate de tener esta referencia

        //public async Task<UsersModel> ObtenerUsuarioActual()
        //{
        //    // Verificar si existe información del usuario en el almacenamiento local
        //    if (Preferences.ContainsKey("IdUser"))
        //    {
        //        // Obtener el ID del usuario almacenado localmente
        //        string userId = Preferences.Get("IdUser", "");

        //        // Obtener la información del usuario desde Firebase utilizando el ID
        //        var user = await Cconexion.firebase
        //            .Child("Users")
        //            .Child(userId)
        //            .OnceSingleAsync<UsersModel>();

        //        return user;
        //    }
        //    else
        //    {
        //        // Si no hay información del usuario en el almacenamiento local, devolver null o algún otro valor predeterminado
        //        return null;
        //    }
        //}
        public async Task<ObservableCollection<UsersModel>> MostrarUsers()
        {
            var data = await Task.Run(() => Cconexion.firebase
            .Child("Users")
            .AsObservable<UsersModel>()
            .AsObservableCollection());
            return data;
        }

        //public async Task<UsersModel> MostrarUserLogueado(string userId)
        //{
        //    var data = await Task.Run(() => Cconexion.firebase
        //    .Child("Users")
        //    .Child(userId)
        //    .OnceAsync<UsersModel>());

        //    if (data != null && data.Any())
        //    {
        //        return data.First().Object;
        //    }

        //    return null;
        //}



    }
}
