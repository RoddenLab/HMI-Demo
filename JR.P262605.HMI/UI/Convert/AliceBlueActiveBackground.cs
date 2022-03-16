using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace JR.P262605.HMI.UI.Convert
{
    public class AliceBlueActiveBackground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? new SolidColorBrush(Colors.AliceBlue) : new SolidColorBrush(SystemColors.ControlColor);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}