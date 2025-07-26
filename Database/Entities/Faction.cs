namespace Database.Entities;

/// <summary>
/// Represents an in-game faction.
/// </summary>
public partial class Faction
{
    /// <summary>
    /// Unique identifier for the faction.
    /// </summary>
    public int ID { get; }

    /// <summary>
    /// Unique string used to represent the faction.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Every <c>Creature</c> that belongs to the faction.
    /// <para/> This collection is initialized as an empty list by default.
    /// </summary>
    public virtual ICollection<Creature> Creatures { get; set; } = [];
}
