using Database.Entities;

namespace Database.Repositories
{
    internal class CalcRepository(CreatureInfoContext dbContext)
    {
        private readonly CreatureInfoContext dbContext = dbContext;

        public ICollection<Faction> GetFactions()
        {
            return [.. dbContext.Factions];
        }

        public ICollection<Creature> GetFactionCreatures(int factionID)
        {
            // TODO: Maybe handle if the faction doesn't exist.
            return [.. dbContext.Creatures.Where(c => c.FactionID == factionID)];
        }
    }
}
