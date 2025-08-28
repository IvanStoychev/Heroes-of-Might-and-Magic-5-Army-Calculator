namespace Frontend.Utils.Converters;

using Avalonia;
using Avalonia.Data.Converters;

using System.Globalization;
using System;

public class BoolToThicknessConverter : IValueConverter
{
    public Thickness TrueThickness { get; set; } = new Thickness(3);
    public Thickness FalseThickness { get; set; } = new Thickness(0);


    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b && b ? TrueThickness : FalseThickness;

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
