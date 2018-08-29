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
	public partial class LoginCreatePage : TabbedPage
	{
		public LoginCreatePage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}