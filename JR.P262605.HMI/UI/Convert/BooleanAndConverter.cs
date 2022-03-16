using System;
using System.Linq;
using System.Windows.Data;

namespace JR.P262605.HMI.UI.Convert
{
    public class BooleanAndConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool[] Booleans = new bool[values.Length];

            for (int ix = 0; ix < values.Length; ix++)
            {
                Booleans[ix] = System.Convert.ToBoolean(values[ix]);
            }

            return Booleans.All((x) => x);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
