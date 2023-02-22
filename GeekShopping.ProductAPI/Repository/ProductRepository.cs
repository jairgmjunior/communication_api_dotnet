using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _context;

        public ProductRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> FindAll()
        {
            var products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> FindById(long id)
        {
            var product = await _context.Products
                                        .Where(p => p.Id == id)
                                        .FirstOrDefaultAsync();
            return product;
        }

        public async Task<bool> Create(Product product)
        {
            _context.Products.Add(product);

            var hasCreated = await _context.SaveChangesAsync();

            return hasCreated > 0;
        }
        public async Task<Product> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> Delete(Product product)
        {
            try
            {
                _context.Products.Remove(product);
                var hasDeleted = await _context.SaveChangesAsync();

                return hasDeleted > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
