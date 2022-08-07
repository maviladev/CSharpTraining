using System;
using Portfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Services
{
	public interface ISendGridEmailService
	{
		Task Send(ContactDTO data);
	}

	public class SendGridEmailService : ISendGridEmailService
	{
		private readonly IConfiguration configuration;

        public SendGridEmailService(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public async Task Send(ContactDTO data)
		{
			var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
			var email = configuration.GetValue<string>("SENDGRID_FROM");
			var name = configuration.GetValue<string>("SENDGRID_NAME");

			var client = new SendGridClient(apiKey);
			var from = new EmailAddress(email, name);
			var subject = $"El cliente {data.Email} quiere contactarte";
			var to = new EmailAddress(email, name);
			var messagePlainText = data.Message;
			var htmlContent = $@"De: {data.Name} -
Email: {data.Email}
Mensaje: {data.Message}";

			var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, messagePlainText, htmlContent);
			var response = await client.SendEmailAsync(singleEmail);

		}
	}
}

