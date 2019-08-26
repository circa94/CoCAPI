
using System.Collections.Generic;

namespace CoCAPI.Responses
{
    public class Player
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public int ExpLevel { get; set; }
        public League League { get; set; }
        public int Trophies { get; set; }
        public int VersusTrophies { get; set; }
        public int AttackWins { get; set; }
        public int DefenseWins { get; set; }
        public ClanShortInfo Clan { get; set; }
        public int BestTrophies { get; set; }
        public int Donations { get; set; }
        public int DonationsReceived { get; set; }
        public int WarStars { get; set; }
        public string Role { get; set; }
        public int TownHallLevel { get; set; }
        public int BuilderHallLevel { get; set; }
        public int BestVersusTrophies { get; set; }
        public int VersusBattleWins { get; set; }
        public LegendStatistics LegendStatistics { get; set; }
        public ICollection<Achievement> Achievements { get; set; }
        public ICollection<Troop> Troops { get; set; }
        public ICollection<Hero> Heroes { get; set; }
        public ICollection<Spell> Spells { get; set; }
    }
}
