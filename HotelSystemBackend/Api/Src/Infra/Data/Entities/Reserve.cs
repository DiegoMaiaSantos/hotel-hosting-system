namespace Api.Src.Infra.Data.Entities
{
    public class Reserve : BaseEntity
    {
        public int ReserveId { get; set; }
        public int ServiceOrderId { get; set; }
    }
}
