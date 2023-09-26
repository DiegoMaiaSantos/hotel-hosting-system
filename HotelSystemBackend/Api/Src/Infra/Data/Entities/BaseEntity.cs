namespace Api.Src.Infra.Data.Entities
{
    public class BaseEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public int CreateUser { get; set; }
        public int UpdateUser { get; set; }
    }
}
