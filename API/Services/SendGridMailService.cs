﻿using API.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;


namespace API.Services
{
    public class SendGridMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public SendGridMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string content)
        {
            var apiKey = _configuration["Token:SendGridAPIKey"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("support@doctorclick.app", "Info Doctor Click");
            var to = new EmailAddress(toEmail);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
