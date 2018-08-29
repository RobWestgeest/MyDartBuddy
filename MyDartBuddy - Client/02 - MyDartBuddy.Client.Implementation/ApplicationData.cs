using MyDartBuddy.Client.Implementation.Controllers;
using MyDartBuddy.Common.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDartBuddy.Client.Implementation
{
	public class ApplicationData : INotifyPropertyChanged
	{		
		public static ApplicationData Current = new ApplicationData();
		

		public event PropertyChangedEventHandler PropertyChanged;

		private Account _currentAccount;
		public Account CurrentAccount
		{
			get
			{
				if (_currentAccount == null)
				{
					AccountController accountController = new AccountController();
					_currentAccount = accountController.LoadAccountLocally();
				}
				return _currentAccount;
			}
			set
			{
				AccountController accountController = new AccountController();
				accountController.SaveAccountLocally(value);
				_currentAccount = value;
				OnPropertyChanged("CurrentAccount");
				OnPropertyChanged("PageTitle");
				OnPropertyChanged("FullAccountName");
			}
		}

		public string PageTitle
		{
			get
			{
				if (CurrentAccount != null)
				{
					return $"MyDartBuddy - {FullAccountName}";
				}
				else
				{
					return "MyDartBuddy";
				}
			}			
		}

		public string FullAccountName
		{
			get
			{
				if (CurrentAccount != null)
				{
					return $"{CurrentAccount.FirstName} {CurrentAccount.LastName}";
				}
				else
				{
					return "MyDartBuddy";
				}
			}
		}



		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}
