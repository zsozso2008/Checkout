using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Checkout.Api.Commands
{
    public class PatchBasketCommand : IRequest<Guid>
    {
        public Guid BasketId { get; set; }
        public bool Close { get; set; }
        public bool Payed { get; set; }
    }
}
