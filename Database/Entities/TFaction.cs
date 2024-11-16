namespace Database.Entities;

public partial class TFaction
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<TCreature> TCreatures { get; set; } = new List<TCreature>();
}
