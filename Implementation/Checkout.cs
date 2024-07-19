using CheckoutPricing.Interfaces;
using CheckoutPricing.Models;

namespace CheckoutPricing.Implementation
{
    public class Checkout : ICheckout
    {
        public void AddDiscountRule(string sku, int quantity, decimal discountPrice)
        {
            throw new NotImplementedException();
        }

        public void Scan(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
