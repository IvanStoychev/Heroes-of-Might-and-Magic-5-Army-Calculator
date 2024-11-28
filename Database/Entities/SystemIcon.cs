namespace Database.Entities;

/// <summary>
/// Represents an icon that be used in UI elements.
/// </summary>
public partial class SystemIcon
{
    /// <summary>
    /// Primary key of this record in the database.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// The icon name. 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Byte representation of the image.
    /// </summary>
    public byte[] ImageBytes { get; set; }
}
