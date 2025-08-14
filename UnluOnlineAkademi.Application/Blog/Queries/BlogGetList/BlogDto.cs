namespace UnluOnlineAkademi.Application.Blog.Queries.BlogGetList
{
    public class BlogDto
    {
        public Guid ID { get; set; }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Author { get; set; }
        public string? CoverImg { get; set; }
        public string? Image { get; set; }
        public DateTime? PublishDate { get; set; }
        public bool? Status { get; set; }
    }
}
