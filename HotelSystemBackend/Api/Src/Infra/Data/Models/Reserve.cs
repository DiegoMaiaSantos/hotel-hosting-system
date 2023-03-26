namespace Api.Src.Infra.Data.Models
{
    public class Reserve
    {
        public List<Person> Guests { get; set; }
        public Suite Suite { get; set; }
        public int ReservedDays { get; set; }
    }
}
