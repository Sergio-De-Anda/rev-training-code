using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;

namespace PizzaBox.Storing.Repositories
{
  public class ManagerRepository
  {
    public List<Manager> _managerList;
    public ManagerRepository()
    {
      Initialize();
    }
    
    private void Initialize()
    {
      _managerList = new List<Manager>();
      _managerList.Add(CreateManager());
    }
    private Manager CreateManager()
    {
      Manager m = new Manager();
      m.FirstName = "Admin";
      // m.Address = "Arlington, TX";
      m.Email = "admin@pizzabox.com";
      m.Password = "123";
      return m;
    }
  }
}