using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    private static readonly SqlAdapter _sa = new SqlAdapter();
    

    public StoreRepository()
    {
    }
    public void Create(Store u)
    {
      
    }

    public decimal GetSalesByMonth(StoreModel s, int m)
    {
      List<Order> orders = _sa.GetAllOrders(_sa.GetStore(s.StoreName).StoreId, m);
      decimal sum = 0M;
      foreach (var o in orders)
      {
        sum += o.TotalCost;
      }
      return sum;
    }

    public List<Store> Read()
    {
      return _sa.GetAllStores();
    }

    public StoreModel Read(string s)
    {
      Store tempStore = _sa.GetStore(s);
      StoreModel currentStore = new StoreModel();
      currentStore.StoreName = tempStore.StoreName;
      currentStore.Address.Street = tempStore.Address.Street;
      currentStore.Address.City = tempStore.Address.City;
      currentStore.Address.AddressState = tempStore.Address.AddressState;
      currentStore.Address.ZipCode = tempStore.Address.ZipCode;
      foreach (var o in tempStore.Order)
      {
        Order currentOrder = _sa.GetOrder(o.OrderId);
        OrderModel newOrder = new OrderModel();
        newOrder.UserId = currentOrder.UserId;
        newOrder.StoreId = currentOrder.StoreId;
        newOrder.OrderDate = currentOrder.OrderDate;
        newOrder.TotalCost = currentOrder.TotalCost;
        foreach (var pizza in currentOrder.OrderPizza)
        {
            Pizza currentPizza = _sa.GetPizza(pizza.PizzaId);
            PizzaModel newPizza = new PizzaModel();
            newPizza.Cost = currentPizza.Cost;
            newPizza.Crust = currentPizza.Crust.CrustName;
            newPizza.Size = currentPizza.Size.SizeName;
            foreach (var topping in currentPizza.PizzaTopping)
            {
              Topping t = _sa.GetTopping(topping.ToppingId);
              newPizza.Toppings.Add(t.ToppingName);
            }
            newOrder.Pizzas.Add(newPizza);
        }
        currentStore.Orders.Add(newOrder);
      }
      return currentStore;
    }

    public void Update(UserModel u)
    {
    }

    public void Delete(UserModel u)
    {
    }

    private void Save()
    {
    }
  }
}