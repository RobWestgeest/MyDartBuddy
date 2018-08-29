using Dapper;
using MyDartBuddy.Common.Entities;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace MyDartBuddy.WebApi.DataAccess
{
	public class AccountDataController
	{
		public void Create(Account account)
		{
			using(IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDartBuddy"].ConnectionString))
			{
				connection.Execute("[account].csp_CreateAccount @FirstName, @LastName, @Email, @Password", account);
			}
		}

		public Account Select(string email)
		{
			using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDartBuddy"].ConnectionString))
			{
				return connection.Query<Account>("[account].csp_SelectAccount  @Email", new { Email = email }).FirstOrDefault();
			}
		}


		public void Update(Account account)
		{
			using (IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDartBuddy"].ConnectionString))
			{
				connection.Execute("[account].csp_UpdateAccount @Id, @FirstName, @LastName, @Email, @Password", account);
			}
		}
	}
}
