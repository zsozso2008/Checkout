using Checkout.DataAccess.Repositories;
using MediatR;
using System;
using Checkout.DataAccess.Models;

namespace Checkout.Api.Commands
{
    public class GetBasketCommand : IRequest<Basket>
    {
        public Guid BasketId { get; set; }
    }
}
