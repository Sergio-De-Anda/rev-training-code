using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Adapters
{
  public class SqlAdapter
  {
    private PizzaBoxDbContext _db = new PizzaBoxDbContext();

    // Size
    public Size GetSize(string s)
    {
      return _db.Size.Where(x => x.SizeName == s).FirstOrDefault();
    }
    public List<Size> GetAllSizes()
    {
      return _db.Size.ToList();
    }
    // Crust
    public Crust GetCrust(string c)
    {
      return _db.Crust.Where(x => x.CrustName == c).FirstOrDefault();
    }
    public List<Crust> GetAllCrusts()
    {
      return _db.Crust.ToList();
    }
    // Topping
    public Topping GetTopping(string t)
    {
      return _db.Topping.Where(x => x.ToppingName == t).FirstOrDefault();
    }
    public Topping GetTopping(int id)
    {
      return _db.Topping.Where(x => x.ToppingId == id).FirstOrDefault();
    }
    public List<Topping> GetAllToppings()
    {
      return _db.Topping.ToList();
    }
    // Pizza
    public Pizza GetPizza(int id)
    {
      return _db.Pizza.Where(p => p.PizzaId == id).Include(s => s.Size).Include(c => c.Crust).Include(t => t.PizzaTopping).FirstOrDefault();
    }
    // Address
    public bool CreateAddress(Address a)
    {
      _db.Address.Add(a);
      return _db.SaveChanges() == 1;
    }
    public List<Address> GetAddresses()
    {
      return _db.Address.ToList();
    }
    public Address GetAddress()
    {
      return _db.Address.Where(a => a.AddressId == 1).First();
    }
    
    public bool UpdateAddress(Address a)
    {
      _db.Update(a);
      return _db.SaveChanges() == 1;
    }

    public bool DeleteAddress(Address a)
    {
      _db.Remove(a);
      return _db.SaveChanges() == 1;
    }

    // Order
    
    public bool CreateOrder(Order order)
    {
      foreach (var op in order.OrderPizza)
      {
        foreach (var t in op.Pizza.PizzaTopping)
        {
          _db.PizzaTopping.Add(t);
        }
        _db.Pizza.Add(op.Pizza); //git add
        
        _db.OrderPizza.Add(op);
      }
      
      _db.Order.Add(order); //git add

      return _db.SaveChanges() ==  1; //git commit
    }

    public Order GetOrder(int id)
    {
      return _db.Order.Where(o => o.OrderId == id).Include(p => p.OrderPizza).FirstOrDefault();
    }
     public Order GetOrderByUserId(int u)
    {
      return _db.Order.Where(x => x.UserId == u).OrderByDescending(d => d.OrderDate).FirstOrDefault();
    } 
    public Order GetOrder(int s, int u)
    {
      return _db.Order.Where(x => x.UserId == u && x.StoreId == s).OrderByDescending(d => d.OrderDate).FirstOrDefault();
    }

    public List<Order> GetAllOrders(int sId, int month)
    {
      return _db.Order.Where(o => o.StoreId == sId && o.OrderDate.Month == month).ToList();
      
    }

    // User
    public bool CreatUser(User u)
    {
      _db.Address.Add(u.Address);
      _db.UserAccount.Add(u.UserAccount);
      _db.User.Add(u);
      return _db.SaveChanges() == 1;
    }
    public User GetUser(string e, string p)
    {
      return _db.User.Where(x => x.UserAccount.Email == e && x.UserAccount.Password == p).Include(a => a.Address).Include(t => t.UserType).Include(a => a.UserAccount).Include(o => o.Order).FirstOrDefault();
    }

    // Store
    public bool CreateStore(Store s)
    {
      return false;
    }
    public Store GetStore(string n)
    {
      return _db.Store.Where(x => x.StoreName == n).Include(a => a.Address).Include(o => o.Order).FirstOrDefault();
    }
     public Store GetStore(int id)
    {
      return _db.Store.Where(x => x.StoreId == id).Include(a => a.Address).Include(o => o.Order).FirstOrDefault();
    }

    public List<Store> GetAllStores()
    {
      return _db.Store.Include(a => a.Address).ToList();
    }
  }
}