namespace Database.Entities;

/// <summary>
/// Represents an in-game creature.
/// </summary>
public partial class Creature
{
    /// <summary>
    /// Primary key of this record in the database.
    /// </summary>
    public int ID { get; }

    /// <summary>
    /// Foreign key of the faction the creature belongs to.
    /// </summary>
    public int FactionID { get; set; }

    /// <summary>
    /// Byte representation of the image of the creature.
    /// </summary>
    public byte[] ImageBytesBase { get; set; }

    /// <summary>
    /// Byte representation of the image of the creature's upgrade. 
    /// </summary>
    public byte[] ImageBytesUpg { get; set; }

    /// <summary>
    /// Byte representation of the image of the creature's alternative upgrade.
    /// </summary>
    public byte[] ImageBytesUpgAlt { get; set; }
    
    /// <summary>
    /// The in-game tier of the creature. 
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
    /// A <c>Faction</c> entity the creature belongs to.
    /// </summary>
    public virtual Faction Faction { get; set; }
}
