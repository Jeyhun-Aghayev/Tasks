namespace Shared.Dto.Email;

public class EmailBodyDto
{
    public string To { get; set; } = null!;
    public string From { get; set; } = null!;
    public string? Bcc { get; set; } //gizli tanik
    public string? Cc { get; set; }
    public string Subject { get; set; } = null!;
    public string? Body { get; set; }
    public bool SendNow { get; set; } = false;
    public DateTime? ScheduleTime { get; set; }
    public ICollection<AttachmentDto> Attachments { get; set; } = new List<AttachmentDto>();

}
public class AttachmentDto
{
    public string FileName { get; set; } = string.Empty;
    public byte[] FileContent { get; set; } = Array.Empty<byte>();
}
