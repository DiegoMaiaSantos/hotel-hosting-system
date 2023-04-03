namespace Api.Src.Infra.Data.Entities
{
    public class Suite : Reserve
    {
        public int IdSuite { get; set; }
        public string SuiteType { get; set; }
        public int Capacity { get; set; }
        public decimal DailyValue { get; set; }
        public int IdPersonSuite { get; set; }
        public Person Person { get; set; }
        public Reserve Reserve { get; set; }
    }
}
