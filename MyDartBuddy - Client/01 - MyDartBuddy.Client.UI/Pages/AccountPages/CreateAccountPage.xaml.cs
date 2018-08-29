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
	public partial class CreateAccountPage : ContentPage
	{
		
		public CreateAccountPage()
		{			
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);			
		}

		public CreateAccountPage(bool showNavigationBar)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, showNavigationBar);
		}

		private async void OnCreateAccountButtonClicked(object sender, EventArgs e)
		{
			if (!VerifyInput())
			{
				return;
			}

			IsBusy = true;
			try
			{				
				ApplicationData.Current.CurrentAccount = await CreateAccountAsync();
				await Navigation.PopAsync();
				await DisplayAlert("Create account", "Your account has been created", "OK");
			}
			catch (Exception ex)
			{
				mainMessageLabel.Text = $"Creating account has failed: {ex.Message}";
			}
			IsBusy = false;
		}

	


		private async Task<MyDartBuddy.Common.Entities.Account> CreateAccountAsync()
		{
			AccountController accountController = new AccountController();
			await accountController.CreateAccountOnlineAsync(
				new MyDartBuddy.Common.Entities.Account()
				{
					FirstName = firstNameEntry.Text,
					LastName = lastNameEntry.Text,
					Email = emailEntry.Text,
					Password = SecurePasswordHasher.Hash(passwordEntry.Text)
				}
					).ConfigureAwait(false);

			return await accountController.LoadAccountOnlineAsync(emailEntry.Text);
		}


		private  bool VerifyInput()
		{
			firstNameMessageLabel.Text = "";
			lastNameMessageLabel.Text = "";
			emailMessageLabel.Text = "";
			passwordMessageLabel.Text = "";
			confirmPasswordMessageLabel.Text = "";
			mainMessageLabel.Text = "";

			bool correct = true;
			if(string.IsNullOrEmpty(firstNameEntry.Text))
			{
				firstNameMessageLabel.Text = "First name is required";
				correct = false;
			}

			if (string.IsNullOrEmpty(lastNameEntry.Text))
			{
				lastNameMessageLabel.Text = "Last name is required";
				correct = false;
			}			

			if (!IsValidEmail(emailEntry.Text))
			{
				emailMessageLabel.Text = "E-Mail is invalid";
				correct = false;
			}

			if (string.IsNullOrEmpty(passwordEntry.Text) || passwordEntry.Text.Length <=7)
			{
				passwordMessageLabel.Text = "Password should contain 8 characters or more";
				correct = false;
			}

			if (string.IsNullOrEmpty(confirmPasswordEntry.Text) || passwordEntry.Text != confirmPasswordEntry.Text)
			{
				confirmPasswordMessageLabel.Text = "Passwords should be the same";
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