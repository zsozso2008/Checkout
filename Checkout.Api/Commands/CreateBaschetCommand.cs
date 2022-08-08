using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Checkout.Api.Commands
{
    public class CreateBaschetCommand : IRequest<Guid>
    {
        public Guid BaschetId { get; set; }
        public string Custormer { get; set; }
        public bool PaysVAT { get; set; }
    }
}
