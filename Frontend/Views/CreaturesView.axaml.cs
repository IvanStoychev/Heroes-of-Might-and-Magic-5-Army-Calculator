namespace Frontend.Views;

using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Controls;

using Database;

using System.Collections.ObjectModel;
using System.Linq;

using Frontend.ViewModels;

public partial class CreaturesView : UserControl
{
    public CreaturesView()
    {
        InitializeComponent();

        var db = new CreatureInfoContext();

        var vms = db.Creatures
            .Select(c => new CreatureViewModel(db, c.ID))
            .ToList();

        CreatureList.Items = new ObservableCollection<CreatureViewModel>(vms);
    }
}