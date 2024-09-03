namespace LabTask.Entities.Base
{
    public class BaseAuditable :BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
