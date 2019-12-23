using System;
using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
    public partial class StoreModel
    {
        public StoreModel()
        {
          Orders = new List<OrderModel>();
          Address = new AddressModel();
        }

        public string StoreName { get; set; }

        public AddressModel Address { get; set; }
        // public UserModel User { get; set; }
        public List<OrderModel> Orders { get; set; }
    }
}
