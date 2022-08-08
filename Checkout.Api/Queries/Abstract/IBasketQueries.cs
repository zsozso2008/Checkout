using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Api.Queries.ViewModel;

namespace Checkout.Api.Queries.Abstract
{
    internal interface IBasketQueries
    {
        Task<IEnumerable<BasketViewModel>> GetBasketsAsyc();
        Task<BasketViewModel> GetBasketAsyc(Guid basketId);
    }
}
