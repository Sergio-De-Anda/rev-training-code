using System.Collections.Generic;

namespace PizzaBox.Domain.Models
{
  public class PizzaModel
  {
      public PizzaModel()
        {
            Toppings = new List<string>();
        }

        public decimal Cost { get; set; }
        public string Crust { get; set; }
        public string Size { get; set; }
        public List<string> Toppings { get; set; }
  }
}