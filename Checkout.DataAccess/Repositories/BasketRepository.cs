using System;
using System.Threading.Tasks;
using Checkout.DataAccess.Models;

namespace Checkout.DataAccess.Repositories
{
    public class BasketRepository : RepositoryAsync<Basket>, IBasketRepository
    {
        public BasketRepository(BasketDbContext dbContext) : base(dbContext)
        {

        }

        public Basket Create()
        {
            return new Basket();
        }

        public Task<Basket> GetBasketAsync(Guid basketId)
        {
            return null;
        }

        async Task IBasketRepository.Add(Basket basket)
        {
            _dbContext.Add(basket);
            await _dbContext.SaveChangesAsync();
        }

        async Task IBasketRepository.SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
