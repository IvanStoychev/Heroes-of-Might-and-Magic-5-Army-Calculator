namespace Database.Entities;

/// <summary>
/// Represents an in-game creature and it's data.
/// Creatures belong to a specific faction and are categorized by tiers, with Tier 1 being the weakest 
/// and Tier 7 being the strongest. <para/>
/// 
/// The <c>Creature</c> class provides properties to store and update the unique identifier, faction id,
/// tier, base cost, upgrade cost, growth and image data for it's base, upgraded and alternate forms. <para/>
/// 
/// The binary image data stored in <c>ImageBytesBase</c>, <c>ImageBytesUpg</c> and <c>ImageBytesUpgAlt</c> 
/// can be converted to a visual representation using the <c>System.Drawing.Image</c> class. <br/>
/// Note that <c>System.Drawing</c> might require additional dependencies on some platforms. <para/>
/// 
/// <b>Additionally</b>, it includes a <c>Faction</c> entity to which it belongs to.
/// </summary>
public partial class Creature
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// This is a 32-bit signed integer.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the faction the creature belongs to.
    /// This is a 32-bit signed integer.
    /// </summary>
    public int FactionID { get; set; }

    /// <summary>
    /// Gets or sets the raw binary image data for the creature's base form. 
    /// <i>For example, a Peasant.</i><para/>
    /// This can be used to reconstruct the image using libraries such as <c>System.Drawing</c>.
    /// </summary>
    public byte[] ImageBytesBase { get; set; }

    /// <summary>
    /// Gets or sets the raw binary image data for the creature's first upgraded form. 
    /// <i>For example, a Peasant (base form) upgrades to a Militiaman.</i> <para/>
    /// This can be used to reconstruct the image using libraries such as <c>System.Drawing</c>.
    /// </summary>
    public byte[] ImageBytesUpg { get; set; }

    /// <summary>
    /// Gets or sets the raw binary image data for the creature's first alternate upgraded form. <para/>
    /// Alternate upgrades are introduced in the <b>Tribes of the East</b> expansion. 
    /// <i>For example, a Peasant (base form) upgrades to a Brute.</i> <para/>
    /// This can be used to reconstruct the image using libraries such as <c>System.Drawing</c>.
    /// </summary>
    public byte[] ImageBytesUpgAlt { get; set; }
    
    /// <summary>
    /// Gets or sets the tier of the creature, representing its rank and power level within the faction.
    /// Tier 1 creatures are the weakest, while Tier 7 creatures are the strongest.
    /// </summary>
    public uint Tier { get; set; }


    /// <summary>
    /// Gets or sets the gold it costs to recruit the creature in it's base form.
    /// </summary>
    public int GoldCostBase { get; set; }

    /// <summary>
    /// Gets or sets the gold it costs to recruit the creature in it's upgraded form.
    /// </summary>
    public int GoldCostUpg { get; set; }


    /// <summary>
    /// Gets or sets the weekly growth rate of the creature.
    /// The growth rate determines the number of creatures available to recruit each week in the castle.
    /// </summary>
    public int Growth { get; set; }

    /// <summary>
    /// Gets or sets the faction associated with this creature.<para/>
    /// Factions include Haven, Inferno, Necropolis, Sylvan, Academy, Dungeon, and Stronghold (from <b>Tribes of the East</b> expansion).
    /// </summary>
    public virtual Faction Faction { get; set; }
}
