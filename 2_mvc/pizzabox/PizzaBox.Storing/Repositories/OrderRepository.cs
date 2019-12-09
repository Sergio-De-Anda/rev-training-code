using System.Collections.Generic;
using System.Linq;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;
using System;
using PizzaBox.Domain.Models;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    private static readonly SqlAdapter _sa = new SqlAdapter();

    public void Create(OrderModel o)
    {
      
      // Order
      Order newOrder = new Order();
      newOrder.UserId = _sa.GetUser(o.User.Email, o.User.Password).UserId;
      newOrder.StoreId = _sa.GetStore(o.StoreName).StoreId;
      // newOrder.StoreName = o.StoreName;
      newOrder.TotalCost = 0M;
      newOrder.OrderDate = DateTime.Now;
      // OrderPizza
      // Pizza
      foreach (var p in o.Pizzas)
      {
        Pizza newPizza = new Pizza();
        newPizza.Cost = p.Cost;
        newPizza.SizeId = _sa.GetSize(p.Size).SizeId;
        newPizza.CrustId = _sa.GetCrust(p.Crust).CrustId;
        newPizza.Cost = _sa.GetSize(p.Size).Price + _sa.GetCrust(p.Crust).Price;
        foreach (var t in p.Toppings)
        {
          PizzaTopping pt = new PizzaTopping();
          pt.Pizza = newPizza;
          pt.ToppingId = _sa.GetTopping(t).ToppingId;
          newPizza.PizzaTopping.Add(pt);
          newPizza.Cost += _sa.GetTopping(t).Price;
        }
        OrderPizza op = new OrderPizza();
        op.Order = newOrder;
        op.Pizza = newPizza;
        newOrder.OrderPizza.Add(op);
        newOrder.TotalCost += newPizza.Cost;
      }
      _sa.CreateOrder(newOrder);
    }

    public Order Read(string store, UserModel user)
    {
      int StoreId = _sa.GetStore(store).StoreId;
      int UserId = _sa.GetUser(user.Email, user.Password).UserId;
      Order o = _sa.GetOrder(StoreId, UserId);
      if(o != null)
        return o;
      return null;
    }

    public Order Read(UserModel user)
    {
      int UserId = _sa.GetUser(user.Email, user.Password).UserId;
      Order o = _sa.GetOrderByUserId(UserId);
      if(o != null)
        return o;
      return null;
    }

  }
}