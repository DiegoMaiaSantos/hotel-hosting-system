namespace Api.Src.Infra.Data.Entities
{
    public class Suite
    {
        public int SuiteId { get; set; }
        public string? SuiteType { get; set; }
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }
        public int PersonSuiteId { get; set; }
        public virtual Person? Person { get; set; }
        public virtual Reserve? Reserve { get; set; }
    }
}
