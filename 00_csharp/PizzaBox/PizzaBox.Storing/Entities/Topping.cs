using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class Topping
    {
        public Topping()
        {
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
