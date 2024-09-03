using LabProniaTask.MVC.Areas.Helper;
using LabProniaTask.MVC.Service.Concretes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace LabProniaTask.MVC.Areas.Manage.Controllers
{
    public class SliderController : Controller
    {
        string path = "C:\\Users\\ceyhunsa\\Desktop\\Clone\\Tasks\\LabProniaTask\\LabProniaTask\\LabProniaTask.MVC\\wwwroot\\Upload\\";
        private readonly SliderItemService _sliderItemService;

        public SliderController(SliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }

        public IActionResult Index()
        {
            
            return View(_sliderItemService.GetAllSliderItems(true));
        }
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(SliderItemCreateDto item)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View(item);
            }
            if (!item.Image.CheckContent("image/"))
            {
                throw new Exception("Duzgun format daxil edin");
            }
            
            SliderItem slider = new SliderItem()
            {

                Offer = item.Offer.Trim(),
                Title = item.Title,
                Description = item.Description,
                ImgPath = item.Image.UploadFile(folderName:path)
            };

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit() => View();
        [HttpPost]
        public IActionResult Edit(SliderItemUpdateDto item)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "");
                return View(item);
            }
            if(item.Image is not null)
            {
                if (!item.Image.CheckContent("image/"))
                {
                    throw new Exception("Duzgun format daxil edin");
                }
            }
            SliderItem NewSlider = _sliderItemService.GetSliderItem(item.Id).Result;
            NewSlider.Title = item.Title;
            NewSlider.Offer = item.Offer;
            NewSlider.Description = item.Description;
            item.Image is not null ? NewSlider.ImgPath = item.Image.UploadFile(path);
        }

        public IActionResult Delete() => View();
    }
}
