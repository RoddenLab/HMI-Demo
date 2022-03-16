using System;
using System.Windows.Data;

namespace JR.P262605.HMI.UI.Convert
{
    public class HMIStationToRobotStation : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value switch
            {
                0 => 0,
                1 => 1,
                3 => 2,
                5 => 3,
                6 => 4,
                9 => 5,
                10 => 6,
                13 => 7,
                15 => 8,
                19 => 9,
                21 => 10,
                _ => 0
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (int)value switch
            {
                0 => 0,
                1 => 1,
                2 => 3,
                3 => 5,
                4 => 6,
                5 => 9,
                6 => 10,
                7 => 13,
                8 => 15,
                9 => 19,
                10 => 21,
                _ => 0
            };
        }
    }
}
