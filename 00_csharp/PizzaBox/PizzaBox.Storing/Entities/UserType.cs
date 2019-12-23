using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int UserTypeId { get; set; }
        public string UserType1 { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
