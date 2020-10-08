using AutumnStore.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutumnStore.Data.Helpers.Seed
{
    internal static class BillingUserSeed
    {
        internal static IEnumerable<User> PopulateUser()
        {
            return new List<User>()
            {
                 AddNewUser(1,"Nemo", "Memo"),
                 AddNewUser(2,"Scooby", "Doo")
            };
        }

        public static User AddNewUser(int userId, string firstName, string lastName)
        {
            return new User()
            {
                UserId = userId,
                FirstName = firstName,
                LastName = lastName
            };
        }
    }
}
