namespace UnluOnlineAkademi.UI.DTOs.AchievementsDto
{
    public class UpdateAchievementsDto
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public int? Number { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
    }
}
