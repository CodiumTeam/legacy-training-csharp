using UserRegistration.Controllers;
using UserRegistration.Domain;

namespace UserRegistration.UseCase
{
    public class RegisterUser
    {
        private readonly EmailSender _smtpEmailSender;

        public RegisterUser(EmailSender emailSender)
        {
            _smtpEmailSender = emailSender;
        }

        public User Execute(string Password, string Email, string Name)
        {
            if (Password.Length <= 8 || !Password.Contains("_"))
            {
                throw new InvalidPasswordException();
            }

            if (UserRegistrationController.orm.FindByEmail(Email) != null)
            {
                throw new UserAlreadyExistsException();
            }

            var rng = new Random();
            var user = new User
            {
                Id = rng.Next(1, 1000),
                Name = Name,
                Password = Password,
                Email = Email
            };
            UserRegistrationController.orm.Save(user);

            var email = new Email(
                "noreply@codium.team",
                Email,
                "Welcome to Codium",
                "This is the confirmation email"
            );
            _smtpEmailSender.SendEmail(email);

            return user;
        }
    }
}