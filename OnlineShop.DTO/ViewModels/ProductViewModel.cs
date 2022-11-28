using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Data.Entities.Product;
using OnlineShop.Data.Entities.CategoryClass;

namespace OnlineShop.DTO.ViewModels
{
    public class ProductViewModel
    {
            public string Name { get; set; }
            public decimal Price { set; get; }
            public int ViewCount { get; set; }
            public decimal OriginalPrice { set; get; }
            public int Stock { set; get; }
            public List<ProductImages> ProductImages { get; set; }
            public Category Category { get; set; }

    }
}
