using System;
using MediatR;

namespace Checkout.Api.Commands
{
    public class AddArticleCommand : IRequest<Guid>
    {
        public Guid BasketId { get; set; }
        public string Item { get; set; }
        public double Price { get; set; }
    }
}
