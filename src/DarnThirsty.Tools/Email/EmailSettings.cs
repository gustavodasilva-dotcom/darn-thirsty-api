namespace DarnThirsty.Tools.Email;

public class EmailSettings
{
	public EmailSettings()
	{
		Senders = new List<string>();
		Recipients = new List<string>();
	}


	public List<string> Senders { get; set; }
	public List<string> Recipients { get; set; }
	public string Subject { get; set; }
}