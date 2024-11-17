namespace Database.Entities;

public partial class Creature
{
    public int ID { get; set; }

    public int FactionID { get; set; }

    public byte[] ImageBytesBase { get; set; }

    public byte[] ImageBytesUpg { get; set; }

    public byte[] ImageBytesUpgAlt { get; set; }

    public int Tier { get; set; }

    public int GoldCostBase { get; set; }

    public int GoldCostUpg { get; set; }

    public int Growth { get; set; }

    public virtual Faction Faction { get; set; }
}
