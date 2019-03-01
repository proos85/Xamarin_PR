using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamarinBootcamp.ValueConverters
{
    public class LoginButtonMandatoryFieldsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!int.TryParse(value?.ToString() ?? string.Empty, out int numChars))
            {
                return false;
            }

            return numChars > 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
