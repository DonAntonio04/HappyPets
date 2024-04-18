using HappyPets.Models;
using HappyPets.Views.MainMenu.PetProfiles;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace HappyPets.ViewModel
{
    public class MyPetsViewModel : BaseViewModel
    {
        
            #region VARIABLES
            private ObservableCollection<ReferenceToObservableCollection> _mascotasDeEjemplo;
            private ReferenceToObservableCollection _petSelect;
            #endregion

            #region CONSTRUCTOR
            public MyPetsViewModel(INavigation navigation)
            {
                Navigation = navigation;
                Mostrar();
            }
            #endregion

            #region OBJECTS
            public ObservableCollection<ReferenceToObservableCollection> MascotasDeEjemplo
            {
                get { return _mascotasDeEjemplo; }
                set { SetValue(ref _mascotasDeEjemplo, value); }
            }
            public ReferenceToObservableCollection PetSelect
            {
                get { return _petSelect; }
                set { SetValue(ref _petSelect, value); }
            }
            #endregion

            #region METHODS
            public ObservableCollection<ReferenceToObservableCollection> MostrarImagenes()
            {
                return new ObservableCollection<ReferenceToObservableCollection>
            {
                new ReferenceToObservableCollection
                {
                    Imagen = "chiquinunis.jpge",
                    Nombre = "chiquinunis 1"
                },
                new ReferenceToObservableCollection
                {
                    Imagen = "chiquinunis.jpge",
                    Nombre = "chiquinunis 2"
                },
                new ReferenceToObservableCollection
                {
                    Imagen = "chiquinunis.jpge",
                    Nombre = "chiquinunis 3"
                }
            };
            }
            public async Task AlimentarPet()
            {
                await DisplayAlert("Listo", "se ha alimentado correctamente tu mascota", "OK");
            }
            public void Mostrar()
            {
                _mascotasDeEjemplo = new ObservableCollection<ReferenceToObservableCollection>(MostrarImagenes());
            }

            public async Task GoToPetProfile()
            {
                await Navigation.PushAsync(new PetProfile(_petSelect));
            }

            #endregion

            #region COMMANDS
            public ICommand AlimentarPetCommand => new Command(async () => await AlimentarPet());

            public ICommand GoToProfileCommand => new Command(async () => await GoToPetProfile());
            #endregion
        
    }
}
