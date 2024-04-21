using System;
using HappyPets.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HappyPets.Models;

namespace HappyPets.Views.MainMenu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePet : ContentPage
    {
        public DeletePet(PetsModel pets)
        {
            InitializeComponent();
         //  BindingContext = new EditPetViewModel(pets,Navigation);
        }
    }
}