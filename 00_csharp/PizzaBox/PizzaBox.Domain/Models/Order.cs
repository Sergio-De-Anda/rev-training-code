using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Order : AModel
    {
      public long CustomerId { get; set; }
      public List<Pizza> Pizzas { get; private set; }
      public DateTime OrderDate { get; set; }
      public decimal OrderTotal { 
        get
        {
          decimal sum = 0;
          foreach (var pizza in this.Pizzas)
          {
            sum += pizza.Price;
          }
          return sum;
        }
      }
      public string StoreName { get; set; }

      public Order(){
        Pizzas = new List<Pizza>();
        OrderDate = DateTime.Now;
      }
      // public Order(List<Pizza> p)
      // {
      //   this.Pizzas = p;
      //   OrderDate = DateTime.Now;
      // }

      public bool AddPizza(Pizza p)
      {
        if(p == null)
          return false;
        this.Pizzas.Add(p);
        if(this.OrderTotal >= 250.00M)
        {
          Console.Clear();
          Console.WriteLine("Order total can't be more than $250");
          return false;
        }
        return true;
      }

      public void PrintOrder()
      {
        Console.WriteLine("Date: {0}", this.OrderDate);
        Console.WriteLine("Total: ${0}", this.OrderTotal);
        Console.WriteLine("Customer ID: {0}\nStore: {1}", this.CustomerId, this.StoreName);
        Console.WriteLine("Pizzas:");
        foreach (var p in Pizzas)
        {
            Console.WriteLine(p);
        }
      }
    }
}