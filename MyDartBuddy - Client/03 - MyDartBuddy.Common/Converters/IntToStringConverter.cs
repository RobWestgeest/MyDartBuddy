using System;
using Xamarin.Forms;

namespace MyDartBuddy.Client.Common.Converters
{
	public class IntToStringConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			if(((int)value) == 0)
			{
				return string.Empty;
			}
			else
			{
				return ((int)value).ToString();
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter,	System.Globalization.CultureInfo culture)
		{
			if (((int)value) == 0)
			{
				return string.Empty;
			}
			else
			{
				return ((int)value).ToString();
			}
		}
	}
}
