using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class OrderModel
    {
      public OrderModel()
        {
          Pizzas = new List<PizzaModel>();
          User = new UserModel();
        }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }

        public UserModel User { get; set; }
        public List<PizzaModel> Pizzas { get; set; }

    }
}