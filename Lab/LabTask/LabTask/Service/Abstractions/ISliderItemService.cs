namespace LabTask.Service.Abstractions;

public interface ISliderItemService
{
    List<SliderItem> GetAllSliderItems(bool isTracking);
    Task<SliderItem> GetSliderItem(int id);
    Task Delete(int id);
    Task Update(SliderItem item);
    Task Create(SliderItem item);
}
