namespace Api.Src.Infra.Data.Models
{
    public class Suite : Reserve
    {
        public string SuiteType { get; set; }
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }
    }
}
