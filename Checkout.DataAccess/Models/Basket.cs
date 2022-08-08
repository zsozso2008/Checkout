using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkout.DataAccess.Models
{
   public class Basket
    {
        [Key]
        public Guid Id { get; set; }

        public string Customer { get; set; }

        [DefaultValue(false)]
        public bool PaysVAT { get; set; }

        public virtual ICollection<Article> Items { get; set; }

        public double TotalNet { get; set; }

        public double TotalGross { get; set; }

        [DefaultValue(false)]
        public bool Closed { get; set; }

        [DefaultValue(false)]
        public bool Payed { get; set; }
    }
}
