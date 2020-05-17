namespace JobApplication.Services
{
    using JobApplication.Models;

    public interface IEmailSender
    {
        void Send(string recepient, string name, Position position);
    }
}
