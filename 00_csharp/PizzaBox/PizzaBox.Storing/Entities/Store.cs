using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class Store
    {
        public Store()
        {
            Order = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public int AddressId { get; set; }
        public int UserId { get; set; }

        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
