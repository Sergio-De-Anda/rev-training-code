using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class Order
    {
        public Order()
        {
            OrderPizza = new HashSet<OrderPizza>();
        }

        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int StoreId { get; set; }
        public decimal TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public bool? Active { get; set; }

        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderPizza> OrderPizza { get; set; }
    }
}
