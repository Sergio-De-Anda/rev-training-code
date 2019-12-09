using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class OrderModel : AModel
    {
      public OrderModel()
        {
          Pizzas = new List<PizzaModel>();
        }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }

        public StoreModel Store { get; set; }
        public UserModel User { get; set; }
        public List<PizzaModel> Pizzas { get; set; }

        // public override string ToString()
        // {
        //   return $"{this.Store.StoreName}";
        // }
    }
}