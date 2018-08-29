using MyDartBuddy.Common.Entities;
using MyDartBuddy.WebApi.Implementation;
using System.Threading.Tasks;
using System.Web.Http;

namespace MyDartBuddy.WebApi
{
	[RoutePrefix("api/account")]
	public class AccountController : BaseController
	{
		[HttpPost]
		public async Task<Account> Create(Account account)
		{
			AccountManager accountManager = new AccountManager();
			return await accountManager.Create(account).ConfigureAwait(false);
		}

		[HttpGet]
		[Route("{email}/accounts")]
		public async Task<Account> Select(string email)
		{
			AccountManager accountManager = new AccountManager();
			return await accountManager.Select(email).ConfigureAwait(false);
		}


		[HttpPut]
		public async Task<Account> Update(Account account)
		{
			AccountManager accountManager = new AccountManager();
			return await accountManager.Update(account).ConfigureAwait(false);
		}


	}
}
