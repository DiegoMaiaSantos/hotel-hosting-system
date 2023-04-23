namespace Api.Src.Infra.Data.Entities
{
    public class Person
    {
        public int GuestId { get; set; }
        public string? Name { get; set; }
        public string? CPF { get; set; }
        public int? HostedSuiteId { get; set; }
        public virtual Suite? Suite { get; set; }
        public virtual Reserve? Reserve { get; set; }
    }
}
