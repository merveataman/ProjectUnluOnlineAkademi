namespace UnluOnlineAkademi.Application.CourseLessons.Queries.CourseLessonsById
{
    public class CourseLessonsByIdDto
    {
        public Guid ID { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Icon { get; set; }
        public string? BackgroundHexColor { get; set; }
        public bool? Status { get; set; }
    }
}
