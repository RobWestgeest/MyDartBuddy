
using MyDartBuddy.Client.UI.Pages.GamePages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDartBuddy.Client.UI.Pages.GamesPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainGamePage : ContentPage
	{		
		public MainGamePage()
		{			
			InitializeComponent();			
		}

		private void Button_Clicked(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new FiveZeroOnePage());
		}
	}
}