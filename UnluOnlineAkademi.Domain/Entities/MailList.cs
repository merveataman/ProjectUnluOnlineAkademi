namespace UnluOnlineAkademi.Domain.Entities
{
    public class MailList:BaseEntity
    {
        public string? Topic { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Message { get; set; }
        public string? EmailAddress { get; set; }
        public string? Answer { get; set; }
        public bool? Status { get; set; }

    }
}
