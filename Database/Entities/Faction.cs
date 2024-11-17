namespace Database.Entities;

public partial class Faction
{
    public int ID { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Creature> TCreatures { get; set; } = new List<Creature>();
}
