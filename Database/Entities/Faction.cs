namespace Database.Entities;

/// <summary>
/// Represents an in-game faction.
/// </summary>
public partial class Faction
{
    /// <summary>
    /// Primary key of this record in the database.
    /// </summary>
    public int ID { get; }

    /// <summary>
    /// The faction name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// A collection of <c>Creature</c> entities that belong to this faction. <para/>
    /// This collection is initialized as an empty list by default.
    /// </summary>
    public virtual ICollection<Creature> Creatures { get; set; } = new List<Creature>();
}
