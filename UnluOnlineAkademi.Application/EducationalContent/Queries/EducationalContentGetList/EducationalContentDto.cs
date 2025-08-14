namespace UnluOnlineAkademi.Application.EducationalContent.Queries.EducationalContentGetList
{
    public class EducationalContentDto
    {
        public Guid ID { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }
    }
}
