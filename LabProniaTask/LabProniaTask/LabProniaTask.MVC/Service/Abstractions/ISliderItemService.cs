namespace LabProniaTask.MVC.Service.Abstractions;

public interface ISliderItemService
{
    List<SliderItem> GetAllSliderItems(bool isTracking);
}
