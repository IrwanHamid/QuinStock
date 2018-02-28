using QuinStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuinStock.Data
{
    public class ProductSizeRepository
    {
        private ApplicationDbContext _context;

        public ProductSizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductSize> GetAllProductSize()
        {
            return _context.ProductSizes.ToList();
        }

        public IEnumerable<ProductSize> GetAllProductSizeByProductId(int productId)
        {
            return _context.ProductSizes.Where(ps => ps.ProductId == productId).ToList();
        }

        public ProductSize AddProductSize(ProductSize productSize)
        {
            _context.ProductSizes.Add(productSize);
            _context.SaveChanges();

            return productSize;
        }

        public void UpdateProductSize(int productSizeId, ProductSize productSize)
        {
            var productSizeInDb = _context.ProductSizes.FirstOrDefault(ps => ps.Id == productSizeId);

            productSizeInDb.Name = productSize.Name;
            productSizeInDb.ProductId = productSize.ProductId;

            _context.SaveChanges();
        }

        public void DeleteProductSize(int productSizeId)
        {
            var productSizeInDb = _context.ProductSizes.FirstOrDefault(ps => ps.Id == productSizeId);

            _context.ProductSizes.Remove(productSizeInDb);
            _context.SaveChanges();
        }
    }
}
