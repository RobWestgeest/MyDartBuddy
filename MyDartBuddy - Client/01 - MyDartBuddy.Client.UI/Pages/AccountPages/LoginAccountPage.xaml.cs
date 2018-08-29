using MyDartBuddy.Client.Implementation;
using MyDartBuddy.Client.Implementation.Controllers;
using MyDartBuddy.Common;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDartBuddy.Client.UI.Pages.AccountPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginAccountPage : ContentPage
	{
		public LoginAccountPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);			
		}

		public LoginAccountPage(bool showNavigationBar)
		{
			InitializeComponent();			
			NavigationPage.SetHasNavigationBar(this, showNavigationBar);
		}


		private async void OnLoginButtonClicked(object sender, EventArgs e)
		{
			if (!VerifyInput())
			{
				return;
			}
			IsBusy = true;

			try
			{
				MyDartBuddy.Common.Entities.Account account = await SelectAccountAsync();
				if (SecurePasswordHasher.Verify(passwordEntry.Text, account.Password))
				{
					ApplicationData.Current.CurrentAccount = account;
					await Navigation.PopAsync();
				}
				else
				{
					messageLabel.Text = "Login has failed. Incorrect password";
				}
			}
			catch (Exception ex)
			{
				messageLabel.Text = $"Login has failed: {ex.Message}";
			}

			IsBusy = false;
		}

		private async Task<MyDartBuddy.Common.Entities.Account> SelectAccountAsync()
		{
			AccountController accountController = new AccountController();
			return await accountController.LoadAccountOnlineAsync(emailEntry.Text).ConfigureAwait(false);
		}

		private bool VerifyInput()
		{
			emailMessageLabel.Text = "";
			passwordMessageLabel.Text = "";
			messageLabel.Text = "";

			bool correct = true;
			if (!IsValidEmail(emailEntry.Text))
			{
				emailMessageLabel.Text = "E-Mail is invalid";				
				correct = false;
			}			

			if (string.IsNullOrEmpty(passwordEntry.Text) || passwordEntry.Text.Length <= 7)
			{
				passwordMessageLabel.Text = "Password should contain 8 characters or more";
				correct = false;
			}			
			return correct;
		}

		private bool IsValidEmail(string email)
		{
			if (!string.IsNullOrEmpty(email))
			{
				Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
				Match match = regex.Match(email);
				return match.Success;
			}
			return false;
		}
	}
}