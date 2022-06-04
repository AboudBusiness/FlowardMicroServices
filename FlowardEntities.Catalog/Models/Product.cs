using System;
using System.Collections.Generic;

namespace FlowardEntities.Catalog.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
        public byte[]? Image { get; set; }
    }
}
