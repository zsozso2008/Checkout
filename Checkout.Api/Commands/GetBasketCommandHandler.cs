using System.Threading;
using System.Threading.Tasks;
using Checkout.Api.Queries.Abstract;
using Checkout.Api.Queries.ViewModel;
using Checkout.Business;
using Checkout.DataAccess.Models;
using Checkout.DataAccess.Repositories;
using MediatR;

namespace Checkout.Api.Commands
{
    internal class GetBasketCommandHandler : IRequestHandler<GetBasketCommand, Basket>
    {
        private readonly IBasketQueries _baschetQueris;
        private readonly IBasketRepository _basketRepository;

        public GetBasketCommandHandler(IBasketRepository basketRepository, IBasketQueries baschetQueris)
        {
            _basketRepository = basketRepository;
            _baschetQueris = baschetQueris;
        }


        public async Task<Basket> Handle(GetBasketCommand request, CancellationToken cancellationToken)
        {
            var basketQuery = await _baschetQueris.GetBasketAsyc(request.BasketId).ConfigureAwait(false);

            var basket = await _basketRepository.GetBasketAsync(request.BasketId).ConfigureAwait(false);
            BasketCalculator basketCalculator = new BasketCalculator();
            basketCalculator.CalulateBasketTotals(basket);
            return basket;
        }
    }
}
