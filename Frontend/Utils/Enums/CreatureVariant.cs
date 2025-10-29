namespace Frontend.Utils.Enums;

/// <summary>
/// Represents the available variants of a creature.
/// Used to determine which portrait, stats, and cost to display.
/// </summary>
public enum CreatureVariant
{
    /// <summary>
    /// The base (unupgraded) creature.
    /// </summary>
    Base,

    /// <summary>
    /// The upgraded form of the creature.
    /// </summary>
    Upgraded,

    /// <summary>
    /// The alternate upgraded form of the creature.
    /// Some creatures have an alternative upgrade path.
    /// </summary>
    Alternate
}
