using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class CreatureInfoContext : DbContext
{
    public CreatureInfoContext()
    {
    }

    public CreatureInfoContext(DbContextOptions<CreatureInfoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Creature> TCreatures { get; set; }

    public virtual DbSet<Faction> TFactions { get; set; }

    public virtual DbSet<SystemIcon> TSystemIcons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=HoMM5 ToE creature costs v1.0.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Creature>(entity =>
        {
            entity.ToTable("t_Creatures");

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.FactionID).HasColumnName("FactionID");
            entity.Property(e => e.GoldCostBase).HasColumnName("GoldCost_Base");
            entity.Property(e => e.GoldCostUpg).HasColumnName("GoldCost_Upg");
            entity.Property(e => e.ImageBytesBase)
                .IsRequired()
                .HasColumnName("ImageBytes_Base");
            entity.Property(e => e.ImageBytesUpg)
                .IsRequired()
                .HasColumnName("ImageBytes_Upg");
            entity.Property(e => e.ImageBytesUpgAlt)
                .IsRequired()
                .HasColumnName("ImageBytes_UpgAlt");

            entity.HasOne(d => d.Faction).WithMany(p => p.TCreatures)
                .HasForeignKey(d => d.FactionID)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Faction>(entity =>
        {
            entity.ToTable("t_Factions");

            entity.HasIndex(e => e.Name, "IX_t_Factions_Name").IsUnique();

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.Name).IsRequired();
        });

        modelBuilder.Entity<SystemIcon>(entity =>
        {
            entity.ToTable("t_SystemIcons");

            entity.HasIndex(e => e.ImageBytes, "IX_t_SystemIcons_ImageBytes").IsUnique();

            entity.HasIndex(e => e.Name, "IX_t_SystemIcons_Name").IsUnique();

            entity.Property(e => e.ID).HasColumnName("ID");
            entity.Property(e => e.ImageBytes).IsRequired();
            entity.Property(e => e.Name).IsRequired();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
