using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDartBuddy.Client.UI.Pages.AccountPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GeneralAccountPage : ContentPage
	{
		public GeneralAccountPage()
		{
			InitializeComponent();
		}

		private void SwitchAccount_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new LoginAccountPage(true));
		}

		private void CreateAccount_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new UpdateAccountPage(true));
		}

		private void UpdateAccount_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new UpdateAccountPage(true));
		}
	}
}