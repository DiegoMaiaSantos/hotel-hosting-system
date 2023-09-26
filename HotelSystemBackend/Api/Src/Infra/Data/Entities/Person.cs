namespace Api.Src.Infra.Data.Entities
{
    public class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ReserveId { get; set; }
    }
}
