using HappyPets.Views.MainMenu.PetProfiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class PetProfileViewModel : BaseViewModel
    {
        #region VARIABLES
        private string _nameOfPet;
        private string _image;
        #endregion

        #region CONSTRUCTOR
        public PetProfileViewModel(INavigation navigation, string image, string name)
        {
            Navigation = navigation;
            _image = image;
            _nameOfPet = name;
        }
        #endregion

        #region OBJECTS
        public string Image
        {
            get { return _image; }
            set { SetValue(ref _image, value); }
        }
        public string NameOfPet
        {
            get { return _nameOfPet; }
            set { SetValue(ref _nameOfPet, value); }
        }
        #endregion

        #region METHODS
        public async Task PetToDelete()
        {
            var request = await DisplayAlert("CUIDADO", $"¿Estas seguro que deseas eliminar a {NameOfPet}?", "Si", "No");
            if (request == true)
            {
                await DisplayAlert("Que triste noticia", "Nunca olvides a tus seres queridos, ellos no te olvidaran", "Aceptar");
                await Navigation.PopAsync();
            }
        }


        public async Task GoToStatisticsPet()
        {
            await Navigation.PushAsync(new PetStastiscs());
        }

        public async Task GoToEdit()
        {
            await Navigation.PushAsync(new EditPet());
        }


        #endregion

        #region COMMANDS

        public ICommand DeleteCommand => new Command(async () => await PetToDelete());
        //public ICommand GoToCameraCommand => new Command(async (pet) => await GoToPetCamera());
        public ICommand GoToStatisticsCommand => new Command(async () => await GoToStatisticsPet());
       
        public ICommand GoToEditCommand => new Command(async () => await GoToEdit());



        #endregion
    }
}
