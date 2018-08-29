using MyDartBuddy.Common.Entities;
using MyDartBuddy.WebApi.DataAccess;
using System;
using System.Threading.Tasks;

namespace MyDartBuddy.WebApi.Implementation
{
	public class AccountManager
    {
		private AccountDataController _accountDataController;

		public AccountManager()
		{
			_accountDataController = new AccountDataController();
		}


		public async Task<Account> Create(Account account)
		{			
			return await Task.Run(() => CreateAccount(account));
		}

		public async Task<Account> Update(Account account)
		{
			return await Task.Run(() => UpdateAccount(account));
		}


		public async Task<Account> Select(string email)
		{
			return await Task.Run(() => SelectAccount(email));
		}





		private Account CreateAccount(Account account)
		{			
			if(_accountDataController.Select(account.Email) != null)
			{
				throw new Exception("Account already exists");
			}

			_accountDataController.Create(account);
			return _accountDataController.Select(account.Email);
		}

		private Account UpdateAccount(Account account)
		{	
			_accountDataController.Update(account);
			return _accountDataController.Select(account.Email);
		}

		private Account SelectAccount(string email)
		{
			Account account = _accountDataController.Select(email);
			if(account == null)
			{
				throw new Exception("Account does not exists");
			}
			return account;
		}



	}
}
