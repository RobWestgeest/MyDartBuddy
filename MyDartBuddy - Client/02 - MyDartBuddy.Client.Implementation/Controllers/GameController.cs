using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDartBuddy.Client.Implementation.Controllers
{
	public class GameController: INotifyPropertyChanged
	{
		private List<int> thrownValues = new List<int>();
		private int _totalValue;
		private int _inputValue;
		private int _remainingValue;


		public int TotalValue { get { return _totalValue; } set { OnPropertyChanged("TotalValue"); _totalValue = value; } } 
		public int InputValue { get {return _inputValue; } set { OnPropertyChanged("InputValue"); _inputValue = value; } }
		public int RemainingValue { get { return _remainingValue; } set { OnPropertyChanged("RemainingValue"); _remainingValue = value; } }

		public event PropertyChangedEventHandler PropertyChanged;

		public GameController()
		{
			TotalValue = 501;
		}



		public void AddValue(int value)
		{
			int currentInputValue = int.Parse(string.Format("{0}{1}", InputValue == 0 ? "" : InputValue.ToString(), value));
			if (currentInputValue < 180)
			{
				InputValue = currentInputValue;
				if (InputValue != 0)
				{
					RemainingValue = TotalValue - InputValue;
				}
			}
		}


		public void ClearThrow()
		{
			InputValue = 0;
			RemainingValue = 0;
		}

		public void ConfirmThrow()
		{
			thrownValues.Add(InputValue);
			TotalValue -= InputValue;
			RemainingValue = 0;
			InputValue = 0;
		}

		public void UndoThrow()
		{
			ClearThrow();
			if (thrownValues.Count > 0)
			{
				int lastThrow = thrownValues.LastOrDefault();
				TotalValue += lastThrow;
				thrownValues.RemoveAt(thrownValues.Count - 1);
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
