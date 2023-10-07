using CleanArichitecture.Application.Models;
using System.Threading.Tasks;

namespace CleanArichitecture.Application.Infrastracture
{
    public interface IEmailSender
    {
        Task<bool> SendEmail(EmailModel model);
    }
}