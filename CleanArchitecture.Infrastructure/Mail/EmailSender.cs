using CleanArichitecture.Application.Infrastracture;
using CleanArichitecture.Application.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Mail
{
    public class EmailSender : IEmailSender
    {
        #region Fields

        private readonly EmailSettingModel _emailSetting;

        #endregion

        #region Ctor

        public EmailSender(IOptions<EmailSettingModel> emailSetting)
        {
            _emailSetting = emailSetting.Value;
        }

        #endregion

        public async Task<bool> SendEmail(EmailModel model)
        {
            var client = new SendGridClient(_emailSetting.ApiKey);
            var to = new EmailAddress(model.ToAddress);
            var from = new EmailAddress
            {
                Name = _emailSetting.FromName,
                Email = _emailSetting.FromAddress
            };

            var message = MailHelper.CreateSingleEmail(from, to, model.Subject, model.Body, model.Body);
            var response = await client.SendEmailAsync(message);
            return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted;
        }
    }
}
