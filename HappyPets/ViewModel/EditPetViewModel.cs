using HappyPets.Datos;
using HappyPets.Models;
using HappyPets.Views.MainMenu;
using HappyPets.Views.MainMenu.PetProfiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class EditPetViewModel : BaseViewModel
    {
        #region VARIABLES
        string _Name;
        string _Race;
        string _Age;
        string _Size;
        PetsModel _SelectPet;
        #endregion

        #region CONSTRUCTOR
     
        public EditPetViewModel(PetsModel petselect,INavigation navigation)
        {
            Navigation = navigation;

            _Name = petselect.PetName.ToString();
            _Race = petselect.PetRaze.ToString();
            _Age = petselect.PetAge.ToString();
           // _Size = petselect.PetSize.ToString();
            _SelectPet = petselect;
        }

        #endregion

        #region OBJECTS
        public string Name
        {
            get { return _Name; }
            set { SetValue(ref _Name, value); }
        }
        public string Race
        {
            get { return _Race; }
            set { SetValue(ref _Race, value); }
        }
        public string Age
        {
            get { return _Age; }
            set { SetValue(ref _Age, value);}
        }
        public string Size
        {
            get { return _Size; }
            set { SetValue(ref _Size, value);}
        }

        public PetsModel SelectPets
        {
            get { return _SelectPet; }
            set {  SetValue(ref _SelectPet, value);}
        }
        #endregion
        #region METHODS

        public async Task EditPet()
        {
            var parametros = new DatosPets();
            SelectPets.PetName = Name;
            SelectPets.PetAge = Age;
            SelectPets.PetRaze = Race;
        //    SelectPets.PetSize = Size;
            await parametros.EditPets(SelectPets);
            await DisplayAlert("Exito", "Se ha actualizado", "Ok");
            await Navigation.PushAsync(new MyPets());
        }

        public async Task DeletePet()
        {
            var parametros = new DatosPets();
            await parametros.DeletePets(SelectPets.IdPet);
            await DisplayAlert("Eliminado", $"La mascota con el nombre {SelectPets.PetName} eliminado", "Ok");
            await Navigation.PushAsync(new MyPets());
        }

        public async Task GoToEdit()
        {
            await Navigation.PushAsync(new EditPet(SelectPets));
        }
        #endregion
        #region COMMANDS
        public ICommand GoToEditcommand => new Command(async () => await GoToEdit());
        public ICommand EditPetcommand => new Command(async () => await EditPet());
        public ICommand DeletePetcomand => new Command(async () => await DeletePet());
        #endregion
    }
}
