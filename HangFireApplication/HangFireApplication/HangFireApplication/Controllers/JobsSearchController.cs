
using MassTransit;
using Shared.Dto.Job;
using System.Net;

namespace HangFireApplication.Controllers;

public class JobsSearchController : Controller
{

    private readonly IBackgroundJobClient _client;
     private readonly IPublishEndpoint _endpoint;
    public JobsSearchController(IBackgroundJobClient client, IPublishEndpoint endpoint)
    {
        _client = client;
        _endpoint = endpoint;
    }

    public IActionResult Index()=> View();
    public IActionResult Search() => View();
    [HttpPost]
    public async Task<IActionResult> Search(JobSearch model)
    {
        if (ModelState.IsValid) 
        {
            if(model.SearchNow)
            {
                _client.Enqueue(()=>SendJob(model));

            }
            else if(!model.SearchNow && model.ScheduleTime is not null && model.ScheduleTime>DateTime.Now)
            {
                _client.Schedule(()=> SendJob(model),model.ScheduleTime.Value);
            }
        }
        return  Json(HttpStatusCode.OK);
    }
    public async Task SendJob(JobSearch model)
    {
        await _endpoint.Publish(model);
    }
}
