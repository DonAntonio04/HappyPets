using HappyPets.Datos;
using HappyPets.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class AddPetViewModel : BaseViewModel
    {
        #region VARIABLES
        string _PetName;
        string _PetRaze;
        string _PetAge;
        string _PetSize;
        string _PetImage;
        #endregion

        #region CONSTRUCTOR
        public AddPetViewModel(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion

        #region OBJECTS
        public string PetName
        {
            get { return _PetName; }
            set { SetValue(ref _PetName, value); }
        }
        public string PetRaze
        {
            get { return _PetRaze; }
            set { SetValue(ref _PetRaze, value); }
        }
        public string PetAge
        {
            get { return _PetAge; }
            set { SetValue(ref _PetAge, value);}
        }
        public string PetSize
        {
            get { return _PetSize; }
            set { SetValue(ref _PetSize, value); }
        }
        public string PetImage
        {
            get { return _PetImage; }
            set { SetValue(ref _PetImage, value);}
        }
        #endregion

        #region METHODS
        public async Task RegisterPet()
        {
            var parametros = new PetsModel();
            var function = new DatosPets();


            parametros.PetName = PetName;
            parametros.PetAge = PetAge;
            parametros.PetRaze = PetRaze;
            parametros.PetSize = PetSize;
            await function.InsertPet(parametros);

            await DisplayAlert("Registro Exitoso!", $"tu mascota se a registrado correctamente", "OK");
            await Navigation.PopAsync();
        }
        #endregion

        #region COMMANDS
        public ICommand RegisterPetCommand => new Command(async () => await RegisterPet());

        #endregion
    }
}
