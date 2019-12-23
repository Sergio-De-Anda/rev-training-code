using System;
using System.Collections.Generic;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Domain.Models
{
    public class Pizza : AModel
    {
        public string Crust { get; set; }
        public string Size { get; set; }
        public decimal Price 
        { 
          get {
            if(this.Size == "Small")
              return 4.99M;
            else if(this.Size == "Medium")
              return 7.99M;
            else if(this.Size == "Large")
              return 9.99M;
            else
              return 250.00M;
          }
        }
        public string Topping { get; set; }

        public Pizza()
        {
        }
        public Pizza(string s, string c, string t)
        {
          this.Size = s;
          this.Crust = c;
          this.Topping = t;
        }
        
        public bool ChooseCrust()
        {
          // this.Crust = c;
          Console.WriteLine("Crusts: ");
          Console.WriteLine("1. Hand-tossed");
          Console.WriteLine("2. Thin");
          Console.WriteLine("3. Cheese-stuffed");
          Console.Write("Choose crust: ");
          int input = Convert.ToInt32(Console.ReadLine());
          switch (input)
          {
            case 1:
              this.Crust = "Hand-tossed";
              break;
            case 2:
              this.Crust = "Thin";
              break;
            case 3:
              this.Crust = "Cheese-stuffed";
              break;
            default:
              return false;
          }
          return true;
        }

        public bool ChooseSize()
        {
          // this.Size
          Console.WriteLine("Sizes: ");
          Console.WriteLine("1. Small     $4.99");
          Console.WriteLine("2. Medium    $7.99");
          Console.WriteLine("3. Large     $9.99");
          Console.Write("Choose size: ");
          int input = Convert.ToInt32(Console.ReadLine());
          switch (input)
          {
            case 1:
              this.Size = "Small";
              break;
            case 2:
              this.Size = "Medium";
              break;
            case 3:
              this.Size = "Large";
              break;
            default:
              // ChooseSize();
              return false;
          }
          return true;
        }

        public bool ChooseTopping()
        {
          // this.Size
          Console.WriteLine("Topping: ");
          Console.WriteLine("1. Pepperoni");
          Console.WriteLine("2. Chicken");
          Console.WriteLine("3. Beef");
          Console.Write("Choose topping: ");
          int input = Convert.ToInt32(Console.ReadLine());
          switch (input)
          {
            case 1:
              this.Topping = "Pepperoni";
              break;
            case 2:
              this.Topping = "Chicken";
              break;
            case 3:
              this.Topping = "Beef";
              break;
            default:
              return false;
          }
          return true;
        }

        public override string ToString()
        {
          return $"{this.Size} pizza with {this.Crust} crust and {this.Topping}" ;
        }
    }
}