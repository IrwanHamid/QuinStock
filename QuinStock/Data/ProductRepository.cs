using QuinStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuinStock.Data
{
    public class ProductRepository
    {
        private ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAllProduct()
        {
            return _context.Products.ToList();
        }

        public Product AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void UpdateProduct(int productId, Product product)
        {
            var productInDb = _context.Products.FirstOrDefault(ps => ps.Id == productId);

            productInDb.Name = product.Name;
            productInDb.IsListedInStore = product.IsListedInStore;
            productInDb.ProductSizes = product.ProductSizes;
            productInDb.ProductColors = product.ProductColors;
            productInDb.ProductImages = product.ProductImages;

            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var productInDb = _context.Products.FirstOrDefault(ps => ps.Id == productId);

            _context.Products.Remove(productInDb);
            _context.SaveChanges();
        }
    }
}
