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
        #endregion

        #region CONSTRUCTOR
        public EditPetViewModel(INavigation navigation)
        {
            Navigation = navigation;
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
        #endregion
        #region METHODS
        public async Task GoToEdit()
        {
            await Navigation.PushAsync(new EditPet());
        }
        #endregion
        #region COMMANDS
        public ICommand GoToEditcommand => new Command(async () => await GoToEdit());
        #endregion
    }
}
