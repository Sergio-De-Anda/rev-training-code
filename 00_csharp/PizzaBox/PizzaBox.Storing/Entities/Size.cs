using System;
using System.Collections.Generic;

namespace PizzaBox.Storing.Entities
{
    public partial class Size
    {
        public Size()
        {
            Pizza = new HashSet<Pizza>();
        }

        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Pizza> Pizza { get; set; }
    }
}
