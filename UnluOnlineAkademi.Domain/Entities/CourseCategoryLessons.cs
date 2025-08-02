namespace UnluOnlineAkademi.Domain.Entities
{
    public class CourseCategoryLessons:BaseEntity
    {
        public Guid CourseLessonID { get; set; }
        public Guid CourseCategoryID { get; set; }

    }
}
