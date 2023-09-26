namespace Api.Src.Infra.Data.Entities
{
    public class Employee : BaseEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string PositionEmployee { get; set; }
        public DateTime Admission { get; set; }
        public decimal ValueTotal { get; set; }
    }
}
