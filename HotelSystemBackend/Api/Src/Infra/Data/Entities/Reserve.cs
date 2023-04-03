namespace Api.Src.Infra.Data.Entities
{
    public class Reserve
    {
        public int IdReserve { get; set; }
        public int ReservedDays { get; set; }
        public int IdGuestReserve { get; set; }
        public int IdSuiteReserve { get; set; }
        public Person Person { get; set; }
        public Suite Suite { get; set; }
    }
}
