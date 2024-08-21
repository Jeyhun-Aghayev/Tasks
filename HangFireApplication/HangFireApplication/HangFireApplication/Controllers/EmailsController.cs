using Hangfire;
using HangFireApplication.Services;
using Refit;

namespace HangFireApplication.Controllers
{
    public class EmailsController : Controller
    {
        public IActionResult Send() => View();
        private readonly IBackgroundJobClient _client;
        public EmailsController(IBackgroundJobClient jobClient)
        {
            _client = jobClient;
        }


        [NonAction]
        public async Task SendEmailAsync(EmailBodyDto request)
        {
            var MailServiceApi = RestService.For<IMailServiceApi>("http://localhost:5020");
            await MailServiceApi.SendEmailAsync(request);
        }
         
        [HttpPost]
        public IActionResult Send(EmailBodyDto email, IFormFile[] attachment)
        {
            email.From = "ceyhunsa@code.edu.az";
            if(attachment != null && attachment.Length > 0)
            {
                email.Attachments = [];
                foreach (var file in attachment)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var filebytes = ms.ToArray();

                        email.Attachments.Add(new AttachmentDto
                        {
                            FileName = file.FileName,
                            FileContent = filebytes
                        });
                    }
                }
            }
            if (email.SendNow)
            {
                _client.Enqueue(() => SendEmailAsync(email));
            }
            else
            {
                var timeoutSendDto = email.ScheduleTime.Value - DateTime.Now;
                _client.Schedule(() => SendEmailAsync(email), timeoutSendDto);
            }

            return View();
        }
    }
}
 