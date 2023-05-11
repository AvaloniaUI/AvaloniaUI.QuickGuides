using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace BindingConvertersExample.Converters;

public class BirthdateToAgeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not DateTimeOffset ageDto) return 0;

        var diff = DateTimeOffset.Now - ageDto;
        
        var age = (int)Math.Round(diff.TotalDays / 365);

        return age >= 0 ? age : 0;
    }
}