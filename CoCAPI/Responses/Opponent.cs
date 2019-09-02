namespace CoCAPI.Responses
{
    public class Opponent
    {
        public string Tag { get; set; }
        public string Name { get; set; }
        public IconUrls BadgeUrls { get; set; }
        public int ClanLevel { get; set; }
        public int Stars { get; set; }
        public double DestructionPercentage { get; set; }
    }
}