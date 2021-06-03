using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = await _context
                        .Products
                        .Include(t => t.ProductType)
                        .Include(b => b.ProductBrand)
                        .ToListAsync();
            
            return products;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productById = await _context
                            .Products
                            .Include(t => t.ProductType)
                            .Include(b => b.ProductBrand)
                            .FirstOrDefaultAsync(x => x.Id == id);

            return productById;
        }

        public async Task<IEnumerable<ProductType>> GetProductTypesAsync()
        {
            var brands = await _context.ProductTypes.ToListAsync();

            return brands;
        }

        public async Task<IEnumerable<ProductBrand>> GetProductBrandsAsync()
        {
            var types = await _context.ProductBrands.ToListAsync();

            return types;
        }
    }
}