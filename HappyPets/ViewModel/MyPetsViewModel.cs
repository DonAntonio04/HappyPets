using HappyPets.Datos;
using HappyPets.Models;
using HappyPets.Views.MainMenu;
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
        PetsModel _Selectpets;
            private ObservableCollection<ReferenceToObservableCollection> _mascotasDeEjemplo;
            private ReferenceToObservableCollection _petSelect;
          ObservableCollection<PetsModel> _Listpets;
        #endregion

        #region CONSTRUCTOR
            //public MyPetsViewModel(PetsModel pets, INavigation navigation)
            //{
            //    Navigation = navigation;
                
    
            //}

        public MyPetsViewModel( INavigation navigation)
        {
            Navigation = navigation;
            MostrarPets();
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

        public ObservableCollection<PetsModel> Listpets
        {
            get { return _Listpets; }
            set
            {
                SetValue(ref _Listpets, value);
                OnpropertyChanged();
            }
        }
        public PetsModel SelectPets
        {
            get { return _Selectpets; }
            set
            {
                if (_Selectpets != value)
                {
                    _Selectpets = value;
                }
            }
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
      
        public async Task MostrarPets()
        {
            var funcion = new DatosPets();
            var lista = await funcion.MostrarPets();
            Listpets = lista;
        }
            //public void Mostrar()
            //{
            //    _mascotasDeEjemplo = new ObservableCollection<ReferenceToObservableCollection>(MostrarImagenes());
            //}

            public async Task GoToPetProfile()
            {
                await Navigation.PushAsync(new PetProfile(_petSelect));
            }
        //public async Task OpenViewEdit()
        //{
        //    await Navigation.PushAsync(new EditPet(SelectPets));
        //}

        #endregion

        #region COMMANDS
        public ICommand AlimentarPetCommand => new Command(async () => await AlimentarPet());
   //     public ICommand OpenEditViewcommand => new Command(async () => await OpenViewEdit());
        public ICommand GoToProfileCommand => new Command(async () => await GoToPetProfile());
            #endregion
        
    }
}
