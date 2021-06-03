using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();

        Task<Product> GetProductByIdAsync(int id);

        Task<IEnumerable<ProductType>> GetProductTypesAsync();

        Task<IEnumerable<ProductBrand>> GetProductBrandsAsync();
    }
}