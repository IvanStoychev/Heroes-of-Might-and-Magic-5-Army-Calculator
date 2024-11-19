namespace Database.Entities;

/// <summary>
/// Represents an icon that can be used in UI elements <para/>
/// 
/// The <c>SystemIcon</c> class provides properties to store and update an icon's unique identifier, 
/// name, and image data. <para/>
/// 
/// The binary image data stored in <c>ImageBytes</c> can be converted to a visual 
/// representation using the <c>System.Drawing.Image</c> class. <br/>
/// Note that <c>System.Drawing</c> might require additional dependencies on some platforms.
/// </summary>
public partial class SystemIcon
{
    /// <summary>
    /// Gets or sets the unique identifier. 
    /// This is a 32-bit signed integer.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the icon name. 
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a byte array of the raw binary data of the icon. <para/>
    /// This can be used to reconstruct the image using libraries such as <c>System.Drawing</c>.
    /// </summary>
    public byte[] ImageBytes { get; set; }
}
