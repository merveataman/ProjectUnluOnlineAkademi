namespace UnluOnlineAkademi.UI.DTOs.HomeHeaderDto
{
    public class HomeHeaderDto
    {
        public Guid ID { get; set; }
        public string Slogan { get; set; }
        public string Desc { get; set; }
        public string? CoverImage { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
