namespace Database.Entities;

public partial class SystemIcon
{
    public int ID { get; set; }

    public string Name { get; set; }

    public byte[] ImageBytes { get; set; }
}
