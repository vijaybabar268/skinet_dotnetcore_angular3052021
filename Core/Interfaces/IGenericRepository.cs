using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> ListAllAsync();

        Task<T> GetByIdAsync(int id);
         
        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);

        Task<T> GetEntityWithSpec(ISpecification<T> spec);

        Task<int> CountAsync(ISpecification<T> spec);
    }
}