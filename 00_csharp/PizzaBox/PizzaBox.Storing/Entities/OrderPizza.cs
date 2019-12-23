using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class OrderPizza
    {
        public int OrderPizzaId { get; set; }
        public int OrderId { get; set; }
        public int PizzaId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Pizza Pizza { get; set; }
    }
}
