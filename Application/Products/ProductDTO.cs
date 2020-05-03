using System;
using System.Collections.Generic;

namespace Application.Products
{
    public class ProductDTO
    {
        //public int Id { get; set; }
        public string SKU { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public ICollection<ImageDTO> Images { get; set; }
    }
}