namespace Api.Src.Infra.Data.Entities
{
    public class ServiceOrder : BaseEntity
    {
        public int ServiceOrderId { get; set; }
        public int SuiteId { get; set; }
        public int TotalDays { get; set; }
        public string ExtraCleaning { get; set; }
        public int EmployeeId { get; set; }
        public decimal ValueTotal { get; set; }
    }
}
