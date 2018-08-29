using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyDartBuddy.Client.Implementation.Controllers
{
	internal class StorageController
	{
		private const string FILENAME = "MyDartBuddyData";


		internal void SaveData(string key, object data)
		{
			if (Device.RuntimePlatform == Device.Android)
			{
				SaveData_Android(key, data);
			}			
		}

		internal T LoadData<T>(string key) where T: class, new()
		{
			if (Device.RuntimePlatform == Device.Android)
			{
				return LoadData_Android<T>(key);
			}
			return null;
		}


		private void SaveData_Android(string key, object data)
		{
			var accountStorage = Android.App.Application.Context.GetSharedPreferences(FILENAME, Android.Content.FileCreationMode.Private);
			var accountStorageEdit = accountStorage.Edit();
			accountStorageEdit.PutString(key, JsonConvert.SerializeObject(data));
			accountStorageEdit.Commit();
		}

		private T LoadData_Android<T>(string key) where T : class, new()
		{
			var accountStorage = Android.App.Application.Context.GetSharedPreferences(FILENAME, Android.Content.FileCreationMode.Private);
			string content = accountStorage.GetString(key, null);
			if (!string.IsNullOrEmpty(content))
			{
				return JsonConvert.DeserializeObject<T>(content);
			}
			return null;
		}
	}
}
