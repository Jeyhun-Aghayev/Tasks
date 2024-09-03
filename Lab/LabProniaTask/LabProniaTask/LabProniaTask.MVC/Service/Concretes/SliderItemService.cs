using LabProniaTask.MVC.Service.Abstractions;

namespace LabProniaTask.MVC.Service.Concretes;

public class SliderItemService : ISliderItemService
{
    private readonly IReadRepository<SliderItem> _readRepository;
    private readonly IWriteRepository<SliderItem> _writeRepository;

    public SliderItemService(IReadRepository<SliderItem> readRepository, IWriteRepository<SliderItem> writeRepository)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
    }

    public async Task Create(SliderItem item)
    { 
        await  _writeRepository.Add(item);
    }

    public async Task Delete(int id)
    {
        await _writeRepository.Delete(id);
    }

    public List<SliderItem> GetAllSliderItems(bool isTracking)
    {
       return _readRepository.GetAll(isTracking).ToList();
    }

    public async Task<SliderItem> GetSliderItem(int id)
    {
        return await _readRepository.GetById(id);
    }

    public async Task Update(SliderItem item)
    {
        await _writeRepository.Update(item);
    }
}
