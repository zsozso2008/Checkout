using System;

using System.Threading;
using System.Threading.Tasks;
using Checkout.DataAccess.Models;
using Checkout.DataAccess.Repositories;
using MediatR;

namespace Checkout.Api.Commands
{
    public class PatchBasketCommandHandler : IRequestHandler<PatchBasketCommand, Guid>
    {
        private readonly IBasketRepository _basketRepository;

        public PatchBasketCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Guid> Handle(PatchBasketCommand request, CancellationToken cancellationToken)
        {
            var busket = await _basketRepository.GetBasketAsync(request.BasketId).ConfigureAwait(false);
            busket.Payed = request.Payed;
            busket.Closed = request.Close;

            await _basketRepository.SaveAsync();
            return busket.Id;
        }
    }
}
