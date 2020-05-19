using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Unit { get; set; }
        public double Stock { get; set; }
        public string Picture { get; set; }
        public double Price { get; set; }
        public bool Current { get; set; } // Tells if the product is currently on sale
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Suppliers { get; set; }

    }
}
