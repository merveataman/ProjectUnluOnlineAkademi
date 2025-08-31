namespace UnluOnlineAkademi.UI.DTOs.WhyUsDto
{
    public class UpdateWhyUsDto
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
