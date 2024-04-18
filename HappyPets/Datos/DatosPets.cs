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

namespace HappyPets.Datos
{
    public class DatosPets
    {
        public async Task InsertPet(PetsModel parametros)
        {
            await Cconexion.firebase
                .Child("Pets")
                .PostAsync(new PetsModel()
                {
                    IdPet = Guid.NewGuid(),
                    PetAge = parametros.PetAge,
                    PetImage = parametros.PetImage,
                    PetName = parametros.PetName,
                    PetSize = parametros.PetSize,
                    PetRaze = parametros.PetRaze,
                }
                );


        }
        public async Task EditPet(PetsModel newdata)
        {
            var update = (await Cconexion.firebase
                .Child("Pets")
                .OnceAsync<PetsModel>())
                .Where(a => a.Object.IdPet == newdata.IdPet).FirstOrDefault();


            await Cconexion.firebase
                .Child("Pets")
                .Child(update.Key)
                .PatchAsync(new PetsModel()
                {
                    IdPet = newdata.IdPet,
                    PetAge = newdata.PetAge,
                    PetImage = newdata.PetImage,
                    PetName = newdata.PetName,
                    PetSize = newdata.PetSize,
                    PetRaze = newdata.PetRaze,
                });
        }

        public async Task DeletePet(Guid idPet)
        {
            var petDelete = (await Cconexion.firebase
                .Child("Pets")
                .OnceAsync<PetsModel>()).Where(a => a.Object.IdPet == idPet).FirstOrDefault();
            await Cconexion.firebase.Child("Pets").Child(petDelete.Key).DeleteAsync(); 
        }

        public async Task<ObservableCollection<PetsModel>> MostrarPets()
        {
            var data = await Task.Run(() => Cconexion.firebase
            .Child("Pets")
            .AsObservable<PetsModel>()
            .AsObservableCollection());
            return data;
        }
    }
}
