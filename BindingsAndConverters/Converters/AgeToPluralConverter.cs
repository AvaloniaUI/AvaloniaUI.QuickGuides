using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BindingConvertersExample.Converters;

public class AgeToPluralConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is > 1 ? "s" : "";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}