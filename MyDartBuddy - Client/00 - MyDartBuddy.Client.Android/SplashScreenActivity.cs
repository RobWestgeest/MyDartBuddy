using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;

namespace TestApp.Droid
{
	[Activity(Label = "MyDartBuddy", Icon = "@drawable/icon", Theme = "@style/MainTheme.SplashScreen", MainLauncher = true, NoHistory = true)]
	public class SplashScreenActivity : Activity
	{
		static readonly string TAG = "X:" + typeof(SplashScreenActivity).Name;

		public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			base.OnCreate(savedInstanceState, persistentState);
			
		}

		// Launches the startup task
		protected override void OnResume()
		{
			base.OnResume();
			Task startupWork = new Task(() => { SimulateStartup(); });
			startupWork.Start();
		}

		// Simulates background work that happens behind the splash screen
		async void SimulateStartup()
		{
			
			await Task.Delay(1); // Simulate a bit of startup work.
			
			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}
	}
}