using HappyPets.Models;
using HappyPets.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyPets.Views.MainMenu.PetProfiles
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPet : ContentPage
    {
        public EditPet(PetsModel pet)
        {
            InitializeComponent();
          //  BindingContext = new EditPetViewModel(pet,Navigation);
          BindingContext = new DeletePetViiewModel(pet,Navigation);
        }
    }
}