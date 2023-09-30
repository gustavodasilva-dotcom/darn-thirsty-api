using DarnThirsty.Tools.Configuration;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace DarnThirsty.Tools.Email;

public static class EmailHelper
{
	public static void Send(EmailSettings settings)
	{
		var email = new MimeMessage();

		foreach (var from in settings.Senders)
			email.From.Add(MailboxAddress.Parse(from));
		foreach (var to in settings.Recipients)
			email.To.Add(MailboxAddress.Parse(to));

		email.Subject = settings.Subject;
		email.Body = new TextPart(TextFormat.Html)
		{
			Text = "<h1>Example HTML Message Body</h1>"
		};

		using var smtp = new SmtpClient();
		smtp.Connect(
			Settings.Configuration["SmtpConfig:Smtp"],
			int.Parse(Settings.Configuration["SmtpConfig:Port"]),
			SecureSocketOptions.StartTls
		);
		smtp.Authenticate(
			Settings.Configuration["SmtpConfig:Username"],
			Settings.Configuration["SmtpConfig:Password"]
		);
		smtp.Send(email);
		smtp.Disconnect(true);
	}
}