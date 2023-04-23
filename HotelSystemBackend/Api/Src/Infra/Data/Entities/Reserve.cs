namespace Api.Src.Infra.Data.Entities
{
    public class Reserve
    {
        public int ReserveId { get; set; }
        public int ReservedDays { get; set; }
        public int GuestReserveId { get; set; }
        public int SuiteReserveId { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Suite? Suite { get; set; }
    }
}
