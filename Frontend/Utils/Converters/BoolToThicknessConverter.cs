namespace Frontend.Utils.Converters;

using Avalonia;
using Avalonia.Data.Converters;

using System.Globalization;
using System;

/// <summary>
/// Converts a boolean value into an Avalonia <see cref="Thickness"/>.
/// Used primarily for conditional borders (e.g., highlighting a selected portrait).
/// </summary>
public class BoolToThicknessConverter : IValueConverter
{
    /// <summary>
    /// The <see cref="Thickness"/> value to return when the bound boolean is true.
    /// Default is a border thickness of 3.
    /// </summary>
    public Thickness TrueThickness { get; set; } = new Thickness(3);

    /// <summary>
    /// The <see cref="Thickness"/> value to return when the bound boolean is false.
    /// Default is no border (<c>0</c>).
    /// </summary>
    public Thickness FalseThickness { get; set; } = new Thickness(0);

    /// <summary>
    /// Converts a <see cref="bool"/> to either <see cref="TrueThickness"/> or <see cref="FalseThickness"/>.
    /// </summary>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        => value is bool b && b ? TrueThickness : FalseThickness;

    /// <summary>
    /// Conversion back is not supported and will throw a <see cref="NotSupportedException"/>.
    /// </summary>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
