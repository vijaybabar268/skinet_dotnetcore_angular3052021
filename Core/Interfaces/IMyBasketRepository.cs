
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMyBasketRepository
    {
         Task<CustomerBasket> GetBasketAsync(string basketId);
         
         Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

         Task<bool> DeleteBasketAsync(string basketId);
    }
} 