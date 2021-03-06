using System.Collections.Generic;

namespace UserRegistration
{
    public class OrmUserRepository
    {
        private Dictionary<string, User> persistedUsers = new Dictionary<string, User>();
        public void Save(User user)
        {
            persistedUsers[user.Email] = user;
        }

        public User FindByEmail(string email)
        {
            return persistedUsers.GetValueOrDefault(email);
        }

    }
}