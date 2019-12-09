using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using PizzaBox.Client.Controllers;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Validations
{
  public class SameStoreAttribute : ValidationAttribute
  {
    private static OrderRepository _or = new OrderRepository();
    public override bool IsValid(object o)
    {
      var s = o as string;
      UserModel currentUser = HomeController._currentUser;
      Console.WriteLine(currentUser);
      if(_or.Read(s, currentUser) != null)
      {
        TimeSpan now = DateTime.Now -_or.Read(s, currentUser).OrderDate;
        if(now < new TimeSpan(0, 24, 0, 0))
        {
          return false;
        }
      }
      return true;
    }
  }
}