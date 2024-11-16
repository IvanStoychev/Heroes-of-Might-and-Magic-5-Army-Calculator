namespace Database.Entities;

public partial class TCreature
{
    public int Id { get; set; }

    public int FactionId { get; set; }

    public byte[] ImageBytesBase { get; set; }

    public byte[] ImageBytesUpg { get; set; }

    public byte[] ImageBytesUpgAlt { get; set; }

    public int Tier { get; set; }

    public int GoldCostBase { get; set; }

    public int GoldCostUpg { get; set; }

    public int Growth { get; set; }

    public virtual TFaction Faction { get; set; }
}
