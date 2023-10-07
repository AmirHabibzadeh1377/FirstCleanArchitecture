using CleanArichitecture.Application.Infrastracture;
using CleanArichitecture.Application.Models;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        #region Fields

        private readonly IOptions<EmailSettingModel> _emailSetting;

        #endregion

        #region Ctor

        public EmailSender(IOptions<EmailSettingModel> emailSetting)
        {
            _emailSetting = emailSetting;
        }

        #endregion

        public Task<bool> SendEmail(EmailModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
