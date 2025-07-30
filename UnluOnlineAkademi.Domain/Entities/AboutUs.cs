namespace UnluOnlineAkademi.Domain.Entities
{
    public class AboutUs:BaseEntity
    {
        //public Guid ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string? Image { get; set; }
        public bool? Status { get; set; }
        public DateTime? Date { get; set; }
        //public bool? ISDeleted { get; set; }

    }
}
