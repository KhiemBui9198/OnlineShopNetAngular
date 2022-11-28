using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Data.Entities.Product;
using OnlineShop.DTO.ViewModels;
using OnlineShop.Repo.Interfaces;
using OnlineShop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data.Entities.Identity;

namespace OnlineShop.Repo
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public ProductRepository(DataBaseContext dbContext)
        {
            _dataBaseContext = dbContext;
        }
        public async Task<Products> AddProduct(ProductViewModel product)
        {
            var products = new Products()
            {
                Name = product.Name,
                Price = product.Price,
                ViewCount = product.ViewCount,
                OriginalPrice = product.OriginalPrice,
                Stock = product.Stock,
                Category = product.Category

            };
            _dataBaseContext.Products.Add(products);
            await _dataBaseContext.SaveChangesAsync();
            return products;
        }

        public async Task<bool> DeleteProduct(long id)
        {
            var products = await _dataBaseContext.Products.FirstOrDefaultAsync(item => item.Id == id);
            if (products != null)
            {
                _dataBaseContext.Remove(products);
                await _dataBaseContext.SaveChangesAsync();
                return true;
            }
            throw new Exception($"Can not find item with id {id}");
        }

        public async Task<IEnumerable<Products>> GetAllProducts()
        {
            var query = await _dataBaseContext.Products.ToListAsync();
            return query;
        }

        public async Task<Products> GetProductById(long id)
        {
            var products = await _dataBaseContext.Products.FirstOrDefaultAsync(item => item.Id == id);
            return products;
        }

        public async Task<Products> UpdateProduct(long id, ProductViewModel product)
        {
            var products = await _dataBaseContext.Products.FindAsync(id);
            if (products != null)
            {
                products.Name = product.Name;
                products.Price = product.Price;
                products.ViewCount = product.ViewCount;
                products.OriginalPrice = product.OriginalPrice;
                products.Stock = product.Stock;
                products.Category = product.Category;

                await _dataBaseContext.SaveChangesAsync();
                return products;
            }
            throw new Exception($"Can not find item with id {id}");
        }
    }
}
