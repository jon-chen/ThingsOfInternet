using System;
using Xamarin.Forms;
using ThingsOfInternet.Models;

namespace ThingsOfInternet.Converters
{
    public class ThingTypeConverter : IValueConverter
    {
        #region IValueConverter implementation

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is BlindSwitch)
            {
                return "Blind";
            }

            if (value is LightSwitch)
            {
                return "Light";
            }

            throw new ArgumentException("value must be of type IThing");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

