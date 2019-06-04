using accesscontrol.Model;
using accesscontrol.Services.Base;

namespace accesscontrol.Service
{
    public interface IEmailSender
    {
        void SendEmail(string body, string email);
    }
}