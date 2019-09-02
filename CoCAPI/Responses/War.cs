namespace CoCAPI.Responses
{
    public class War
    {
        public string Result { get; set; }
        public string EndTime { get; set; }
        public int TeamSize { get; set; }
        public WarClan Clan { get; set; }
        public Opponent Opponent { get; set; }
    }
}
