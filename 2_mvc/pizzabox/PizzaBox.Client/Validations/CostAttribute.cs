using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PizzaBox.Client.Validations
{
  public class CostAttribute : ValidationAttribute
  {
    public override bool IsValid(object o)
    {
      // var c = o as ;
      // Console.WriteLine(c);
      // if(c >= 250M)
      //   return false;
      return true;
    }
  }
}