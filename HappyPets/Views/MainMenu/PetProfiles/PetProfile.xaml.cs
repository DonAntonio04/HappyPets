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
    public partial class PetProfile : ContentPage
    {
        public PetProfile(ReferenceToObservableCollection dataOfPet)
        {
            InitializeComponent();
            BindingContext = new PetProfileViewModel(Navigation, dataOfPet.Imagen, dataOfPet.Nombre);
        }
    }
}