using FluentValidation;

namespace LabTask.Entities.Dtos
{
    public class SlidetItemGetDto
    {
        public int Id { get; set; }
        public int Offer { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImgPath { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
    public class SliderItemCreateDto
    {
        public int Id { get; set; }
        public string Offer { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
    public class SliderItemCreateDtoValidator : AbstractValidator<SliderItemCreateDto>
    {
        public SliderItemCreateDtoValidator()
        {
            RuleFor(x => x.Offer)
                .NotEmpty().WithMessage("Offer is required.")
                .Length(1, 50).WithMessage("Offer length must be between 1 and 50 characters.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 100).WithMessage("Title length must be between 1 and 100 characters.");

            RuleFor(x => x.ShortDescription)
                .MaximumLength(500).WithMessage("Short description length cannot exceed 500 characters.");

            RuleFor(x => x.Image)
                .Must(file => file == null || (file.Length > 0 && file.ContentType.StartsWith("image/")))
                .WithMessage("Invalid image file.");
        }
    }
    public class SliderItemUpdateDto : BaseEntity
    {
        public int Id { get; set; }
        public string Offer { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string ImgPath { get; set; }
        public IFormFile? Image { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime DeletedDate { get; set; }
    }
    public class SliderItemUpdateDtoValidator : AbstractValidator<SliderItemUpdateDto>
    {
        public SliderItemUpdateDtoValidator()
        {
            RuleFor(x => x.Offer)
                .NotEmpty().WithMessage("Offer is required.")
                .Length(1, 50).WithMessage("Offer length must be between 1 and 50 characters.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 100).WithMessage("Title length must be between 1 and 100 characters.");

            RuleFor(x => x.ShortDescription)
                .MaximumLength(500).WithMessage("Short description length cannot exceed 500 characters.");

            RuleFor(x => x.ImgPath)
                .MaximumLength(255).WithMessage("Image path length cannot exceed 255 characters.");

            RuleFor(x => x.Image)
                .Must(file => file == null || (file.Length > 0 && file.ContentType.StartsWith("image/")))
                .WithMessage("Invalid image file.");
        }
    }
}
