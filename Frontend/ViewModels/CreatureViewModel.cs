using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Database;
using Database.Mocks;
using Frontend.Utils.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace Frontend.ViewModels;

public class CreatureViewModel : ViewModelBase
{
    private readonly CreatureInfoContext dbContext;
    private readonly Creature _creature;

    private CreatureVariant _selectedVariant = CreatureVariant.Base;
    private int _creatureCount;

    public IRelayCommand<CreatureVariant> SelectVariantCommand { get; }

    public bool IsBaseSelected => SelectedVariant == CreatureVariant.Base;
    public bool IsUpgSelected => SelectedVariant == CreatureVariant.Upgraded;
    public bool IsAltSelected => SelectedVariant == CreatureVariant.Alternate;

    public Bitmap BasePortrait { get; }
    public Bitmap UpgradedPortrait { get; }
    public Bitmap AlternateUpgradedPortrait { get; }
    public Bitmap GoldIcon { get; }
    public Bitmap GrowthIcon { get; }
    public Bitmap SelectedPortrait
    {
        get
        {
            return SelectedVariant switch
            {
                CreatureVariant.Base => BasePortrait,
                CreatureVariant.Upgraded => UpgradedPortrait,
                CreatureVariant.Alternate => AlternateUpgradedPortrait,
                _ => BasePortrait
            };
        }
    }

    public CreatureVariant SelectedVariant
    {
        get => _selectedVariant;
        set
        {
            if (_selectedVariant != value)
            {
                _selectedVariant = value;
                OnPropertyChanged(nameof(SelectedVariant));
                OnPropertyChanged(nameof(SelectedPortrait));
                OnPropertyChanged(nameof(GoldPerUnit));
                OnPropertyChanged(nameof(TotalGoldCost));
                OnPropertyChanged(nameof(IsBaseSelected));
                OnPropertyChanged(nameof(IsUpgSelected));
                OnPropertyChanged(nameof(IsAltSelected));
            }
        }
    }

    public int CreatureCount
    {
        get => _creatureCount;
        set
        {
            if (_creatureCount != value)
            {
                _creatureCount = value;
                OnPropertyChanged(nameof(CreatureCount));
                OnPropertyChanged(nameof(TotalGoldCost));
                OnPropertyChanged(nameof(RequiredWeeks));
            }
        }
    }

    public int GoldPerUnit =>
        SelectedVariant switch
        {
            CreatureVariant.Base => _creature.GoldCostBase,
            CreatureVariant.Upgraded => _creature.GoldCostUpg,
            CreatureVariant.Alternate => _creature.GoldCostUpg,
            _ => _creature.GoldCostBase
        };

    public int WeeklyGrowth { get; }

    public int TotalGoldCost => CreatureCount * GoldPerUnit;
    public int RequiredWeeks => WeeklyGrowth == 0 ? 0 : (int)Math.Ceiling((double)CreatureCount / WeeklyGrowth);

    public CreatureViewModel(CreatureInfoContext context, int creatureId)
    {
        dbContext = context;

        _creature = dbContext.Creatures
            .Include(c => c.Faction)
            .FirstOrDefault(c => c.ID == creatureId);

        if (_creature == null)
            return;

        BasePortrait = ConvertToBitmap(_creature.ImageBytesBase);
        UpgradedPortrait = ConvertToBitmap(_creature.ImageBytesUpg);
        AlternateUpgradedPortrait = ConvertToBitmap(_creature.ImageBytesUpgAlt);

        WeeklyGrowth = _creature.Growth;

        GoldIcon = GetSystemIcon("gold");
        GrowthIcon = GetSystemIcon("growth");

        SelectVariantCommand = new RelayCommand<CreatureVariant>(v =>
        {
            SelectedVariant = v;   
        });
    }

    private Bitmap ConvertToBitmap(byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return new Bitmap(ms);
    }

    private Bitmap GetSystemIcon(string iconName)
    {
        var icon = dbContext.SystemIcons.FirstOrDefault(i => i.Name.ToLower() == iconName.ToLower());
        return icon != null ? ConvertToBitmap(icon.ImageBytes) : null;
    }
}
