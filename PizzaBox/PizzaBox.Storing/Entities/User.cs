using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
            Store = new HashSet<Store>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool? Active { get; set; }
        public int UserAccountId { get; set; }
        public int UserTypeId { get; set; }
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
        public virtual UserAccount UserAccount { get; set; }
        public virtual UserType UserType { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Store> Store { get; set; }
    }
}
