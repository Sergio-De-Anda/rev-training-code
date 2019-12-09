using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class UserModel : AUser
    {
      public bool Admin { get; set; }
      public List<OrderModel> Orders { get; set; }
      public AddressModel Address { get; set; }

      public UserModel()
      {
        Address = new AddressModel();
        this.Orders = new List<OrderModel>();
      }

      
      
      public override string ToString()
      {
        return $"{this.FirstName}";
      }
    }
}