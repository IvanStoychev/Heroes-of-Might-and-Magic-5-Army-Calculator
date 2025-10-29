using System.ComponentModel;

namespace Frontend.ViewModels;

/// <summary>
/// Base class for all view models, implements INotifyPropertyChanged to support data binding.
/// </summary>
public class ViewModelBase : INotifyPropertyChanged
{
    /// <summary>
    /// Raised when a property value changes, allowing the UI to update automatically.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged;

    /// <summary>
    /// Helper method to raise the PropertyChanged event for a given property name.
    /// </summary>
    /// <param name="propertyName"></param>
    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
