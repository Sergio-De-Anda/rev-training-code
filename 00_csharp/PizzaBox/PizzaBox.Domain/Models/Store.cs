using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Store : AModel
    {
        public string Name { get; set; }
        public List<Order> CompletedOrders { get; private set; }
        public string StoreLocation { get; set; }
        public Store()
        {
          CompletedOrders = new List<Order>();
        }
        public Store(String name, string location)
        {
          this.Name = name;
          this.StoreLocation = location;
          this.CompletedOrders = new List<Order>();
        }
        public void ViewStoreOrders()
        {
          if(CompletedOrders.Count == 0)
          {
            Console.WriteLine("No orders found");
            return;
          }
          Console.WriteLine("\nOrders for {0}", this.Name);
          foreach (var order in this.CompletedOrders)
          {
              order.PrintOrder();
              Console.WriteLine();
          }
        }

        public void AddOrder(Order o)
        {
          this.CompletedOrders.Add(o);
        }

        public override string ToString()
        {
          return $"{this.Name}";
        }
    }
}