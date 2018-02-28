using QuinStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuinStock.Data
{
    public class ProductImageRepository
    {
        private ApplicationDbContext _context;

        public ProductImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductImage> GetAllProductImage()
        {
            return _context.ProductImages.ToList();
        }

        public IEnumerable<ProductImage> GetAllProductImageByProductId(int productId)
        {
            return _context.ProductImages.Where(ps => ps.ProductId == productId).ToList();
        }

        public ProductImage AddProductImage(ProductImage productImage)
        {
            _context.ProductImages.Add(productImage);
            _context.SaveChanges();

            return productImage;
        }

        public void UpdateProductImage(int productImageId, ProductImage productImage)
        {
            var productImageInDb = _context.ProductImages.FirstOrDefault(ps => ps.Id == productImageId);

            productImageInDb.Path = productImage.Path;
            productImageInDb.ProductId = productImage.ProductId;

            _context.SaveChanges();
        }

        public void DeleteProductImage(int productImageId)
        {
            var productImageInDb = _context.ProductImages.FirstOrDefault(ps => ps.Id == productImageId);

            _context.ProductImages.Remove(productImageInDb);
            _context.SaveChanges();
        }
    }
}
