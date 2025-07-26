namespace Database.Entities;

/// <summary>
/// Represents an in-game creature.
/// </summary>
public partial class Creature
{
    /// <summary>
    /// Unique identifier for the creature.
    /// </summary>
    public int ID { get; }

    /// <summary>
    /// ID of the faction the creature belongs to.
    /// </summary>
    public int FactionID { get; set; }

    /// <summary>
    /// Byte representation of the image for the base creature.
    /// </summary>
    public byte[] ImageBytesBase { get; set; }

    /// <summary>
    /// Byte representation of the image for the creature with an upgrade.
    /// </summary>
    public byte[] ImageBytesUpg { get; set; }

    /// <summary>
    /// Byte representation of the image for the creature with an alternative upgrade.
    /// </summary>
    public byte[] ImageBytesUpgAlt { get; set; }
    
    /// <summary>
    /// An integer representation of the creature tier.
    /// </summary>
    public int Tier { get; set; }

    /// <summary>
    /// Amount of gold it takes to recruit a single base creature of this type.
    /// </summary>
    public int GoldCostBase { get; set; }

    /// <summary>
    /// Amount of gold it takes to recruit a single upgraded creature of this type.
    /// </summary>
    public int GoldCostUpg { get; set; }

    /// <summary>
    /// Amount of creatures available for recruitment each week.
    /// </summary>
    public int Growth { get; set; }

    /// <summary>
    /// The <c>Faction</c> the creature belongs to.
    /// </summary>
    public virtual Faction Faction { get; set; }
}
