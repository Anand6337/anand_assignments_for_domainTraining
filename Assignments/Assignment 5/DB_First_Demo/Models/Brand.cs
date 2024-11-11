using System;
using System.Collections.Generic;

namespace DB_First_Demo.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; } = null!;

        public virtual ICollection<Product> Products { get; set; }
    }
}
