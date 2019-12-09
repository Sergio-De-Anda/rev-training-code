using System.Collections.Generic;
using System.Linq;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Adapters;

namespace PizzaBox.Storing.Repositories
{
  public class CustomerRepository
  {
    private static List<Customer> _customerList;
    private const string _path = @"customers.xml";
    public CustomerRepository()
    {
      // Initialize();
      if (_customerList == null)
      {
        try
        {
          _customerList = FileAdapter.ReadFromXml<List<Customer>>(_path);
        }
        catch
        {
          _customerList = new List<Customer>();
          Save();
        }
      }
    }
    public void Create(Customer customer)
    {
      _customerList.Add(customer);
      Save();
    }

    public Customer Read(Customer customer)
    {
      if (customer == null)
      {
        return null;
      }
      return _customerList.Find(x => x.Email==customer.Email && x.Password==customer.Password);
    }

    public void Update(Customer customer)
    {
      var customerItem = _customerList.FirstOrDefault(o => o.Id == customer.Id);

      customerItem = customer;
      Save();
    }

    public void Delete(Customer customer)
    {
      var cItem = _customerList.FirstOrDefault(o => o.Id == customer.Id);

      _customerList.Remove(cItem);
      Save();
    }

    private void Save()
    {
      FileAdapter.WriteToXml<List<Customer>>(_customerList, _path);
    }
  }
}