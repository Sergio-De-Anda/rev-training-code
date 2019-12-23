using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class Pizza
    {
        public Pizza()
        {
            OrderPizza = new HashSet<OrderPizza>();
            PizzaTopping = new HashSet<PizzaTopping>();
        }

        public int PizzaId { get; set; }
        public decimal Cost { get; set; }
        public int SizeId { get; set; }
        public int CrustId { get; set; }

        public virtual Crust Crust { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
        public virtual ICollection<PizzaTopping> PizzaTopping { get; set; }
    }
}
