using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Kettunen.BMICalculator.WPFClient
{
    public class GenderConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (Gender)value == (Gender)parameter;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool?)value == true
                ? parameter
                : null;

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
