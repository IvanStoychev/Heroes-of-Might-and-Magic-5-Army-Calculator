using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.Input;
using Database;
using Database.Mocks;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using Frontend.Utils.Enums;

namespace Frontend.ViewModels;

public class CreatureViewModel : ViewModelBase
{
    private readonly CreatureInfoContext dbContext;
    private readonly Creature _creature;

    private CreatureVariant _selectedVariant = CreatureVariant.Base;
    private int _creatureCount;

    /// <summary>
    /// Command that sets the selected creature variant when a portrait is clicked.
    /// </summary>
    public IRelayCommand<CreatureVariant> SelectVariantCommand { get; }

    /// <summary>
    /// When the Base variant is currently selected (True).
    /// </summary>
    public bool IsBaseSelected => SelectedVariant == CreatureVariant.Base;

    /// <summary>
    /// When the Upgraded variant is currently selected (True).
    /// </summary>
    public bool IsUpgSelected => SelectedVariant == CreatureVariant.Upgraded;

    /// <summary>
    /// When the Alternate variant is currently selected (True).
    /// </summary>
    public bool IsAltSelected => SelectedVariant == CreatureVariant.Alternate;

    /// <summary>
    /// Bitmap of the base creature portrait.
    /// </summary>
    public Bitmap BasePortrait { get; }

    /// <summary>
    /// Bitmap of the upgraded creature portrait.
    /// </summary>
    public Bitmap UpgradedPortrait { get; }

    /// <summary>
    /// Bitmap of the alternate upgraded creature portrait.
    /// </summary>
    public Bitmap AlternateUpgradedPortrait { get; }

    /// <summary>
    /// Bitmap used for the gold icon in the UI.
    /// </summary>
    public Bitmap GoldIcon { get; }

    /// <summary>
    /// Bitmap used for the weekly growth icon in the UI.
    /// </summary>
    public Bitmap GrowthIcon { get; }

    /// <summary>
    /// Returns the portrait that matches the currently selected variant.
    /// </summary>
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

    /// <summary>
    /// The variant (Base/Upgraded/Alternate) currently selected; changing it updates related UI properties.
    /// </summary>
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

    /// <summary>
    /// The number of creatures; changes recompute total cost and required weeks.
    /// </summary>
    public int CreatureCount
    {
        get => _creatureCount;
        private set
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

    /// <summary>
    /// Nullable numeric input bridge for NumericUpDown; coerces to a non-negative integer into CreatureCount.
    /// </summary>
    public double? CreatureCountInput
    {
        get => CreatureCount; 
        set
        {
            var v = 0;
            if (value.HasValue && !double.IsNaN(value.Value))
                v = (int)Math.Max(0, Math.Round(value.Value));

            CreatureCount = v;
        }
    }

    /// <summary>
    /// Gold cost per single creature for the currently selected variant.
    /// </summary>
    public int GoldPerUnit =>
        SelectedVariant switch
        {
            CreatureVariant.Base => _creature.GoldCostBase,
            CreatureVariant.Upgraded => _creature.GoldCostUpg,
            CreatureVariant.Alternate => _creature.GoldCostUpg,
            _ => _creature.GoldCostBase
        };

    /// <summary>
    /// Number of creatures produced per week.
    /// </summary>
    public int WeeklyGrowth { get; }

    /// <summary>
    /// Computed total gold cost.
    /// </summary>
    public int TotalGoldCost => CreatureCount * GoldPerUnit;

    /// <summary>
    /// Computed weeks needed to recruit creatures.
    /// </summary>
    public int RequiredWeeks => WeeklyGrowth == 0 ? 0 : (int)Math.Ceiling((double)CreatureCount / WeeklyGrowth);

    /// <summary>
    /// Loads the creature, initializes portraits/icons, sets up the select-variant command.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="creatureId"></param>
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

    /// <summary>
    /// Creates a Bitmap from raw image bytes.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    private Bitmap ConvertToBitmap(byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return new Bitmap(ms);
    }

    /// <summary>
    /// Retrieves a system icon by name from the DB and returns it as a Bitmap.
    /// </summary>
    /// <param name="iconName"></param>
    /// <returns></returns>
    private Bitmap GetSystemIcon(string iconName)
    {
        var icon = dbContext.SystemIcons.FirstOrDefault(i => i.Name.ToLower() == iconName.ToLower());
        return icon != null ? ConvertToBitmap(icon.ImageBytes) : null;
    }
}
