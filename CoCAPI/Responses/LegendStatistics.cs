namespace CoCAPI.Responses
{
    public class LegendStatistics
    {
        public int LegendTrophies { get; set; }
        public Season CurrentSeason { get; set; }
        public Season PreviousSeason { get; set; }
        public Season BestSeason { get; set; }
    }
}