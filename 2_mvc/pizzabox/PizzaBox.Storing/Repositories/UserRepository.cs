using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private static readonly SqlAdapter _sa = new SqlAdapter();
    
    public void Create(UserModel u)
    {
      // Save();
      Address newUserAddress = new Address();
      newUserAddress.Street = u.Address.Street;
      newUserAddress.City = u.Address.City;
      newUserAddress.AddressState = u.Address.AddressState;
      newUserAddress.ZipCode = u.Address.ZipCode;

      UserAccount newUserAccount = new UserAccount();
      newUserAccount.Email = u.Email;
      newUserAccount.Password = u.Password;

      User newUser = new User();
      newUser.FirstName = u.FirstName;
      newUser.LastName = u.LastName;
      newUser.Address = newUserAddress;
      newUser.UserAccount = newUserAccount;
      newUser.UserTypeId = 2;

      _sa.CreatUser(newUser);
    }

    public UserModel Read(string e, string p)
    {
      User u = _sa.GetUser(e, p);
      if(u == null)
        return null;
      UserModel tempU = new UserModel();
      tempU.FirstName = u.FirstName;
      tempU.LastName = u.LastName;
      tempU.Address.Street = u.Address.Street;
      tempU.Address.City = u.Address.City;
      tempU.Address.AddressState = u.Address.AddressState;
      tempU.Address.ZipCode = u.Address.ZipCode;
      tempU.Email = u.UserAccount.Email;
      tempU.Password = u.UserAccount.Password;
      if(u.UserType.UserType1 == "Manager")
      {
        tempU.Admin = true;
        return tempU;
      }
      // get orders
      foreach (var o in u.Order)
      {
        Order currentOrder = _sa.GetOrder(o.OrderId);
        OrderModel newOrder = new OrderModel();
        newOrder.StoreName = _sa.GetStore(currentOrder.StoreId).StoreName;
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
        tempU.Orders.Add(newOrder);
      }
      return tempU;
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