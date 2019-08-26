using System.Collections.Generic;

namespace CoCAPI.Responses
{
    public class Clan
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public IconUrls BadgeUrls { get; set; }
        public int ClanLevel { get; set; }
        public int ClanPoints { get; set; }
        public int ClanVersusPoints { get; set; }
        public int RequiredTrophies { get; set; }
        public string WarFrequency { get; set; }
        public int WarWinStreak { get; set; }
        public int WarWins { get; set; }
        public int WarTies { get; set; }
        public int WarLosses { get; set; }
        public bool IsWarLogPublic { get; set; }
        public int Members { get; set; }
        public ICollection<MemberList> MemberList { get; set; }
    }
}