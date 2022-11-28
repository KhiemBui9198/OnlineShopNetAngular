using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Data.Entities.Product;
using OnlineShop.Data.Entities.Identity;
using OnlineShop.Data.Entities.CategoryClass;

namespace OnlineShop.Data.Entities.Product
{
    public class Products: BaseEntity
    {
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public decimal Price { set; get; }
        public int ViewCount { get; set; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public List<ProductImages> ProductImages { get; set; }
        public Category Category { get; set; }

    }
}
