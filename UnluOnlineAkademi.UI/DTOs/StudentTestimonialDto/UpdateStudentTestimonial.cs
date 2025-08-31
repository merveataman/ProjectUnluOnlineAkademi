namespace UnluOnlineAkademi.UI.DTOs.StudentTestimonialDto
{
    public class UpdateStudentTestimonial
    {
        public Guid ID { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Image { get; set; }
        public string? Education { get; set; }
        public string? Testimonial { get; set; }
        public int? Rate { get; set; }
        public bool Status { get; set; }
    }
}
