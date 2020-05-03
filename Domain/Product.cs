using System;
using System.Collections.Generic;

namespace Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
