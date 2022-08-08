using System;
using System.Threading;
using System.Threading.Tasks;
using Checkout.DataAccess.Models;
using Checkout.DataAccess.Repositories;
using MediatR;

namespace Checkout.Api.Commands
{
    internal class AddArticleCommandHandler : IRequestHandler<AddArticleCommand, Guid>
    {
        private readonly IBasketRepository _basketRepository;

        public AddArticleCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Guid> Handle(AddArticleCommand request, CancellationToken cancellationToken)
        {
            var busket = await _basketRepository.GetBasketAsync(request.BasketId).ConfigureAwait(false);
            busket.Items.Add(new Article
            {
                Item = request.Item, 
                Price = request.Price
            });
            
            await _basketRepository.SaveAsync();
            return busket.Id;
        }
    }
}
