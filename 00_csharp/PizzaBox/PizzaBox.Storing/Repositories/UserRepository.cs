using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;
using PizzaBox.Storing.Entities;
using Pizza=PizzaBox.Storing.Entities.Pizza;
using Order=PizzaBox.Storing.Entities.Order;

namespace PizzaBox.Storing.Repositories
{
  public class UserRepository
  {
    private static List<UserModel> _userList;
    private const string _path = @"users.xml";
    private static readonly SqlAdapter _sa = new SqlAdapter();
    // private static readonly MapperConfiguration _userConfig = new MapperConfiguration(c => c.CreateMap<UserModel, User>());
    // private static readonly MapperConfiguration _addressConfig = new MapperConfiguration(c => c.CreateMap<UserModel, Address>());
    // private static readonly MapperConfiguration _userTypeConfig = new MapperConfiguration(c => c.CreateMap<UserModel, UserType>());
    // private static readonly MapperConfiguration _userAccountConfig = new MapperConfiguration(c => c.CreateMap<UserModel, UserAccount>());
    

    public UserRepository()
    {
      // Initialize();
      // if (_userList == null)
      // {
      //   try
      //   {
      //     _userList = FileAdapter.ReadFromXml<List<UserModel>>(_path);
      //   }
      //   catch
      //   {
      //     _userList = new List<UserModel>();
      //     Save();
      //   }
      // }
    }
    public void Create(UserModel u)
    {
      // _userList.Add(u);
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
      // if (u == null)
      // {
      //   return null;
      // }
      // return _userList.Find(x => x.Email==u.Email && x.Password==u.Password);
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
      // tempU.UserType = u.UserType.UserType1;
      
      // get orders
      foreach (var o in u.Order)
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
        tempU.Orders.Add(newOrder);

        // tempU.Orders.Add(newOrder);
      }
      // tempU.Orders = u.Order;
      return tempU;
    }

    public void Update(UserModel u)
    {
      var customerItem = _userList.FirstOrDefault(o => o.Id == u.Id);

      customerItem = u;
      Save();
    }

    public void Delete(UserModel u)
    {
      var cItem = _userList.FirstOrDefault(o => o.Id == u.Id);

      _userList.Remove(cItem);
      Save();
    }

    private void Save()
    {
      FileAdapter.WriteToXml<List<UserModel>>(_userList, _path);
    }
  }
}