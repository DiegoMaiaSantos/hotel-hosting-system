namespace Api.Src.Infra.Data.Entities
{
    public class Person : Reserve
    {
        public int IdGuest { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public int IdHostedSuite { get; set; }
        public Suite Suite { get; set; }
        public Reserve Reserve { get; set; }
    }
}
