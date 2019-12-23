using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OrderModel=PizzaBox.Domain.Models.OrderModel;
using PizzaModel=PizzaBox.Domain.Models.PizzaModel;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;
using System;

namespace PizzaBox.Storing.Repositories
{
  public class OrderRepository
  {
    // private MapperConfiguration _orderConfig = new MapperConfiguration(c => c.CreateMap<OrderModel, Entities.Order>().ForMember(s => s.TotalCost, o => o.MapFrom(d => d.OrderTotal)));
    // private static List<OrderModel> _orderList;
    // private const string _path = @"orders.xml";
    private static readonly SqlAdapter _sa = new SqlAdapter();
    private static readonly MapperConfiguration _orderConfig = new MapperConfiguration(c => c.CreateMap<Order, OrderModel>());
    private static readonly MapperConfiguration _pizzaConfig = new MapperConfiguration(c => c.CreateMap<PizzaModel, Pizza>());
    
    // private static readonly MapperConfiguration _orderPizzaConfig = new MapperConfiguration(c => c.CreateMap<PizzaModel, OrderPizza>());

    public OrderRepository()
    {
      // if (_orderList == null)
      // {
      //   try
      //   {
      //     _orderList = FileAdapter.ReadFromXml<List<OrderModel>>(_path);
      //   }
      //   catch
      //   {
      //     _orderList = new List<OrderModel>();
      //     Save();
      //   }
      // }
    }

    public void Create(OrderModel o)
    {
      
      // Order
      Order newOrder = new Order();
      newOrder.UserId = _sa.GetUser(o.User.Email, o.User.Password).UserId;
      newOrder.StoreId = _sa.GetStore(o.Store.StoreName).StoreId;
      newOrder.TotalCost = 9.99M;
      newOrder.OrderDate = DateTime.Now;
      // OrderPizza
      // Pizza
      foreach (var p in o.Pizzas)
      {
        Pizza newPizza = new Pizza();
        newPizza.Cost = p.Cost;
        newPizza.SizeId = _sa.GetSize(p.Size).SizeId;
        newPizza.CrustId = _sa.GetCrust(p.Crust).CrustId;
        // add pizza
        foreach (var t in p.Toppings)
        {
          PizzaTopping pt = new PizzaTopping();
          pt.Pizza = newPizza;
          pt.ToppingId = _sa.GetTopping(t).ToppingId;
          newPizza.PizzaTopping.Add(pt);
        }
        OrderPizza op = new OrderPizza();
        op.Order = newOrder;
        op.Pizza = newPizza;
        newOrder.OrderPizza.Add(op);
      }
      _sa.CreateOrder(newOrder);
    }

    public OrderModel Read()
    {
      // if (order == null)
      // {
      //   return _orderList;
      // }
      // return _orderList.Where(o => o.Id == order.Id).ToList();
      Order o = _sa.GetOrder(2);
      var om = new Mapper(_orderConfig);

      // OrderModel om = new OrderModel();
      // om.OrderDate = o.OrderDate;
      OrderModel m = om.Map<OrderModel>(o);
      return m;
    }

    // public void Update(OrderModel order)
    // {
    //   var orderItem = _orderList.FirstOrDefault(o => o.Id == order.Id);

    //   orderItem = order;
    //   Save();
    // }

    // public void Delete(OrderModel order)
    // {
    //   var orderItem = _orderList.FirstOrDefault(o => o.Id == order.Id);

    //   _orderList.Remove(orderItem);
    //   Save();
    // }

    private void Save()
    {
      // FileAdapter.WriteToXml<List<OrderModel>>(_orderList, _path);
    }
  }
}