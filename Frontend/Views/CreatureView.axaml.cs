namespace Frontend.Views;

using System.Collections.ObjectModel;
using System.Linq;

using Avalonia.Controls;

using Database;

using Frontend.ViewModels;

public partial class CreatureView : UserControl
{
    public ObservableCollection<CreatureViewModel> Creatures { get; }

    private readonly CreatureInfoContext _db;

    public CreatureView()
    {
        InitializeComponent();

        _db = new CreatureInfoContext();

        // create a CreatureViewModel for each creature row
        var vms = _db.Creatures
            .Select(c => new CreatureViewModel(_db, c.ID))
            .ToList();

        Creatures = new ObservableCollection<CreatureViewModel>(vms);
    }
}