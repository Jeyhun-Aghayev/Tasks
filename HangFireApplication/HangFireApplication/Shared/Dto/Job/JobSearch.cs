namespace Shared.Dto.Job;
public class JobSearch
{
    public string[]? KeyWords { get; set; }
    public string[]? Companies { get; set; }
    public bool SearchNow { get; set; }
    public DateTime? ScheduleTime { get; set; }
}
public class JobSearchDto
{

    public string KeyWord { get; set; } = null!;
    public string WebUrl { get; set; } = null!;
}
