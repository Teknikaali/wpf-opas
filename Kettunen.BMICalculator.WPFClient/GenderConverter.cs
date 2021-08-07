using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Kettunen.BMICalculator.WPFClient
{
    public class GenderConverter : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => (Gender)value == (Gender)Enum.Parse(typeof(Gender), parameter as string);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => (bool?)value == true
                ? Enum.Parse(typeof(Gender), parameter as string)
                : null;

        public override object ProvideValue(IServiceProvider serviceProvider)
            => this;
    }
}
