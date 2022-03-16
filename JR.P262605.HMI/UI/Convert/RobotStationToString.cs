using System;
using System.Windows.Data;

namespace JR.P262605.HMI.UI.Convert
{
    public class RobotStationToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (TypeLibrary.RobotStation)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value;
        }
    }
}