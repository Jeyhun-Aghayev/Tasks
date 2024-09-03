using Microsoft.AspNetCore.Http.HttpResults;

namespace LabTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderItemController : ControllerBase
    {
        string path = "C:\\Users\\ceyhunsa\\Desktop\\Clone\\Tasks\\Lab\\LabTask\\LabTask\\wwwroot\\Upload\\";
        private readonly SliderItemService _sliderItemService;

        public SliderItemController(SliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_sliderItemService.GetAllSliderItems(true));
        }
        [HttpPost]
        public IActionResult Create(SliderItemCreateDto item)
        {
                return NotFound();
           
            SliderItem slider = new SliderItem()
            {

                Offer = item.Offer.Trim(),
                Title = item.Title,
                ImgPath = item.Image.UploadFile(folderName: path)
            };

            return RedirectToAction(nameof(Index));
        }
        [HttpPut]
        public IActionResult Edit(SliderItemUpdateDto item)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View(item);
            }
            if (item.Image is not null)
            {
                if (!item.Image.CheckContent("image/"))
                {
                    throw new Exception("Duzgun format daxil edin");
                }
            }
            SliderItem NewSlider = _sliderItemService.GetSliderItem(item.Id).Result;
            NewSlider.Title = item.Title;
            NewSlider.Offer = item.Offer;
            NewSlider.ShortDescription = item.ShortDescription;
            item.Image is not null ? NewSlider.ImgPath = item.Image.UploadFile(path);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete() => ;
    
    }
}
