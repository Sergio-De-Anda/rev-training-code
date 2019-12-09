using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Models
{
  public class AdminViewModel
  {
    private static StoreRepository _sr = new StoreRepository();
    public AdminViewModel()
    {
      Stores = _sr.Read();
      User = new UserModel();
      Months = new List<int>();
      for(int i = 1; i <= 12; i++)
      {
        Months.Add(i);
      }
      Sum = 0;
    }
    [Required]
    public string StoreSelected { get; set; }
    public int MonthSelected { get; set; }
    public decimal Sum { get; set; }
    public StoreModel Store { get; set; }
    public UserModel User { get; set; }
    public List<Store> Stores { get; set; }
    public List<int> Months { get; set; }
  }
}