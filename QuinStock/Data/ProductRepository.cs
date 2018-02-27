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

        //TODO: Check avaibility of record 
        public IEnumerable<ProductSize> GetAllProductSize()
        {
            return _context.ProductSizes.ToList();
        }

        //TODO: Check avaibility of record 
        public IEnumerable<ProductSize> GetAllProductSizeByProductId(Product product)
        {
            return _context.ProductSizes.Where(ps => ps.ProductId == product.Id).ToList();
        }

        public ProductSize AddProductSize(ProductSize productSize)
        {
            _context.ProductSizes.Add(productSize);
            _context.SaveChanges();

            return productSize;
        }

        //TODO: Check avaibility of record 
        public void UpdateProductSize(int productSizeId, ProductSize productSize)
        {
            var productSizeInDb = _context.ProductSizes.FirstOrDefault(ps => ps.Id == productSizeId);

            productSizeInDb.Name = productSize.Name;
            productSizeInDb.ProductId = productSize.ProductId;

            _context.SaveChanges();
        }

        //TODO: Check avaibility of record 
        public void DeleteProductSize(int productSizeId)
        {
            var productSizeInDb = _context.ProductSizes.FirstOrDefault(ps => ps.Id == productSizeId);

            _context.ProductSizes.Remove(productSizeInDb);
            _context.SaveChanges();
        }
    }
}
