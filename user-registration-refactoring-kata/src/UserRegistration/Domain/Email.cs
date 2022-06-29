namespace UserRegistration.Domain;

public class Email
{
    public string From { get; }
    public string To { get; }
    public string Subject { get; }
    public string Body { get; }

    public Email(String from, String to, String subject, String body)
    {
        From = from;
        To = to;
        Subject = subject;
        Body = body;
    }
}