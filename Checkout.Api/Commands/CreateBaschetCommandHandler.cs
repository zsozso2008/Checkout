using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Checkout.DataAccess.Models;
using Checkout.DataAccess.Repositories;
using MediatR;
using Microsoft.Extensions.WebEncoders.Testing;

namespace Checkout.Api.Commands
{
    public class CreateBaschetCommandHandler : IRequestHandler<CreateBaschetCommand, Guid>
    {
        private readonly IBasketRepository _basketRepository;

        public CreateBaschetCommandHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Guid> Handle(CreateBaschetCommand request, CancellationToken cancellationToken)
        {
            var basket = _basketRepository.Create();
            basket.Id = Guid.NewGuid();
            basket.Customer = request.Custormer;
            basket.PaysVAT = request.PaysVAT;
            basket.Items = new List<Article>();
            _basketRepository.Add(basket);
            await _basketRepository.SaveAsync();
            return basket.Id;
        }
    }
}
