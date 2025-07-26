namespace Database.Entities;

/// <summary>
/// Represents an icon that be used in UI elements.
/// </summary>
public partial class SystemIcon
{
    /// <summary>
    /// Unique identifier for the system icon.
    /// </summary>
    public int ID { get; }

    /// <summary>
    /// Unique string used to represent the system icon.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Byte representation of the image for the system icon.
    /// </summary>
    public byte[] ImageBytes { get; set; }
}
