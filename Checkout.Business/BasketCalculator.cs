using Checkout.DataAccess.Models;

namespace Checkout.Business
{
    public class BasketCalculator
    {
        public Basket CalulateBasketTotals(Basket basket)
        {
            if (basket.Items.Count == 0)
                return basket;
            double total = 0;
            foreach (var item in basket.Items)
            {
                 total  =+ item.Price;
            }

            basket.TotalNet = total;
            if (basket.PaysVAT)
            {
                basket.TotalGross = basket.TotalNet + (basket.TotalNet * 0.1);
            }

            return basket;
        }
    }
}
