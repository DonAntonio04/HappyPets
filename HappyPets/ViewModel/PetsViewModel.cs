using HappyPets.Datos;
using HappyPets.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class PetsViewModel : BaseViewModel
    {
        #region VARIABLES
        public string _PetName;
        public string _PetRaze;
        public string _PetAge;
        public string _PetImage;
        public string _PetSize;
        #endregion

        #region CONSTRUCTOR
        public PetsViewModel(INavigation navigation)
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
            set { SetValue(ref _PetAge, value); }
        }
        public string PetImage
        {
            get { return _PetImage; }
            set { SetValue(ref _PetImage, value); }
        }
        public string PetSize
        {
            get { return _PetSize; }
            set { SetValue(ref _PetSize, value);}
        }
        #endregion

        #region METHODS
        public async Task RegisterPet()
        {
            var parametros = new PetsModel();
            var function = new DatosPets();


            parametros.PetAge = PetAge;
            parametros.PetImage = PetImage;
            parametros.PetName = PetName;
            parametros.PetSize = PetSize;
            parametros.PetRaze = PetRaze;

            await DisplayAlert("Registro Exitoso!", $"tu mascota se a registrado correctamente", "OK");
            await Navigation.PopAsync();
        }
        #endregion

        #region COMMANDS
        public ICommand RegisterPetCommand => new Command(async () => await RegisterPet());

        #endregion
    }
}
