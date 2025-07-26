using Database.Entities;

namespace Database.Repositories
{
    public class CalcRepository(CreatureInfoContext dbContext)
    {
        private readonly CreatureInfoContext dbContext = dbContext;

        public ICollection<Faction> GetFactions()
        {
            return [.. dbContext.Factions];
        }

        public ICollection<Creature> GetFactionCreatures(int factionID)
        {
            return [.. dbContext.Creatures.Where(c => c.FactionID == factionID)];
        }
    }
}
