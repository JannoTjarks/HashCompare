using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace HashCompareGUI
{
    public class RadioConverter : IValueConverter
    {
        public object Convert(object v, Type t, object p, CultureInfo culture)
        {
            return v.Equals(p);
        }

        public object ConvertBack(object v, Type t, object p, CultureInfo culture)
        {
            return System.Convert.ToBoolean(v) ? p : null;
        }
    }
}
