namespace UnluOnlineAkademi.UI.DTOs.HomeContactDto
{
    public class CreateHomeContactDto
    {
        public Guid ID { get; set; }
        public string? Topic { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Message { get; set; }
        public string? EmailAddress { get; set; }
        public string? Answer { get; set; }
    }
}
