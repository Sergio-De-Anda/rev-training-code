using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class UserAccount
    {
        public UserAccount()
        {
            User = new HashSet<User>();
        }

        public int UserAccountId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
