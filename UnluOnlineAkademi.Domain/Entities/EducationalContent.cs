namespace UnluOnlineAkademi.Domain.Entities
{
    public class EducationalContent:BaseEntity
    {
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }

    }
}
