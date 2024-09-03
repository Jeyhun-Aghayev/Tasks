namespace LabTask.Entities
{
    public class SliderItem : BaseAuditable
    {
        public int Id { get; set; }
        public string Offer { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImgPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
