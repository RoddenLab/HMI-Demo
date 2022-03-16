using System;
using System.Windows.Data;

namespace JR.P262605.HMI.UI.Convert
{
    public class ProcessStepToString : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (TypeLibrary.ProcessStep)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value;
        }
    }
}