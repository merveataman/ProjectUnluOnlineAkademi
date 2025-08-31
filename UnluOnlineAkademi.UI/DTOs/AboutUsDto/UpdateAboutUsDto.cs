namespace UnluOnlineAkademi.UI.DTOs.AboutUsDto
{
    public class UpdateAboutUsDto
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Image { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
        public IFormFile? ImageFile { get; set; }

    }
}
