using System;
using System.Windows;
using System.Windows.Data;

namespace JR.P262605.HMI.UI.Convert
{
    public class BoolToVisibleOrHidden : IValueConverter
    {
        public BoolToVisibleOrHidden() { }
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            return bValue ? Visibility.Visible : (object)Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;
            return visibility == Visibility.Visible ? true : (object)false;
        }
    }
}
