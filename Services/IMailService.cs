namespace website_backend.Services
{
    public interface IMailService
    {
        void Send(string subject, string message);
    }
}