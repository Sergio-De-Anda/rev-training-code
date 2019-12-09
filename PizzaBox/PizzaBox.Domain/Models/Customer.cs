using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Customer : AUser
    {
      public List<Order> Orders { get; }

      public Customer()
      {
        this.Orders = new List<Order>();
      }

      public void AddOrder(Order o)
      {
        Orders.Add(o);
      }

      public void ViewOrderHistory()
      {
        if(Orders.Count == 0)
        {
          Console.WriteLine("No orders found");
          return;
        }
        Console.WriteLine("\nOrders for {0}:", this.FirstName);
        foreach (var o in Orders)
        {
            o.PrintOrder();
            Console.WriteLine();
        }
        
      }
      
      public override string ToString()
      {
        return $"{this.FirstName}";
      }
    }
}