using Checkout.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkout.Api.Queries.ViewModel
{
    public class BasketViewModel
    {
        public Guid Id { get; set; }
        public string Custommer { get; set; }
        public string Customer { get; set; }
        public bool PaysVAT { get; set; }
        public virtual ICollection<Article> Items { get; set; }
        public double TotalNet { get; set; }
        public double TotalGross { get; set; }

    }
}
