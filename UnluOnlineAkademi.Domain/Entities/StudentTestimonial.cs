namespace UnluOnlineAkademi.Domain.Entities
{
    public class StudentTestimonial:BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Image { get; set; }
        public string? Education { get; set; }
        public string? Testimonial { get; set; }
        public int? Rate { get; set; }
        public bool? Status { get; set; }

    }
}
