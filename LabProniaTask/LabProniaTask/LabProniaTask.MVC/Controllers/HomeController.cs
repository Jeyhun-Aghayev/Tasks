using LabProniaTask.MVC.Models;
using LabProniaTask.MVC.Service.Abstractions;
using LabProniaTask.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LabProniaTask.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderItemService _sliderItemService;

        public HomeController(ISliderItemService sliderItemService)
        {
            _sliderItemService = sliderItemService;
        }

        public IActionResult Index()
        {
            IndexVM vm = new IndexVM()
            {
                sliderItems = _sliderItemService.GetAllSliderItems(true)
            };
            
            return View(vm);
        }

    }
}
