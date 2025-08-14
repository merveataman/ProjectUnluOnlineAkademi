namespace UnluOnlineAkademi.UI.DTOs.PoliciesDto
{
    public class PoliciesByIdDto
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public bool? Status { get; set; }
    }
}
