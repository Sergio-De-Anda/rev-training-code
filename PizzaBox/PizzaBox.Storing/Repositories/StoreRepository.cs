using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
// using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;
using Store=PizzaBox.Storing.Entities.Store;
using Order=PizzaBox.Storing.Entities.Order;
using Pizza=PizzaBox.Storing.Entities.Pizza;

namespace PizzaBox.Storing.Repositories
{
  public class StoreRepository
  {
    // public List<Store> _storeList { get; set; }
    // private const string _path = @"stores.xml";
    private static readonly SqlAdapter _sa = new SqlAdapter();

    public StoreRepository()
    {
      // if (_storeList == null)
      // {
      //   try
      //   {
      //     _storeList = FileAdapter.ReadFromXml<List<Store>>(_path);
      //   }
      //   catch
      //   {
      //     _storeList = new List<Store>();
      //     Save();
      //   }
      // }
    }
    public void Create(StoreModel s)
    {
      // _storeList.Add(s);
      Save();
    }

    public StoreModel Read(string s)
    {
      // if (s == null)
      // {
      //   return null;
      // }
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
        newOrder.TotalCost = currentOrder.OrderPizza.Count;
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
        // newOrder.Store = 
        currentStore.Orders.Add(newOrder);

        // tempU.Orders.Add(newOrder);
      }

      // return _storeList.Find(x => x.Name == s.Name);
      return currentStore;
    }

    public void Update(StoreModel s)
    {
      // var sItem = _storeList.FirstOrDefault(o => o.Id == s.Id);

      // sItem = s;
      Save();
    }

    public void Delete(StoreModel s)
    {
      // var sItem = _storeList.FirstOrDefault(o => o.Id == s.Id);

      // _storeList.Remove(sItem);
      Save();
    }

    private void Save()
    {
      // FileAdapter.WriteToXml<List<StoreModel>>(_storeList, _path);
    }
    // private void Initialize()
    // {
    //   Stores = new List<Store>();
    //   Stores.Add(new Store("Pizza Planet", "Arlington, TX"));
    //   Stores.Add(new Store("Best Pizza", "Dallas, TX"));
    //   Stores.Add(new Store("Freddie's Pizza", "Dallas, TX"));
    // }
  }
}