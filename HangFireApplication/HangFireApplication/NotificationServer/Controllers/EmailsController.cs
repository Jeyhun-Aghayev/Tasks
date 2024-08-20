using Microsoft.AspNetCore.Mvc;
using NotificationServer.Services;
using Shared.Dto.Email;

namespace NotificationServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmailsController : ControllerBase
{
    private readonly IMailService _mailService;

    public EmailsController(IMailService mailService)
    {
        _mailService = mailService;
    }

    [HttpPost]
    public async Task<IActionResult> SendMail([FromBody] EmailBodyDto request)
    {
        try
        {
            await _mailService.SendEmailAsync(request);
            return Ok();
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
    }

}
