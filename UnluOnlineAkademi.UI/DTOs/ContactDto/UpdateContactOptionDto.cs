namespace UnluOnlineAkademi.UI.DTOs.ContactDto
{
    public class UpdateContactOptionDto
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
