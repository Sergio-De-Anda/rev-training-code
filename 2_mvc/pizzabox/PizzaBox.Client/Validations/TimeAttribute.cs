using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using PizzaBox.Client.Controllers;
using PizzaBox.Domain.Models;
using PizzaBox.Storing.Entities;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Client.Validations
{
  public class TimeAttribute : ValidationAttribute
  {
    private static OrderRepository _or = new OrderRepository();
    public override bool IsValid(object o)
    {
      // var s = o;
      UserModel currentUser = HomeController._currentUser;
      // DataTime Now = 
      Order order = _or.Read(currentUser);
      if(order != null)
      {
        TimeSpan now = DateTime.Now - order.OrderDate;
        if(now < new TimeSpan(0, 1, 0, 0))
        {
          return false;
        }
      }
      return true;
    }
  }
}