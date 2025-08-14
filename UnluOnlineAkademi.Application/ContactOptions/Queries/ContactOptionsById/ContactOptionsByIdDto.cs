namespace UnluOnlineAkademi.Application.ContactOptions.Queries.ContactOptionsById
{
    public class ContactOptionsByIdDto
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public bool? Status { get; set; }
    }
}
