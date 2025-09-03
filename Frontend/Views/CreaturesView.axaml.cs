namespace Frontend.Views;

using Avalonia.Controls;

using Database;

using System.Collections.ObjectModel;
using System.Linq;

using Frontend.ViewModels;

/// <summary>
/// View responsible for displaying a collection of creatures.
/// </summary>
public partial class CreaturesView : UserControl
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreaturesView"/> class.  
    /// Loads creature data from the database and sets up the item source for the view.
    /// </summary>
    public CreaturesView()
    {
        InitializeComponent();

        var db = new CreatureInfoContext();

        var viewModels = db.Creatures
            .Select(c => new CreatureViewModel(db, c.ID))
            .ToList();

        CreatureList.ItemsSource = new ObservableCollection<CreatureViewModel>(viewModels);
    }
}