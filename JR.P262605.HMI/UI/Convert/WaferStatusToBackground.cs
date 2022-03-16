using System;
using System.Windows.Data;
using System.Windows.Media;

namespace JR.P262605.HMI.UI.Convert
{
    public class WaferStatusToBackground : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (TypeLibrary.WaferStatus)value switch
            {
                TypeLibrary.WaferStatus.Empty => new SolidColorBrush(Colors.WhiteSmoke),
                TypeLibrary.WaferStatus.NotScanned => new SolidColorBrush(Colors.LightBlue),
                TypeLibrary.WaferStatus.Fault => new SolidColorBrush(Colors.LightCoral),
                TypeLibrary.WaferStatus.Done => new SolidColorBrush(Colors.LightGreen),
                TypeLibrary.WaferStatus.Ready => new SolidColorBrush(Colors.LightCyan),
                TypeLibrary.WaferStatus.Processing => new SolidColorBrush(Colors.LightYellow),
                _ => new SolidColorBrush(Colors.AliceBlue),
            };
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}