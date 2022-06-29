namespace UserRegistration.Domain;

public interface EmailSender
{
    public void SendEmail(Email email);
}