namespace Api.Src.Infra.Data.Entities
{
    public class Suite : BaseEntity
    {
        public int SuiteId { get; set; }
        public string SuiteType { get; set; }
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }
    }
}
