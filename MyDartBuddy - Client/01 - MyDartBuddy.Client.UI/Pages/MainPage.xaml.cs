using MyDartBuddy.Client.Implementation;
using MyDartBuddy.Client.UI.Pages.AccountPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDartBuddy.Client.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : MasterDetailPage
	{
		public MainPage()
		{
			InitializeComponent();
			MenuPage.ListView.ItemSelected += ListView_ItemSelected;
			NavigationPage.SetHasNavigationBar(this, false);

			if (ApplicationData.Current.CurrentAccount == null)
			{
				Navigation.PushAsync(new LoginCreatePage());
			}
		}

		private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MenuItem;
			if (item == null)
			{
				return;
			}			
			var page = (Page)Activator.CreateInstance(item.TargetType);
			Detail = new NavigationPage(page);			
			IsPresented = false;
			MenuPage.ListView.SelectedItem = null;
		}
	}
}