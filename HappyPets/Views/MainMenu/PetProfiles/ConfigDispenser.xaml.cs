using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HappyPets.Models;
using HappyPets.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HappyPets.Views.MainMenu.PetProfiles
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigDispenser : ContentPage
	{
		public ConfigDispenser ()
		{
			InitializeComponent ();
			//BindingContext = new PetProfileViewModel();
		}
	}
}