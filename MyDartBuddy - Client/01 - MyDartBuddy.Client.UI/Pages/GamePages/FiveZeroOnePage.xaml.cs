using MyDartBuddy.Client.Implementation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyDartBuddy.Client.UI.Pages.GamePages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FiveZeroOnePage : ContentPage
	{
		private GameController gameController = new GameController();

		public FiveZeroOnePage()
		{
			InitializeComponent();

			lblTotalValue.BindingContext = gameController;
			lblInputValue.BindingContext = gameController;
			lblRemainingValue.BindingContext = gameController;
		}

		private void InputButton_Clicked(object sender, EventArgs e)
		{
			Button clickedButton = sender as Button;
			if(clickedButton != null)
			{
				gameController.AddValue(int.Parse(clickedButton.Text));
			}
		}

		private void ClearButton_Clicked(object sender, EventArgs e)
		{
			gameController.ClearThrow();
		}

		private void OkButton_Clicked(object sender, EventArgs e)
		{
			gameController.ConfirmThrow();
		}

		private void UndoButton_Clicked(object sender, EventArgs e)
		{
			gameController.UndoThrow();
		}
	}
}