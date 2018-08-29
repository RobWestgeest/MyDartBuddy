using MyDartBuddy.Client.UI.Pages.AccountPages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyDartBuddy.Client.UI.Pages.GamesPages;

namespace MyDartBuddy.Client.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageMenu : ContentPage
	{
		public ListView ListView;
		public ObservableCollection<MenuItem> MenuItems { get; set; }

		public MainPageMenu()
		{
			MenuItems = new ObservableCollection<MenuItem>(new[]
				{
					new MenuItem {Title = "Games", TargetType = typeof(MainGamePage) },
					new MenuItem {Title = "Account", TargetType = typeof(GeneralAccountPage) },
					
				});

			InitializeComponent();
			ListView = MenuItemsListView;
		}

		
	}
}