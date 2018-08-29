using MyDartBuddy.Client.Common;
using MyDartBuddy.Common.Entities;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDartBuddy.Client.Implementation.Controllers 
{
	public class AccountController
	{
		public async Task<Account> CreateAccountOnlineAsync(Account account)
		{
			using (HttpClient client = new HttpClient())
			{
				string content = JsonConvert.SerializeObject(account);
				using (var response = await client.PostAsync(Path.Combine(Configuration.BaseConnectionString, "api/account"), new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false))
				{
					string result = await response.Content.ReadAsStringAsync();
					if (response.IsSuccessStatusCode)
					{
						return JsonConvert.DeserializeObject<Account>(result);
					}
					else
					{						
						throw new Exception(result);
					}
				}
			}
		}


		public async Task<Account> LoadAccountOnlineAsync(string email)
		{
			using (HttpClient client = new HttpClient())
			{
				using (var response = await client.GetAsync(Path.Combine(Configuration.BaseConnectionString, $"api/account/{email}/accounts")).ConfigureAwait(false))
				{
					string result = await response.Content.ReadAsStringAsync();
					if (response.IsSuccessStatusCode)
					{
						return JsonConvert.DeserializeObject<Account>(result);
					}
					else
					{
						throw new Exception(result);
					}
				}
			}
		}

		public async Task<Account> UpdateAccountOnlineAsync(Account account)
		{
			using (HttpClient client = new HttpClient())
			{
				string content = JsonConvert.SerializeObject(account);
				using (var response = await client.PutAsync(Path.Combine(Configuration.BaseConnectionString, "api/account"), new StringContent(content, Encoding.UTF8, "application/json")).ConfigureAwait(false))
				{
					string result = await response.Content.ReadAsStringAsync();
					if (response.IsSuccessStatusCode)
					{
						return JsonConvert.DeserializeObject<Account>(result);
					}
					else
					{
						throw new Exception(result);
					}
				}
			}
		}

		public void SaveAccountLocally(Account account)
		{
			try
			{
				StorageController sc = new StorageController();
				sc.SaveData("CurrentAccount", account);				
			}
			catch
			{
				throw new Exception("Account could not be stored");
			}
		}

		public Account LoadAccountLocally()
		{
			try
			{
				StorageController sc = new StorageController();
				return  sc.LoadData<Account>("CurrentAccount");
			}
			catch
			{
				throw new Exception("Account could not be loaded");
			}
		}
	}
}
