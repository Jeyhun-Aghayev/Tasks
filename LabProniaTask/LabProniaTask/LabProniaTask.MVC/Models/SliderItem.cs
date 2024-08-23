namespace LabProniaTask.MVC.Models
{
    public class SliderItem:BaseEntity
    {
        public string Offer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
    }
    public class SliderItemCreateDto
    {
        public string Offer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile? Image { get; set; }
    }
    public class SliderItemUpdateDto:BaseEntity
    {
        public string Offer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public IFormFile? Image { get; set; }
    }
}
