using QuinStock.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuinStock.Data
{
    public class ProductColorRepository
    {
        private ApplicationDbContext _context;

        public ProductColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }        

        public IEnumerable<ProductColor> GetAllProductColor()
        {
            return _context.ProductColors.ToList();
        }

        public IEnumerable<ProductColor> GetAllProductColorByProductId(int productId)
        {
            return _context.ProductColors.Where(ps => ps.ProductId == productId).ToList();
        }

        public ProductColor AddProductColor(ProductColor productColor)
        {
            _context.ProductColors.Add(productColor);
            _context.SaveChanges();

            return productColor;
        }

        public void UpdateProductColor(int productColorId, ProductColor productColor)
        {
            var productColorInDb = _context.ProductColors.FirstOrDefault(ps => ps.Id == productColorId);

            productColorInDb.Name = productColor.Name;
            productColorInDb.ProductId = productColor.ProductId;

            _context.SaveChanges();
        }

        public void DeleteProductColor(int productColorId)
        {
            var productColorInDb = _context.ProductColors.FirstOrDefault(ps => ps.Id == productColorId);

            _context.ProductColors.Remove(productColorInDb);
            _context.SaveChanges();
        }
    }
}
