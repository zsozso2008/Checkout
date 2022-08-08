using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Checkout.DataAccess.Models;

namespace Checkout.DataAccess.Repositories
{
    public interface IBasketRepository
    {
        Task<Basket> GetBasketAsync(Guid basketId);
        Basket Create();
        Task SaveAsync();
        Task Add(Basket basket);
    }
}
