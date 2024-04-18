using Firebase.Database;
using Firebase.Database.Query;
using HappyPets.Conexion;
using HappyPets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<ObservableCollection<UsersModel>> MostrarUser()
        {
            var data = await Task.Run(() => Cconexion.firebase
            .Child("Users")
            .AsObservable<UsersModel>()
            .AsObservableCollection());
            return data;
        }
    }
}
