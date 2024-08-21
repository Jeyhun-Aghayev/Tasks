using LabProniaTask.MVC.Service.Abstractions;

namespace LabProniaTask.MVC.Service.Concretes;

public class SliderItemService : ISliderItemService
{
    private readonly IReadRepository<SliderItem> _readRepository;

    public SliderItemService(IReadRepository<SliderItem> readRepository)
    {
        _readRepository = readRepository;
    }

    public List<SliderItem> GetAllSliderItems(bool isTracking)
    {
       return _readRepository.GetAll(isTracking).ToList();
    }
}
