using System;
using Xamarin.Forms;

namespace MyDartBuddy.Client.Common.Converters
{
	public class BooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return !(bool)value;
		}

		public object ConvertBack(object value, Type targetType, object parameter,	System.Globalization.CultureInfo culture)
		{
			return !(bool)value;
		}
	}
}
