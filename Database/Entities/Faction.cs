namespace Database.Entities;


/// <summary>
/// Represents an in-game faction to which creatures can belong. <para/>
/// 
/// The <c>Faction</c> class provides properties to store and update the unique identifier 
/// and name of a faction. <para/>
/// 
/// <b>Additionally</b>, it includes a collection of associated <c>Creature</c> entities that 
/// belong to this faction.
/// </summary>
public partial class Faction
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// This is a 32-bit signed integer.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the faction name.
    /// </summary>
    public string Name { get; set; }


    /// <summary>
    /// Gets or sets a collection of <c>Creature</c> entities that belong to this faction. <para/>
    /// This collection is initialized as an empty list by default.
    /// </summary>
    public virtual ICollection<Creature> Creatures { get; set; } = new List<Creature>();
}
