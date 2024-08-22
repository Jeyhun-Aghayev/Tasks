namespace HangFireApplication.Services
{
    public interface IMailServiceApi
    { 
        [Post("/api/emails")]
        Task SendEmailAsync([Body] EmailBodyDto email);
    }
}
