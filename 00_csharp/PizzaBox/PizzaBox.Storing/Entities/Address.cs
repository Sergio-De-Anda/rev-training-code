using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class Address
    {
        public Address()
        {
            Store = new HashSet<Store>();
            User = new HashSet<User>();
        }

        public int AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string AddressState { get; set; }
        public int ZipCode { get; set; }

        public virtual ICollection<Store> Store { get; set; }
        public virtual ICollection<User> User { get; set; }

        public override string ToString()
        {
          return $"{this.Street}, {this.City}, {this.AddressState} {this.ZipCode}";
        }
    }
}
