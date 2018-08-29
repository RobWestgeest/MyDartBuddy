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
	public partial class UpdateAccountPage : ContentPage
	{
		
		public UpdateAccountPage()
		{
			Initialize(false);
		}

		public UpdateAccountPage(bool showNavigationBar)
		{
			Initialize(showNavigationBar);
		}

		private void Initialize(bool showNavigationBar)
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, showNavigationBar);			

			firstNameEntry.Text = ApplicationData.Current.CurrentAccount.FirstName;
			lastNameEntry.Text = ApplicationData.Current.CurrentAccount.LastName;
			emailEntry.Text = ApplicationData.Current.CurrentAccount.Email;
		}

		private async void OnUpdateAccountButtonClicked(object sender, EventArgs e)
		{
			if (!VerifyInput())
			{
				return;
			}

			IsBusy = true;
			try
			{				
				ApplicationData.Current.CurrentAccount = await UpdateAccountAsync();
				await Navigation.PopAsync();
				await DisplayAlert("Update account", "Your account has been updated", "OK");
			}
			catch (Exception ex)
			{
				mainMessageLabel.Text = $"Updating account has failed: {ex.Message}";
			}
			IsBusy = false;
		}

	


		private async Task<MyDartBuddy.Common.Entities.Account> UpdateAccountAsync()
		{
			AccountController accountController = new AccountController();
			return await accountController.UpdateAccountOnlineAsync(
				new MyDartBuddy.Common.Entities.Account()
				{
					Id = ApplicationData.Current.CurrentAccount.Id,
					FirstName = firstNameEntry.Text,
					LastName = lastNameEntry.Text,
					Email = emailEntry.Text,
					Password = SecurePasswordHasher.Hash(passwordEntry.Text)
				}
					).ConfigureAwait(false);
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