namespace UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentById
{
    public class EducationalContentByIdDto
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
