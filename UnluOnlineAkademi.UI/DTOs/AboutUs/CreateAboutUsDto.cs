namespace UnluOnlineAkademi.UI.DTOs.AboutUs
{
    public class CreateAboutUsDto
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Image { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
    }
}
