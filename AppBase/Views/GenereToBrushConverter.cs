using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AppBase.Views
{
    internal class GenereToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Brush colore;

            if( Models.GenereEnum.Femmina == (Models.GenereEnum)value)
            {
                colore = Brushes.Pink;
            }else if (Models.GenereEnum.Maschio == (Models.GenereEnum)value)
            {
                colore = Brushes.Blue;
            }
            else
            {
                colore = Brushes.Green;
            }

            return colore;
            //throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            return Binding.DoNothing;
        }
    }
}
