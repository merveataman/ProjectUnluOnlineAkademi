namespace UnluOnlineAkademi.Domain.Entities
{
    public class Achievements:BaseEntity
    {
        public string? Title { get; set; }
        public int? Number { get; set; }
        public string? Icon { get; set; }
        public bool? Status { get; set; }

    }
}
